using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Unity;
using WpfFuelStation.Models;
using WpfFuelStation.Infrastructure;
using WpfFuelStation.Models.DataModels;
using WpfFuelStation.Enums;
using WpfFuelStation.Controls;

namespace WpfFuelStation.ViewModels
{
    public class DriverView : BindableBase
    {
        IMessageSender messageSender;
        IRepository repository;
        MessageWindow messageWindow;
        UnityContainer container;
        WayBillView billView;

        int driverId;

        public DriverView(IMessageSender messageSender, IRepository repository, WayBillView billView)
        {
            this.messageSender = messageSender;
            this.repository = repository;
            container = new UnityContainer();
            this.billView = billView;


            if (billView.IsGuide)
            {
                Content = "Выбрать";
                IsGuide = false;
            }
            else
            {
                Content = "Изменить";
                IsGuide = true;
            }
            GetDrivers();
            GetCurrentRowIdCommand = new DelegateCommand(() => GetCurrentRowId());
            SaveDriverDatasCommand = new DelegateCommand(() => SaveDriverDatas());
            DeleteDriverCommand = new DelegateCommand(() => DeleteDriver());
            ChangeDriverCommand = new DelegateCommand(() => ChangeDriver());
        }

        public DelegateCommand ShowHelperWindowCommand { get; }
        public DelegateCommand GetCurrentRowIdCommand { get; }
        public DelegateCommand SaveDriverDatasCommand { get; }
        public DelegateCommand DeleteDriverCommand { get; }
        public DelegateCommand<string> LoadGuideCommand { get; }
        public DelegateCommand ChangeDriverCommand { get; }

        public List<DriverDataModels> DriverDatas { get; set; }
        public List<string> Transports { get; set; }
        public int DriverId { get; set; }
        public bool IsGuide { get; set; }
        public string Content { get; set; }

        string name;
        public string Name
        {
            get => name;
            set { name = value; RaisePropertyChanged(nameof(Name)); }
        }

        string middleName;
        public string MiddleName
        {
            get => middleName;
            set { middleName = value; RaisePropertyChanged(nameof(MiddleName)); }
        }

        string surname;
        public string Surname
        {
            get => surname;
            set { surname = value;RaisePropertyChanged(nameof(Surname)); }
        }

        string serviceNumber;
        public string ServiceNumber
        {
            get => serviceNumber;
            set { serviceNumber = value; RaisePropertyChanged(nameof(ServiceNumber)); }
        }

        
        public string FullInfo { get; set; }
        
        private void GetCurrentRowId()
        {
            RaisePropertyChanged(nameof(DriverId));
            if(DriverDatas.Count > 0)
            {
                driverId = DriverDatas[DriverId].DriverId;
                var temp = repository.Drivers.Where(x => x.Id == driverId).FirstOrDefault();
                Name = temp.Name;
                Surname = temp.Surname;
                MiddleName = temp.MiddleName;
                ServiceNumber = temp.ServiceNumber.ToString();
                FullInfo = $"{Surname} {Name} {MiddleName} {ServiceNumber}";
            }
        }

        private void GetDrivers()
        {
            try
            {
                DriverDatas = new List<DriverDataModels>();
                Transports = new List<string>();
                if (repository.Drivers.Count() > 0)
                {
                    foreach (var t in repository.Drivers)
                    {
                        DriverDatas.Add(new DriverDataModels()
                        {
                            DriverId = t.Id,
                            MiddleName = t.MiddleName,
                            Name = t.Name,
                            ServiceNumber = t.ServiceNumber.ToString(),
                            Surname = t.Surname
                        });
                    }
                }
                RaisePropertyChanged(nameof(DriverDatas));
                RaisePropertyChanged(nameof(Transports));
            }
            catch (Exception ex) {  }
        }

        private void GetDriversAfterChange()
        {
            try
            {
                DriverDatas = new List<DriverDataModels>();
                using (var context = new FuelContext())
                {
                    if (context.Drivers.Count() > 0)
                    {
                        foreach (var t in context.Drivers)
                        {
                            DriverDatas.Add(new DriverDataModels()
                            {
                                DriverId = t.Id,
                                MiddleName = t.MiddleName,
                                Name = t.Name,
                                ServiceNumber = t.ServiceNumber.ToString(),
                                Surname = t.Surname
                            });
                        }
                    }
                }
                RaisePropertyChanged(nameof(DriverDatas));
            }
            catch (Exception ex) { }
        }

        private void SaveDriverDatas()
        {
            try
            {
                using (var context = new FuelContext())
                {
                    if (!string.IsNullOrEmpty(ServiceNumber))
                    {
                        var servNum = int.Parse(ServiceNumber);
                        if (!context.Drivers.Any(x => x.ServiceNumber == servNum))
                        {
                            context.Drivers.Add(new Driver()
                            {
                                MiddleName = MiddleName,
                                Name = Name,
                                Surname = Surname,
                                ServiceNumber = int.Parse(ServiceNumber)
                            });
                            context.SaveChanges();
                            ShowMessageWindow("Сообщение", "Данные сохранены", MessageEnums.Success);
                            GetDrivers();
                        }

                        else
                            ShowMessageWindow("Ошибка", "Табельный номер присутствует.", MessageEnums.Error);
                    }
                }
            }
            catch (Exception ex) { ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error); }
        }

        private void ChangeDriver()
        {
            try
            {
                if (IsGuide)
                {
                    if (!string.IsNullOrEmpty(ServiceNumber))
                    {
                        int id = DriverDatas[DriverId].DriverId;
                        using (var context = new FuelContext())
                        {
                            var temp = context.Drivers.Where(x => x.Id == id).FirstOrDefault();
                            temp.Name = Name;
                            temp.ServiceNumber = int.Parse(ServiceNumber);
                            temp.MiddleName = MiddleName;
                            temp.Surname = Surname;
                            context.SaveChanges();
                        }
                        ShowMessageWindow("Сообщение", "Данные отредактированны.", MessageEnums.Success);
                        GetDriversAfterChange();
                        Name = ServiceNumber = Surname = MiddleName = "";
                    }
                    else
                        ShowMessageWindow("Сообщение", "Ошибка заполнения", MessageEnums.Error);
                }
                else
                    DriverDemo();
            }
            catch (Exception ex) { ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error); }
        }

        private void DeleteDriver()
        {
            try
            {
                if (!string.IsNullOrEmpty(ServiceNumber))
                {
                    int id = DriverDatas[DriverId].DriverId;
                    using (var context = new FuelContext())
                    {
                        var temp = context.Drivers.Where(x => x.Id == id).FirstOrDefault();
                        context.Drivers.Remove(temp);
                        context.SaveChanges();
                    }
                    ShowMessageWindow("Сообщение", "Данные удалены", MessageEnums.Success);
                    GetDriversAfterChange();
                    Name = ServiceNumber = Surname = MiddleName = "";
                }
                else
                    ShowMessageWindow("Сообщение", "Ошибка заполнения", MessageEnums.Error);
            }
            catch (Exception ex) { ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error); }
        }

        private void DriverDemo()
        {
            if (!string.IsNullOrEmpty(Surname) && !string.IsNullOrEmpty(Name))
                billView.DriverAction.Invoke($"{Surname} {Name} {MiddleName} {driverId}");
            else
                ShowMessageWindow("Сообщение", "Выберите транспорт.", MessageEnums.Error);
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
