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
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.Windows.Threading;
using WpfFuelStation.Models;
using WpfFuelStation.Controls;
using WpfFuelStation.Models.DataModels;
using FastReport;
using WpfFuelStation.Reports;
using FastReport.Data;

namespace WpfFuelStation.ViewModels
{
    public class ViewMain : BindableBase
    {
        IMessageSender messageSender;
        UnityContainer container;
        MessageWindow messageWindow;
        FuelWindow fuelWindow;
        TransportWindow transportWindow;
        DriverWindow driverWindow;
        WayBillWindow billWindow;
        DriverTransportWindow helperWindow;
        FuelStateWindow stateWindow;
        WayReportWindow reportWindow;
        SettingWindow settingWindow;
        FuelCheckPrepareWindow fuelCheckWindow;
        DispatcherTimer loadingDispatcher;
        DispatcherTimer chargingDispatcher;
        IRepository repository;

        bool isReady;
        int fuelId;
        int wayBillId;

        public ViewMain(IMessageSender messageSender, IRepository repository)
        {
            this.messageSender = messageSender;
            this.repository = repository;
            container = new UnityContainer();
            CreateStartSeries();

            loadingDispatcher = new DispatcherTimer();
            loadingDispatcher.Interval = TimeSpan.FromMilliseconds(500);
            loadingDispatcher.Tick += new EventHandler(CurrentDispathcerTick);
            chargingDispatcher = new DispatcherTimer();
            chargingDispatcher.Interval = TimeSpan.FromMilliseconds(500);
            chargingDispatcher.Tick += new EventHandler(ChargingDispatcherTick);


            ChargeAction += GetChargeInfo;

            TransportViewCommand = new DelegateCommand(() => GetChargeTransportView());
            TanksViewCommand = new DelegateCommand(() => GetFillTanksView());
            RunLoadingDispatcherCommand = new DelegateCommand(() => RunLoadingDispatcher());
            ShowFuelWindowCommand = new DelegateCommand(() => ShowFuelWindow());
            ShowTransportWindowCommand = new DelegateCommand(() => ShowTransportWindow());
            ShowDriverWindowCommand = new DelegateCommand(() => ShowDriverWindow());
            ShowWayBillWindowCommand = new DelegateCommand(() => ShowWayBillWindow());
            ShowFuelStateWindowCommand = new DelegateCommand(() => ShowFuelStateWindow());
            ShowGuideWindowCommand = new DelegateCommand(() => ShowGuideWindow());
            AcceptBeforeChargingCommand = new DelegateCommand(() => AcceptBeforeCharging());
            StartChargingCommand = new DelegateCommand(() => StartCharging());
            GetFuelMarkBeforeLoadingCommand = new DelegateCommand(() => GetFuelMarkBeforeLoading());
            ShowDriverHelperWindowCommand = new DelegateCommand(() => ShowDriverHelperWindow());
            ShowCheckCommand = new DelegateCommand(() => ShowCheck());
            ShowOutCheckPrepareWindowCommand = new DelegateCommand<string>((s) => ShowOutCheckPrepareWindow(s));
            ShowInCheckPrepareWindowCommand = new DelegateCommand<string>((s) => ShowInCheckPrepareWindow(s));
            ShowStateReportPrepareWindowCommand = new DelegateCommand<string>((s) => ShowStateReportPrepareWindow(s));
            ShowWayBillReportWindowCommand = new DelegateCommand(() => ShowWayBillReportWindow());
            ShowSettingWindowCommand = new DelegateCommand(() => ShowSettingWindow());
        }

        #region Properties
        public SeriesCollection YSeries { get; set; }
        public int LoadView { get; set; } = 0;
        public bool IsGuideLoaded { get; set; } = true;
        public bool IsAccepted { get; set; }
        public bool IsCharging { get; set; }
        public bool IsCheckReady { get; set; }
        public List<string> FuelMarks { get; set; }

        double currentWeight;
        public double CurrentWeight
        {
            get => currentWeight;
            set { currentWeight = value; RaisePropertyChanged(nameof(CurrentWeight)); }
        }
        double tankWeight;
        public double TankWeight
        {
            get => tankWeight;
            set { tankWeight = value; RaisePropertyChanged(nameof(TankWeight)); }
        }
        double _xPoint;
        public double XPoints
        {
            get => _xPoint;
            set { _xPoint = value; RaisePropertyChanged(nameof(XPoints)); }
        }


        string transport;
        public string Transport
        {
            get => transport;
            set { transport = value; RaisePropertyChanged(nameof(Transport)); }
        }
        string transportNumber;
        public string TransportNumber
        {
            get => transportNumber;
            set { transportNumber = value; RaisePropertyChanged(nameof(TransportNumber)); }
        }
        string fuelMark;
        public string FuelMark
        {
            get => fuelMark;
            set { fuelMark = value; RaisePropertyChanged(nameof(FuelMark)); }
        }
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
        string driverName;
        public string DriverName
        {
            get => driverName;
            set { driverName = value; RaisePropertyChanged(nameof(DriverName)); }
        }
        string serviceNumber;
        public string ServiceNumber
        {
            get => serviceNumber;
            set { serviceNumber = value; RaisePropertyChanged(nameof(ServiceNumber)); }
        }
        float fuelLimit;
        public float FuelLimit
        {
            get => fuelLimit;
            set { fuelLimit = value; RaisePropertyChanged(nameof(FuelLimit)); }
        }
        float fuelInTank;
        public float FuelInTank
        {
            get => fuelInTank;
            set { fuelInTank = value; RaisePropertyChanged(nameof(FuelInTank)); }
        }
        float fuelCharged;
        public float FuelCharged
        {
            get => fuelCharged;
            set { fuelCharged = value; RaisePropertyChanged(nameof(FuelCharged)); }
        }

        //Filling tanks properties
        float quantity;
        public float Quantity
        {
            get => quantity;
            set { quantity = value; RaisePropertyChanged(nameof(Quantity)); }
        }
        float maxQuantity;
        public float MaxQuantity
        {
            get => maxQuantity;
            set { maxQuantity = value; RaisePropertyChanged(nameof(MaxQuantity)); }
        }
        float fuelToFill;
        public float FuelToFill
        {
            get => fuelToFill;
            set { fuelToFill = value; RaisePropertyChanged(nameof(FuelToFill)); }
        }
        #endregion

        public DelegateCommand TransportViewCommand { get; }
        public DelegateCommand TanksViewCommand { get; }
        public DelegateCommand RunLoadingDispatcherCommand { get; }
        public DelegateCommand ShowFuelWindowCommand { get; }
        public DelegateCommand ShowTransportWindowCommand { get; }
        public DelegateCommand ShowDriverWindowCommand { get; }
        public DelegateCommand ShowWayBillWindowCommand { get; }
        public DelegateCommand ShowFuelStateWindowCommand { get; }
        public DelegateCommand ShowGuideWindowCommand { get; }
        public DelegateCommand AcceptBeforeChargingCommand { get; }
        public DelegateCommand StartChargingCommand { get; }
        public DelegateCommand GetFuelMarkBeforeLoadingCommand { get; }
        public DelegateCommand ShowDriverHelperWindowCommand { get; }
        public DelegateCommand ShowCheckCommand { get; }
        public DelegateCommand<string> ShowOutCheckPrepareWindowCommand { get; }
        public DelegateCommand<string> ShowInCheckPrepareWindowCommand { get; }
        public DelegateCommand<string> ShowStateReportPrepareWindowCommand { get; }
        public DelegateCommand ShowWayBillReportWindowCommand { get; }
        public DelegateCommand ShowSettingWindowCommand { get; }

        private void AcceptBeforeCharging()
        {
            if (FuelInTank > FuelLimit && isReady)
            {
                IsAccepted = true;
                RaisePropertyChanged(nameof(IsAccepted));
            }
            else
                ShowMessageWindow("Ошибка", "Заполните данные или проверьте остаток топлива.", MessageEnums.Error);
        }

        private void StartCharging()
        {
            chargingDispatcher.Start();
            IsCharging = true;
            RaisePropertyChanged(nameof(IsCharging));
        }

        private void ChargingDispatcherTick(object sender, EventArgs e)
        {
            try
            {
                if (FuelInTank != 0)
                {
                    FuelCharged += 5;
                    FuelInTank -= 5;
                    if (FuelCharged == FuelLimit)
                    {
                        chargingDispatcher.Stop();
                        ShowMessageWindow("Сообщение", "Заправлено!", MessageEnums.Success);
                        IsAccepted = false;
                        IsCharging = false;
                        RaisePropertyChanged(nameof(IsCharging));
                        RaisePropertyChanged(nameof(IsAccepted));
                        using (var context = new FuelContext())
                        {
                            using (var trans = context.Database.BeginTransaction())
                            {
                                try
                                {
                                    var temp = context.FuelInTanks.Where(x => x.FuelId == fuelId)
                                        .OrderByDescending(y => y.Id)
                                        .FirstOrDefault();
                                    context.FuelInTanks.Add(new Models.FuelInTank()
                                    {
                                        Quantity = FuelInTank,
                                        CerrentDate = DateTime.Now,
                                        FuelId = fuelId,
                                        ArrivingDate = null,
                                        ArrivingQuantity = temp.ArrivingQuantity
                                    });
                                    context.SaveChanges();

                                    var wayBills = context.WayBills.Where(x => x.Id == wayBillId).FirstOrDefault();
                                    wayBills.IsRegistered = true;
                                    context.SaveChanges();

                                    var price = repository.Fuels.Where(x => x.Id == fuelId).FirstOrDefault().Price;
                                    context.Charges.Add(new Charge()
                                    {
                                        ChargeDate = DateTime.Now,
                                        Quantity = FuelLimit,
                                        TotalPrice = price * (decimal)FuelLimit,
                                        WaybillId = wayBillId
                                    });
                                    context.SaveChanges();
                                    trans.Commit();
                                }
                                catch (Exception ex) { ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error); ClearDatas(); trans.Rollback(); }
                            }
                        }
                        ClearDatas();
                        isReady = false;
                        IsCheckReady = true;
                        RaisePropertyChanged(nameof(IsCheckReady));
                    }
                }
            }
            catch (Exception ex) { ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error); ClearDatas(); }
        }

        int wbId = 0;
        public Action<ChargeDataModel> ChargeAction { get; set; }
        private void GetChargeInfo(ChargeDataModel chargeData)
        {
            try
            {
                Transport = chargeData.Transport;
                TransportNumber = chargeData.TransportNamber;
                DriverName = chargeData.Driver;
                FuelLimit = chargeData.FuelForCharge;
                FuelMark = chargeData.FuelMark;
                ServiceNumber = chargeData.ServiceNamber.ToString();
                DepartmentDate = chargeData.DepartmentDate;
                DepartmentPlace = chargeData.DepartmentPlace;
                wayBillId = chargeData.WayBillId;
                wbId = chargeData.WayBillId;
                fuelId = repository.Fuels.Where(x => x.FuelMark == FuelMark).FirstOrDefault().Id;
                if (repository.FuelInTanks.Count() > 0)
                {
                    FuelInTank = (float)repository.FuelInTanks.Where(x => x.FuelId == fuelId)
                        .OrderByDescending(y => y.Id)
                        .FirstOrDefault().Quantity;
                    isReady = true;
                }
                helperWindow.Close();
            }
            catch (Exception ex) { ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error); }
        }


        private void CurrentDispathcerTick(object sender, EventArgs e)
        {
            StartLoadingAndChart();
        }

        private void RunLoadingDispatcher()
        {
            CurrentWeight = 0;
            if (FuelToFill > 0 && !string.IsNullOrEmpty(FuelMark))
                loadingDispatcher.Start();
            else
                ShowMessageWindow("Предупреждение", "Резервуар полон или отсутствуют данные.", MessageEnums.Warning);
        }


        private void StartLoadingAndChart()
        {
            CurrentWeight += 5;
            Quantity += 5;
            try
            {
                if (Quantity == MaxQuantity)
                {
                    
                    loadingDispatcher.Stop();
                    using (var context = new FuelContext())
                    {
                        context.FuelInTanks.Add(new Models.FuelInTank()
                        {
                            Quantity = Quantity,
                            CerrentDate = DateTime.Now,
                            FuelId = fuelId,
                            ArrivingQuantity = FuelToFill,
                            ArrivingDate = DateTime.Now
                        });
                        context.SaveChanges();
                        ShowMessageWindow("Сообщение", "Резервуар заполнен.", MessageEnums.Success);
                    }
                    Quantity = 0; FuelMark = ""; CurrentWeight = 0; FuelToFill = 0;
                }

                Task.Run(() =>
                {
                    YSeries[0].Values.Add(new ObservableValue(CurrentWeight));
                    RaisePropertyChanged(nameof(YSeries));
                    SetXStep();
                });
            }
            catch (Exception ex) { ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error); }
        }

        
        
        private void GetFuelMarkBeforeLoading()
        {
            try
            {
                FuelToFill = 0;
                Quantity = 0;
                using (var context = new FuelContext())
                {
                    fuelId = context.Fuels.Where(x => x.FuelMark == FuelMark).FirstOrDefault().Id;
                    MaxQuantity = (float)context.Fuels.Where(x => x.Id == fuelId).FirstOrDefault().MaxFuelValue;
                    Quantity = (float)context.FuelInTanks.Where(x => x.FuelId == fuelId)
                        .OrderByDescending(y => y.Id)
                        .FirstOrDefault().Quantity;
                    FuelToFill = MaxQuantity - Quantity;
                }
            }
            catch (Exception ex) { /*ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error);*/ }
        }

        private void GetChargeTransportView()
        {
            LoadView = 0;
            ClearDatas();
            RaisePropertyChanged(nameof(LoadView));
        }

        private void GetFillTanksView()
        {
            LoadView = 1;
            FuelMark = "";
            RaisePropertyChanged(nameof(LoadView));
            FuelMarks = new List<string>();
            if (repository.Fuels.Count() > 0)
                foreach (var t in repository.Fuels)
                    FuelMarks.Add(t.FuelMark);
            RaisePropertyChanged(nameof(FuelMarks));

        }

        
        Report report; 
        private void ShowCheck()
        {
            string serverName;
            using (var context = new FuelContext())
            {
                if (context.Settings.Count() > 0)
                    serverName = context.Settings.FirstOrDefault().ServerName;
                else
                {
                    ShowMessageWindow("Предупреждение", "Нет имени сервера", MessageEnums.Warning);
                    return;
                }
            }
            report = new FuelCheck();
            string connection = @"data source=" + serverName + ";initial catalog=FuelStationDb;integrated security=True;MultipleActiveResultSets=True;";
            
            var queryParameters = report.Dictionary.Connections[0].Tables[0].Parameters;
            report.SetParameterValue("ConnectString", connection);
            ReportHelper.TrySetCommandParam(queryParameters, "billId", wbId);
            using (var rp = new ReportForm("Чек о заправке", report))
            {
                rp.ShowDialog();
            }
            IsCheckReady = false;
            RaisePropertyChanged(nameof(IsCheckReady));
        }

        public string CheckVar { get; set; }
        private void ShowOutCheckPrepareWindow(string s)
        {
            CheckVar = "1";
            container.RegisterInstance<IMessageSender>(messageSender);
            container.RegisterInstance<IRepository>(repository);
            container.RegisterInstance<ViewMain>(this);
            fuelCheckWindow = container.Resolve<FuelCheckPrepareWindow>();
            fuelCheckWindow.ShowDialog();
        }

        private void ShowInCheckPrepareWindow(string s)
        {
            CheckVar = "0";
            container.RegisterInstance<IMessageSender>(messageSender);
            container.RegisterInstance<IRepository>(repository);
            container.RegisterInstance<ViewMain>(this);
            fuelCheckWindow = container.Resolve<FuelCheckPrepareWindow>();
            fuelCheckWindow.ShowDialog();
        }

        private void ShowStateReportPrepareWindow(string s)
        {
            CheckVar = "2";
            container.RegisterInstance<IMessageSender>(messageSender);
            container.RegisterInstance<IRepository>(repository);
            container.RegisterInstance<ViewMain>(this);
            fuelCheckWindow = container.Resolve<FuelCheckPrepareWindow>();
            fuelCheckWindow.ShowDialog();
        }

        private void ShowWayBillReportWindow()
        {
            container.RegisterInstance<IMessageSender>(messageSender);
            container.RegisterInstance<IRepository>(repository);
            container.RegisterInstance<ViewMain>(this);
            reportWindow = container.Resolve<WayReportWindow>();
            reportWindow.ShowDialog();
        }

        private void ShowSettingWindow()
        {
            container.RegisterInstance<IMessageSender>(messageSender);
            container.RegisterInstance<IRepository>(repository);
            container.RegisterInstance<ViewMain>(this);
            settingWindow = container.Resolve<SettingWindow>();
            settingWindow.ShowDialog();
        }

        private void SetXStep()
        {
            Task.Run(() =>
            {
                XPoints += 80;
            });
        }

        private void CreateStartSeries()
        {
            currentWeight = 0.00;
            tankWeight = 5000;
            YSeries = new SeriesCollection
                {
                    new LineSeries
                    {
                        Values = new ChartValues<ObservableValue>()
                        {
                           new ObservableValue(10),
                           new ObservableValue(7),
                           new ObservableValue(12),
                           new ObservableValue(4)
                        }
                    }
                };
        }

        private void ShowDriverHelperWindow()
        {
            container.RegisterInstance<IMessageSender>(messageSender);
            container.RegisterInstance<IRepository>(repository);
            container.RegisterInstance<ViewMain>(this);
            helperWindow = container.Resolve<DriverTransportWindow>();
            helperWindow.ShowDialog();
        }

        private void ShowFuelWindow()
        {
            container.RegisterInstance<IMessageSender>(messageSender);
            container.RegisterInstance<IRepository>(repository);
            fuelWindow = container.Resolve<FuelWindow>();
            fuelWindow.ShowDialog();
        }

        private void ShowTransportWindow()
        {

            container.RegisterInstance<IMessageSender>(messageSender);
            container.RegisterInstance<IRepository>(repository);
            transportWindow = container.Resolve<TransportWindow>();
            transportWindow.ShowDialog();
        }

        private void ShowDriverWindow()
        {
            IsGuideLoaded = true;
            container.RegisterInstance<IMessageSender>(messageSender);
            container.RegisterInstance<IRepository>(repository);
            container.RegisterInstance<ViewMain>(this);
            driverWindow = container.Resolve<DriverWindow>();
            driverWindow.ShowDialog();
        }

        private void ShowGuideWindow()
        {
            IsGuideLoaded = false;
            container.RegisterInstance<IMessageSender>(messageSender);
            container.RegisterInstance<IRepository>(repository);
            container.RegisterInstance<ViewMain>(this);
            driverWindow = container.Resolve<DriverWindow>();
            driverWindow.ShowDialog();
        }

        private void ShowWayBillWindow()
        {
            container.RegisterInstance<IMessageSender>(messageSender);
            container.RegisterInstance<IRepository>(repository);
            billWindow = container.Resolve<WayBillWindow>();
            billWindow.ShowDialog();
        }

        private void ShowFuelStateWindow()
        {
            container.RegisterInstance<IMessageSender>(messageSender);
            container.RegisterInstance<IRepository>(repository);
            stateWindow = container.Resolve<FuelStateWindow>();
            stateWindow.ShowDialog();
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

        private void ClearDatas()
        {
            ServiceNumber = FuelMark = Transport = TransportNumber = DriverName = DepartmentPlace = "";
            Quantity = 0; FuelInTank = 0; FuelCharged = 0;
        }
    }
}
