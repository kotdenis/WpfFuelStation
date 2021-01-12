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
    public class DriverBillHelperView : BindableBase
    {
        IMessageSender messageSender;
        IRepository repository;
        MessageWindow messageWindow;
        UnityContainer container;
        WayBillView billView;

        public DriverBillHelperView(IMessageSender messageSender, IRepository repository, WayBillView billView)
        {
            this.messageSender = messageSender;
            this.repository = repository;
            container = new UnityContainer();
            this.billView = billView;

            GetDatas();
            GetHelperRowIdCommand = new DelegateCommand(() => GetHelperRowId());
            DriverDemoCommand = new DelegateCommand<string>((s) => DriverDemo(s));
        }

        public DelegateCommand GetHelperRowIdCommand { get; }
        public DelegateCommand<string> DriverDemoCommand { get; }

        public List<DriverDataModels> DriverDataHelperModels { get; set; }

        string name;
        public string Name
        {
            get => name;
            set { name = value; RaisePropertyChanged(nameof(Name)); }
        }

        string surName;
        public string Surname
        {
            get => surName;
            set { surName = value; RaisePropertyChanged(nameof(Surname)); }
        }

        string middleName;
        public string MiddleName
        {
            get => middleName;
            set { middleName = value; RaisePropertyChanged(nameof(MiddleName)); }
        }

        private void GetDatas()
        {
            try
            {
                DriverDataHelperModels = new List<DriverDataModels>();
                foreach(var t in repository.Drivers)
                {
                    DriverDataHelperModels.Add(new DriverDataModels()
                    {
                        Surname = t.Surname,
                        Name = t.Name,
                        MiddleName = t.MiddleName,
                        DriverId = t.Id
                    });
                }
            }
            catch (Exception ex) { ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error); }
        }

        public int HelperId { get; set; }
        private void GetHelperRowId()
        {
            RaisePropertyChanged(nameof(HelperId));
            var id = DriverDataHelperModels[HelperId].DriverId;
            var temp = DriverDataHelperModels.Where(x => x.DriverId == id).FirstOrDefault();
            Name = temp.Name;
            Surname = temp.Surname;
            MiddleName = temp.MiddleName; 
        }

        private void DriverDemo(string s)
        {
            string fullName = Surname + " " + Name + " " + MiddleName;
            billView.DriverAction.Invoke(fullName);
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
