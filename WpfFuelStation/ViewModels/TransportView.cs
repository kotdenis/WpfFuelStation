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
    public class TransportView : BindableBase
    {
        IMessageSender messageSender;
        IRepository repository;
        MessageWindow messageWindow;
        UnityContainer container;
        WayBillView billView;

        int transId;

        public TransportView(IMessageSender messageSender, IRepository repository, WayBillView billView)
        {
            this.messageSender = messageSender;
            this.repository = repository;
            container = new UnityContainer();
            this.billView = billView;

            GetTransports();
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

            GetFuelMarkCommand = new DelegateCommand(() => GetFuelMark());
            GetCurrentRowIdCommand = new DelegateCommand(() => GetCurrentRowId());
            SaveTransportDatasCommand = new DelegateCommand(() => SaveTransportDatas());
            ChangeTransportDatasCommand = new DelegateCommand(() => ChangeTransportDatas());
            DeleteTransportCommand = new DelegateCommand(() => DeleteTransport());
        }

        public DelegateCommand GetFuelMarkCommand { get; }
        public DelegateCommand GetCurrentRowIdCommand { get; }
        public DelegateCommand SaveTransportDatasCommand { get; }
        public DelegateCommand ChangeTransportDatasCommand { get; }
        public DelegateCommand DeleteTransportCommand { get; }

        public List<TransportDataModel> TransportVehicles { get; set; }
        public List<string> FuelMarks { get; set; }
        public int TransportId { get; set; }
        public string Content { get; set; }

        string transport;
        public string Transport
        {
            get => transport;
            set { transport = value; RaisePropertyChanged(nameof(Transport)); }
        }
        string transNumber;
        public string TransNumber
        {
            get => transNumber;
            set { transNumber = value;RaisePropertyChanged(nameof(TransNumber)); }
        }
        //string fuelMark;
        //public string FuelMark
        //{
        //    get => fuelMark;
        //    set { fuelMark = value; RaisePropertyChanged(nameof(FuelMark)); }
        //}
        bool isQuide;
        public bool IsGuide
        {
            get => isQuide;
            set { isQuide = value; RaisePropertyChanged(nameof(IsGuide)); }
        }


        private void GetCurrentRowId()
        {
            RaisePropertyChanged(nameof(TransportId));
            if(TransportVehicles.Count > 0)
            {
                transId = TransportVehicles[TransportId].TransportId;
                var temp = TransportVehicles.Where(x => x.TransportId == transId).FirstOrDefault();
                Transport = temp.Transport;
                TransNumber = temp.TransNumber;
            }
        }

        private void SaveTransportDatas()
        {
            try
            {
                using (var context = new FuelContext())
                {
                    if (!string.IsNullOrEmpty(TransNumber)&& !string.IsNullOrEmpty(TransNumber))
                    {
                        
                        if (!context.TransportVehicles.Any(x => x.TransportNumber == TransNumber))
                        {
                            context.TransportVehicles.Add(new TransportVehicle()
                            {
                                Transport = Transport,
                                TransportNumber = TransNumber
                            });
                            context.SaveChanges();
                            ShowMessageWindow("Сообщение", "Данные сохранены", MessageEnums.Success);
                            Transport = TransNumber = "";
                            GetTransports();
                        }
                        else
                            ShowMessageWindow("Сообщение", "Номер автомобиля уже есть в базе.", MessageEnums.Error);
                    }
                    else
                        ShowMessageWindow("Сообщение", "Ошибка заполнения", MessageEnums.Error);
                }
            }
            catch (Exception ex) { ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error); }
        }

        private void GetFuelMark()
        {
            //RaisePropertyChanged(nameof(FuelMark));
        }

        private void GetTransportAfterChange()
        {
            TransportVehicles = new List<TransportDataModel>();
            FuelMarks = new List<string>();
            using (var context = new FuelContext())
            {
                foreach(var t in context.TransportVehicles)
                {
                    TransportVehicles.Add(new TransportDataModel
                    {
                        TransportId = t.Id,
                        Transport = t.Transport,
                        TransNumber = t.TransportNumber
                    });
                }
            }
            RaisePropertyChanged(nameof(TransportVehicles));
        }

        private void GetTransports()
        {
            try
            {
                TransportVehicles = new List<TransportDataModel>();
                FuelMarks = new List<string>();
                foreach (var t in repository.TransportVehicles)
                {
                    TransportVehicles.Add(new TransportDataModel
                    {
                        TransportId = t.Id,
                        Transport = t.Transport,
                        TransNumber = t.TransportNumber
                    });
                }
                RaisePropertyChanged(nameof(TransportVehicles));
                foreach (var t in repository.Fuels.Select(x => x.FuelMark))
                    FuelMarks.Add(t);
            }
            catch (Exception ex) {  }
        }

        private void ChangeTransportDatas()
        {
            try
            {
                if (IsGuide)
                {
                    if (TransportVehicles.Count > 0)
                    {
                        int id = TransportVehicles[TransportId].TransportId;
                        using (var context = new FuelContext())
                        {
                            // context.Database.Log = sql => System.Windows.Forms.MessageBox.Show(sql);
                            var temp = context.TransportVehicles.Where(x => x.Id == id).FirstOrDefault();
                            temp.Transport = Transport;
                            temp.TransportNumber = TransNumber;
                            context.SaveChanges();
                        }
                        ShowMessageWindow("Сообщение", "Данные отредоктированны.", MessageEnums.Success);
                        GetTransportAfterChange();
                        Transport = TransNumber = "";
                    }
                    else
                        ShowMessageWindow("Сообщение", "Ошибка заполнения", MessageEnums.Error);
                }
                else
                    TransportDemo();
            }
            catch (Exception ex) { /*ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error);*/ }
        }

        private void DeleteTransport()
        {
            try
            {
                if (TransportVehicles.Count > 0)
                {
                    int id = TransportVehicles[TransportId].TransportId;
                    using (var context = new FuelContext())
                    {
                        // context.Database.Log = sql => System.Windows.Forms.MessageBox.Show(sql);
                        var temp = context.TransportVehicles.Where(x => x.Id == id).FirstOrDefault();
                        context.TransportVehicles.Remove(temp);
                        context.SaveChanges();
                    }
                    ShowMessageWindow("Сообщение", "Данные удалены.", MessageEnums.Success);
                    GetTransportAfterChange();
                    Transport = TransNumber = "";
                }
                else
                    ShowMessageWindow("Сообщение", "Ошибка заполнения", MessageEnums.Error);
            }
            catch (Exception ex) { ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error); }
        }

        private void TransportDemo()
        {
            if (!string.IsNullOrEmpty(Transport) && !string.IsNullOrEmpty(TransNumber))
                billView.TransportAction.Invoke($"{Transport} {TransNumber} {transId}");
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
