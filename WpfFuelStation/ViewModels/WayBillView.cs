using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Unity;
using WpfFuelStation.Controls;
using WpfFuelStation.Enums;
using WpfFuelStation.Infrastructure;
using WpfFuelStation.Models;
using WpfFuelStation.Models.DataModels;

namespace WpfFuelStation.ViewModels
{
    public class WayBillView : BindableBase
    {
        IMessageSender messageSender;
        IRepository repository;
        MessageWindow messageWindow;
        UnityContainer container;
        TransportWindow transportWindow;
        DriverWindow driverWindow;

        int transportId;
        int driverId;

        public WayBillView(IMessageSender messageSender, IRepository repository)
        {
            this.messageSender = messageSender;
            this.repository = repository;
            container = new UnityContainer();

            GetFuelMarks();
            DepartmentDate = DateTime.Now;
            TransportAction += TransportDemo;
            DriverAction += DriverDemo;
            ShowTransportWindowCommand = new DelegateCommand(() => ShowTransportWindow());
            ShowDriverWindowCommand = new DelegateCommand(() => ShowDriverWindow());
            GetFuelMarkCommand = new DelegateCommand(() => GetFuelMark());
            SaveWayBillCommand = new DelegateCommand(() => SaveWayBill());
        }

        public DelegateCommand ShowTransportWindowCommand { get; }
        public DelegateCommand ShowDriverWindowCommand { get; }
        public DelegateCommand GetFuelMarkCommand { get; }
        public DelegateCommand SaveWayBillCommand { get; }

        public List<string> FuelMarks { get; set; }
        public bool IsGuide { get; set; }
        

        string wayBillNumber;
        public string WayBillNumber
        {
            get => wayBillNumber;
            set { wayBillNumber = value; RaisePropertyChanged(nameof(WayBillNumber)); }
        }

        DateTime departmentDate;
        public DateTime DepartmentDate
        {
            get => departmentDate;
            set { departmentDate = value; RaisePropertyChanged(nameof(DepartmentDate)); }
        }

        string departmentPlace;
        public string DepartmentPlace
        {
            get => departmentPlace;
            set { departmentPlace = value; RaisePropertyChanged(nameof(DepartmentPlace)); }
        }

        float fuelLimit;
        public float FuelLimit
        {
            get => fuelLimit;
            set { fuelLimit = value; RaisePropertyChanged(nameof(FuelLimit)); }
        }

        string transport;
        public string Transport
        {
            get => transport;
            set { transport = value; RaisePropertyChanged(nameof(Transport)); }
        }

        string driver;
        public string Driver
        {
            get => driver;
            set { driver = value; RaisePropertyChanged(nameof(Driver)); }
        }

        string fuel;
        public string Fuel
        {
            get => fuel;
            set { fuel = value; RaisePropertyChanged(nameof(Fuel)); }
        }


        private void ShowTransportWindow()
        {
            IsGuide = true;
            container.RegisterInstance<IMessageSender>(messageSender);
            container.RegisterInstance<IRepository>(repository);
            container.RegisterInstance<WayBillView>(this);
            transportWindow = container.Resolve<TransportWindow>();
            transportWindow.Show();
        }

        private void ShowDriverWindow()
        {
            IsGuide = true;
            container.RegisterInstance<IMessageSender>(messageSender);
            container.RegisterInstance<IRepository>(repository);
            container.RegisterInstance<WayBillView>(this);
            driverWindow = container.Resolve<DriverWindow>();
            driverWindow.Show();
        }

        private void SaveWayBill()
        {
            try
            {
                if(!string.IsNullOrEmpty(WayBillNumber) &&  !string.IsNullOrEmpty(DepartmentPlace) && 
                    !string.IsNullOrEmpty(Transport) && !string.IsNullOrEmpty(Driver) && !string.IsNullOrEmpty(Fuel))
                {
                    using (var context = new FuelContext())
                    {
                        var fuelId = context.Fuels.Where(x => x.FuelMark == Fuel).FirstOrDefault().Id;
                        if (!context.WayBills.Any(x => x.WayBillNumber == WayBillNumber))
                        {
                            using (var transaction = context.Database.BeginTransaction())
                            {
                                try
                                {
                                    context.WayBills.Add(new WayBill()
                                    {
                                        DepartmentDate = DepartmentDate,
                                        DepartmentPlace = DepartmentPlace,
                                        FuelLimit = FuelLimit,
                                        WayBillNumber = WayBillNumber
                                    });
                                    context.SaveChanges();
                                    var wayBillId = context.WayBills.Where(x => x.WayBillNumber == WayBillNumber)
                                        .OrderByDescending(y => y.Id)
                                        .FirstOrDefault().Id;
                                    context.DriverTransports.Add(new DriverTransport()
                                    {
                                        DriverId = driverId,
                                        TransportId = transportId,
                                        FuelId = fuelId,
                                        WayBillId = wayBillId
                                    });
                                    context.SaveChanges();
                                    transaction.Commit();
                                    ShowMessageWindow("Сообщение", "Сохранено.", MessageEnums.Success);
                                }
                                catch (Exception ex) { ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error); transaction.Rollback(); }
                            }
                        }
                        else
                            ShowMessageWindow("Ошибка", "Путевой лист с таким номером уже существует.", MessageEnums.Warning);
                    }
                }
                else
                    ShowMessageWindow("Ошибка", "Заполните данные.", MessageEnums.Warning);
            }
            catch (Exception ex) { ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error); }
        }

        private void GetFuelMarks()
        {
            try
            {
                FuelMarks = new List<string>();
                foreach (var t in repository.Fuels)
                    FuelMarks.Add(t.FuelMark);
            }
            catch (Exception ex) { ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error); }
        }

        private void GetFuelMark()
        {
            RaisePropertyChanged(nameof(Fuel));
        }

        public Action<string> TransportAction { get; set; }
        public void TransportDemo(string s)
        {
            var list = s.Split(' ').ToList();
            for (int i = 0; i < list.Count - 1; i++)
                Transport += list[i] + " ";
            transportId = int.Parse(list.LastOrDefault());
            transportWindow.Close();
            IsGuide = false;
            ShowMessageWindow("Сообщение", "Транспорт принят.", MessageEnums.Success);
        }

        public Action<string> DriverAction { get; set; }
        public void DriverDemo(string s)
        {
            var list = s.Split(' ').ToList();
            for (int i = 0; i < list.Count - 1; i++)
                Driver += list[i] + " ";
            driverId = int.Parse(list.LastOrDefault());
            driverWindow.Close();
            IsGuide = false;
            ShowMessageWindow("Сообщение", "Водитель принят.", MessageEnums.Success);
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
