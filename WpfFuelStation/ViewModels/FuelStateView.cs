using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Unity;
using WpfFuelStation.Enums;
using WpfFuelStation.Infrastructure;
using WpfFuelStation.Models;
using WpfFuelStation.Models.DataModels;

namespace WpfFuelStation.ViewModels
{
    public class FuelStateView : BindableBase
    {
        IMessageSender messageSender;
        IRepository repository;
        MessageWindow messageWindow;
        UnityContainer container;

        public FuelStateView(IMessageSender messageSender, IRepository repository)
        {
            this.messageSender = messageSender;
            this.repository = repository;
            container = new UnityContainer();

            GetFuelStateDatas();
            GetFuelMarkCommand = new DelegateCommand(() => GetFuelMark());
            GetCurrentRowIdCommand = new DelegateCommand(() => GetCurrentRowId());
            SaveFuelStateCommand = new DelegateCommand(() => SaveFuelState());
            DeleteFuelStateCommand = new DelegateCommand(() => DeleteFuelState());
        }

        public DelegateCommand GetFuelMarkCommand { get; }
        public DelegateCommand GetCurrentRowIdCommand { get; }
        public DelegateCommand SaveFuelStateCommand { get; }
        public DelegateCommand DeleteFuelStateCommand { get; }

        public List<FuelStateDataModels> FuelStateDatas { get; set; }
        public List<string> FuelMarks { get; set; }
        public bool IsChecked { get; set; }

        float temperature;
        public float Temperature
        {
            get => temperature;
            set{ temperature = value; RaisePropertyChanged(nameof(Temperature)); }
        }
        float pressure;
        public float Pressure
        {
            get => pressure;
            set { pressure = value; RaisePropertyChanged(nameof(Pressure)); }
        }
        string fuelMark;
        public string FuelMark
        {
            get => fuelMark;
            set { fuelMark = value; RaisePropertyChanged(nameof(FuelMark)); }
        }

        DateTime checkingDate;
        public DateTime CheckingDate
        {
            get => checkingDate;
            set { checkingDate = value; RaisePropertyChanged(nameof(CheckingDate)); }
        }

        float maxQuantity;
        public float MaxQuantity
        {
            get => maxQuantity;
            set { maxQuantity = value; RaisePropertyChanged(nameof(MaxQuantity)); }
        }

        private void GetFuelStateDatas()
        {
            try
            {
                FuelStateDatas = new List<FuelStateDataModels>();
                FuelMarks = new List<string>();
                if (repository.FuelStates.Count() > 0)
                {
                    foreach (var t in repository.FuelStates)
                    {
                        string s = repository.Fuels.Where(x => x.Id == t.FuelId).FirstOrDefault().FuelMark;
                        FuelStateDatas.Add(new FuelStateDataModels()
                        {
                            CheckingDate = t.CheckingDate,
                            FuelMark = s,
                            Id = t.Id,
                            Pressure = t.Pressure,
                            Temperature = t.Temperature,
                            IsChecked = true
                        });
                    }
                    RaisePropertyChanged(nameof(FuelStateDatas));
                }
                if (repository.Fuels.Count() > 0)
                {
                    foreach (var t in repository.Fuels)
                        FuelMarks.Add(t.FuelMark);
                    RaisePropertyChanged(nameof(FuelMarks));
                }
            }
            catch (Exception ex) {  }
        }

        private void SaveFuelState()
        {
            try
            {
                var date = repository.FuelStates.Select(x => x).LastOrDefault().CheckingDate;
                if (date < CheckingDate && !IsChecked)
                {
                    using (var context = new FuelContext())
                    {
                        if (!string.IsNullOrEmpty(FuelMark))
                        {
                            var id = repository.Fuels.Where(x => x.FuelMark == FuelMark).FirstOrDefault().Id;
                            context.FuelStates.Add(new FuelState()
                            {
                                Temperature = Temperature,
                                CheckingDate = CheckingDate,
                                FuelId = id,
                                Pressure = Pressure,
                                IsChecked = true
                            });
                        }
                        context.SaveChanges();
                        GetFuelStateDatas();
                        ShowMessageWindow("Сообщение", "Данные сохранены", MessageEnums.Success);
                        IsChecked = false;
                    }
                }
                else
                    ShowMessageWindow("Сообщение", "Дата проверки меньше проведенной до этого.", MessageEnums.Warning);
            }
            catch (Exception ex) { ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error); }
        }

        private void DeleteFuelState()
        {
            try
            {
                int id = FuelStateDatas[StateId].Id;
                using(var context = new FuelContext())
                {
                    var temp = context.FuelStates.Where(x => x.Id == id).FirstOrDefault();
                    context.FuelStates.Remove(temp);
                    context.SaveChanges();
                    GetFuelStateDatas();
                    ShowMessageWindow("Сообщение", "Данные удалены", MessageEnums.Success);
                }
            }
            catch (Exception ex) { ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error); }
        }

        public int StateId { get; set; }
        private void GetCurrentRowId()
        {
            RaisePropertyChanged(nameof(StateId));
            if (FuelStateDatas.Count > 0)
            {
                int id = FuelStateDatas[StateId].Id;
                var temp = FuelStateDatas.Where(x => x.Id == id).FirstOrDefault();
                Temperature = temp.Temperature;
                Pressure = temp.Pressure;
                CheckingDate = temp.CheckingDate;
                FuelMark = temp.FuelMark;
                IsChecked = temp.IsChecked;
            }
        }

        private void GetFuelMark()
        {
            RaisePropertyChanged(nameof(FuelMark));
        }

        private void CloseMessageWindow()
        {
            messageWindow.Close();
        }

        public void ShowMessageWindow(string label, string message, MessageEnums enumMessage)
        {
            messageSender.Label = label;
            messageSender.Message = message;
            messageSender.EnumCount = (int)enumMessage;
            messageSender.CloseWindow += CloseMessageWindow;
            container.RegisterInstance<IMessageSender>(messageSender);
            messageWindow = container.Resolve<MessageWindow>();
            messageWindow.ShowDialog();
        }
    }
}
