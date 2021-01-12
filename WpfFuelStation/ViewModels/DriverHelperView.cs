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
    public class DriverHelperView : BindableBase
    {
        IMessageSender messageSender;
        IRepository repository;
        MessageWindow messageWindow;
        UnityContainer container;
        ViewMain viewMain;

        public DriverHelperView(IMessageSender messageSender, IRepository repository, ViewMain viewMain)
        {
            this.messageSender = messageSender;
            this.repository = repository;
            container = new UnityContainer();
            this.viewMain = viewMain;

            GetDriverTransportDatas();
            GetCurrentRowCommand = new DelegateCommand(() => GetCurrentRow());
            GetChargeInfoCommand = new DelegateCommand(() => GetChargeInfo());
        }

        public DelegateCommand GetCurrentRowCommand { get; }
        public DelegateCommand GetChargeInfoCommand { get; }

        public List<ChargeDataModel> ChargeDataModels { get; set; }
        public int CurrentId { get; set; }
        public bool IsReady { get; set; }
        
        private void GetDriverTransportDatas()
        {
            try
            {
                ChargeDataModels = new List<ChargeDataModel>();
                using (var context = new FuelContext())
                {
                    ChargeDataModels = (from wayBill in context.WayBills
                                        join driverTransport in context.DriverTransports on wayBill.Id equals driverTransport.WayBillId
                                        join drivers in context.Drivers on driverTransport.DriverId equals drivers.Id
                                        join transport in context.TransportVehicles on driverTransport.TransportId equals transport.Id
                                        join fuels in context.Fuels on driverTransport.FuelId equals fuels.Id

                                        where wayBill.IsRegistered != true

                                        select new ChargeDataModel
                                        {
                                            DepartmentDate = wayBill.DepartmentDate,
                                            DepartmentPlace = wayBill.DepartmentPlace,
                                            Driver = drivers.Surname + " " + drivers.Name + " " +drivers.MiddleName,
                                            FuelForCharge = wayBill.FuelLimit,
                                            FuelMark = fuels.FuelMark,
                                            Price = fuels.Price,
                                            ServiceNamber = drivers.ServiceNumber,
                                            Transport = transport.Transport,
                                            TransportNamber = transport.TransportNumber,
                                            WayBillId = wayBill.Id,
                                            WayBillNumber = wayBill.WayBillNumber
                                        }).ToList();
                    
                }
                RaisePropertyChanged(nameof(ChargeDataModels));
            }
            catch (Exception ex) { ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error); }
        }

        ChargeDataModel dataModel;
        private void GetCurrentRow()
        {
            RaisePropertyChanged(nameof(CurrentId));
            if (ChargeDataModels.Count > 0)
            {
                dataModel = new ChargeDataModel();
                var id = ChargeDataModels[CurrentId].WayBillId;
                dataModel = ChargeDataModels.Where(x => x.WayBillId == id).FirstOrDefault();
                IsReady = true;
                RaisePropertyChanged(nameof(IsReady));
            }
        }

        private void GetChargeInfo()
        {
            try
            {
                if (dataModel != null)
                    viewMain.ChargeAction.Invoke(dataModel);
                else
                    ShowMessageWindow("Предупреждение", "Нет данных", MessageEnums.Warning);
            }
            catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.ToString()); }
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
