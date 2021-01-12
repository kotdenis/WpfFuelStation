using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using WpfFuelStation.Infrastructure;
using WpfFuelStation.Models;
using Prism.Commands;
using Prism.Mvvm;
using WpfFuelStation.Enums;
using FastReport;
using FastReport.Data;
using WpfFuelStation.Reports;
using System.Configuration;

namespace WpfFuelStation.ViewModels
{
    public class FuelCheckView : BindableBase
    {
        IMessageSender messageSender;
        IRepository repository;
        MessageWindow messageWindow;
        ViewMain viewMain;
        UnityContainer container;
        Report report;

        public FuelCheckView(IMessageSender messageSender, IRepository repository, ViewMain viewMain)
        {
            this.messageSender = messageSender;
            this.repository = repository;
            this.viewMain = viewMain;
            container = new UnityContainer();

            FuelMarks = new List<string>();
            foreach (var t in repository.Fuels)
                FuelMarks.Add(t.FuelMark);
            GetWayBillNumbers();
            FuelMark = "";
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            ShowFuelReportCommand = new DelegateCommand(() => ShowFuelReport());
            GetStartDateCommand = new DelegateCommand(() => GetStartDate());
            GetEndDateCommand = new DelegateCommand(() => GetEndDate());
            ShowWayBillReportCommand = new DelegateCommand(() => ShowWayBillReport());
            SaveServerNameCommand = new DelegateCommand(() => SaveServerName());
        }

        public DelegateCommand ShowFuelReportCommand { get; }
        public DelegateCommand GetStartDateCommand { get; }
        public DelegateCommand GetEndDateCommand { get; }
        public DelegateCommand ShowWayBillReportCommand { get; }
        public DelegateCommand SaveServerNameCommand { get; }

        public List<string> FuelMarks { get; set; }
        public List<string> WayBillNumbers { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        string fuelMark;
        public string FuelMark
        {
            get => fuelMark;
            set
            {
                fuelMark = value; RaisePropertyChanged(nameof(FuelMark));
            }
        }
        string billNumber;
        public string BillNumber
        {
            get => billNumber;
            set
            {
                billNumber = value; RaisePropertyChanged(nameof(BillNumber));
            }
        }

        string serverName;
        public string SqlServerName
        {
            get => serverName;
            set { serverName = value; RaisePropertyChanged(nameof(SqlServerName)); }
        }

        private void GetWayBillNumbers()
        {
            try
            {
                WayBillNumbers = new List<string>();
                using (var context = new FuelContext())
                {
                    var list = context.WayBills.Where(x => x.IsRegistered == false).ToList();
                    if (list.Count > 0)
                        foreach (var t in list)
                            WayBillNumbers.Add(t.WayBillNumber);
                }
                RaisePropertyChanged(nameof(WayBillNumbers));
            }
            catch (Exception ex) { ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error); }
        }

        private void ShowFuelReport()
        {
            try
            {
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
                if (!string.IsNullOrEmpty(FuelMark))
                {
                    var id = repository.Fuels.Where(x => x.FuelMark == FuelMark)
                        .FirstOrDefault().Id;
                    if (viewMain.CheckVar == "0")
                        report = new WasteReport();
                    if (viewMain.CheckVar == "1")
                        report = new OutComeCheck();
                    if (viewMain.CheckVar == "2")
                        report = new FuelStateReport();
                    var b = id;
                    string connection = @"data source=" + SqlServerName + ";initial catalog=FuelStationDb;integrated security=True;MultipleActiveResultSets=True;";
                    report.SetParameterValue("ConnectString", connection);
                    var queryParameters = report.Dictionary.Connections[0].Tables[0].Parameters;
                    ReportHelper.TrySetCommandParam(queryParameters, "StartDate", StartDate);
                    ReportHelper.TrySetCommandParam(queryParameters, "EndDate", EndDate);
                    ReportHelper.TrySetCommandParam(queryParameters, "IdFuel", id);
                    //report.SetParameterValue("ConnectString", connection);
                    report.SetParameterValue("DateStart", StartDate);
                    report.SetParameterValue("DateEnd", EndDate);
                    
                    using (var rp = new ReportForm("Отчет по топливу", report))
                    {
                        rp.ShowDialog();
                    }
                }
                else
                    ShowMessageWindow("Ошибка", "Выберите марку топлива", MessageEnums.Warning);
            }
            catch (Exception ex) { ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error); }
        }

        private void ShowWayBillReport()
        {
            if (!string.IsNullOrEmpty(BillNumber))
            {
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
                report = new WayBillReport();
                string connection = @"data source=" + serverName + ";initial catalog=FuelStationDb;integrated security=True;MultipleActiveResultSets=True;";
                report.SetParameterValue("ConnectString", connection);
                var queryParameters = report.Dictionary.Connections[0].Tables[0].Parameters;
                ReportHelper.TrySetCommandParam(queryParameters, "wayNumber", BillNumber);
                
                using (var rp = new ReportForm("Путевой лист", report))
                {
                    rp.ShowDialog();
                }
            }
            else
                ShowMessageWindow("Предупреждение", "Выберите номер путевого листа", MessageEnums.Warning);
        }

        private void SaveServerName()
        {
            using (var context = new FuelContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        var mb = context.Settings;
                        if (context.Settings.Count() > 0)
                        {
                            var temp = context.Settings.FirstOrDefault();
                            context.Settings.Remove(temp);
                            context.SaveChanges();
                        }
                        if (!string.IsNullOrEmpty(SqlServerName))
                        {
                            context.Settings.Add(new Setting()
                            {
                                ServerName = SqlServerName
                            });
                            context.SaveChanges();
                            ShowMessageWindow("Сообщение", "Сохранено!", MessageEnums.Success);
                        }
                        else
                            ShowMessageWindow("Предупреждение", "Введите имя сервера", MessageEnums.Warning);
                        trans.Commit();
                    }
                    catch (Exception ex) { ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error); }
                }
            }
        }

        private void GetStartDate()
        {
            RaisePropertyChanged(nameof(StartDate));
        }

        private void GetEndDate()
        {
            RaisePropertyChanged(nameof(EndDate));
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
