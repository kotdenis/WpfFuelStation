using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using WpfFuelStation.Infrastructure;
using WpfFuelStation.Models;
using WpfFuelStation.Enums;
using Unity;

namespace WpfFuelStation.ViewModels
{
    public class FuelView : BindableBase
    {
        IMessageSender messageSender;
        IRepository repository;
        MessageWindow messageWindow;
        UnityContainer container;

        public FuelView(IMessageSender messageSender, IRepository repository)
        {
            this.messageSender = messageSender;
            this.repository = repository;
            container = new UnityContainer();
            GetFuels();

            GetCurrentRowIdCommand = new DelegateCommand(() => GetCurrentRowId());
            SaveFuelDatasCommand = new DelegateCommand(() => SaveFuelDatas());
            ChangeFuelDatasCommand = new DelegateCommand(() => ChangeFuelDatas());
            DeleteFuelCommand = new DelegateCommand(() => DeleteFuel());
        }

        public DelegateCommand GetCurrentRowIdCommand { get; }
        public DelegateCommand SaveFuelDatasCommand { get; }
        public DelegateCommand ChangeFuelDatasCommand { get; }
        public DelegateCommand DeleteFuelCommand { get; }

        public List<Fuel> Fuels { get; set; }
        public int FuelId { get; set; }

        string fuelMark;
        public string FuelMark
        {
            get => fuelMark;
            set { fuelMark = value; RaisePropertyChanged(nameof(FuelMark)); }
        }

        float maxQuantity;
        public float MaxQuantity
        {
            get => maxQuantity;
            set { maxQuantity = value; RaisePropertyChanged(nameof(MaxQuantity)); }
        }

        decimal price;
        public decimal Price
        {
            get => price;
            set { price = value; RaisePropertyChanged(nameof(Price)); }
        }

        private void GetFuels()
        {
            try
            {
                Fuels = new List<Fuel>();
                foreach (var t in repository.Fuels)
                {
                    var b = t.MaxFuelValue;
                    Fuels.Add(new Fuel()
                    {
                        Price = t.Price,
                        FuelMark = t.FuelMark,
                        Id = t.Id,
                        MaxFuelValue = t.MaxFuelValue
                    });
                }
                RaisePropertyChanged(nameof(Fuels));
            }
            catch (Exception ex) { ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error); }
        }

        private void GetFuelsAfterChange()
        {
            Fuels = new List<Fuel>();
            using (var context = new FuelContext())
            {
                foreach (var t in context.Fuels)
                {
                    Fuels.Add(new Fuel()
                    {
                        Price = t.Price,
                        FuelMark = t.FuelMark,
                        Id = t.Id,
                        MaxFuelValue = t.MaxFuelValue
                    });
                }
            }
            RaisePropertyChanged(nameof(Fuels));
        }

        private void GetCurrentRowId()
        {
            try
            {
                RaisePropertyChanged(nameof(FuelId));
                if (Fuels.Count > 0)
                {
                    int id = Fuels[FuelId].Id;
                    var temp = Fuels.Where(x => x.Id == id).FirstOrDefault();
                    FuelMark = temp.FuelMark;
                    Price = temp.Price;
                    MaxQuantity = temp.MaxFuelValue;
                }
            }
            catch(Exception ex) {  }
        }

        private void SaveFuelDatas()
        {
            try
            {
                using(var context = new FuelContext())
                {
                    using (var trans = context.Database.BeginTransaction())
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(FuelMark) && !repository.Fuels.Any(x => x.FuelMark == FuelMark))
                            {
                                context.Fuels.Add(new Fuel()
                                {
                                    FuelMark = FuelMark,
                                    Price = Price,
                                    MaxFuelValue = MaxQuantity
                                });
                                context.SaveChanges();
                                
                                var fuelId = context.Fuels.OrderByDescending(x => x.Id).FirstOrDefault().Id;
                                context.FuelInTanks.Add(new FuelInTank()
                                {
                                    ArrivingDate = DateTime.Now,
                                    CerrentDate = DateTime.Now,
                                    FuelId = fuelId,
                                    Quantity = MaxQuantity
                                });
                                context.SaveChanges();
                                trans.Commit();
                                ShowMessageWindow("Сообщение", "Данные сохранены", MessageEnums.Success);
                                FuelMark = "";
                                MaxQuantity = 0;
                                Price = 0;
                                GetFuels();
                            }
                            else
                                ShowMessageWindow("Сообщение", "Ошибка заполнения", MessageEnums.Error);
                        }
                        catch (Exception ex) { ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error); trans.Rollback(); }
                    }
                }
                
            }
            catch (Exception ex) { ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error); }
        }

        private void ChangeFuelDatas()
        {
            try
            {
                if(Fuels.Count > 0)
                {
                    int id = Fuels[FuelId].Id;
                    using(var context = new FuelContext())
                    {
                        var temp = context.Fuels.Where(x => x.Id == id).FirstOrDefault();
                        temp.FuelMark = FuelMark;
                        temp.Price = Price;
                        temp.MaxFuelValue = MaxQuantity;
                        context.SaveChanges();
                    }
                    ShowMessageWindow("Сообщение", "Данные редактированны.", MessageEnums.Success);
                    GetFuelsAfterChange();
                    FuelMark = "";
                    MaxQuantity = 0;
                    Price = 0;
                    
                }
            }
            catch (Exception ex) { ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error); }
        }

        private void DeleteFuel()
        {
            try
            {
                using (var context = new FuelContext())
                {
                    using(var trans = context.Database.BeginTransaction())
                    {
                        try
                        {
                            int id = Fuels[FuelId].Id;
                            if (context.FuelStates.Any(x => x.FuelId == id))
                                foreach (var t in context.FuelStates.Where(x => x.FuelId == id))
                                    context.FuelStates.Remove(t);
                            context.SaveChanges();
                            if (context.FuelInTanks.Any(x => x.FuelId == id))
                                foreach (var t in context.FuelInTanks.Where(x => x.FuelId == id))
                                    context.FuelInTanks.Remove(t);
                            context.SaveChanges();
                            var temp = context.Fuels.Where(x => x.Id == id).FirstOrDefault();
                            context.Fuels.Remove(temp);
                            context.SaveChanges();
                            trans.Commit();
                            ShowMessageWindow("Сообщение", "Удалено", MessageEnums.Success);
                            GetFuelsAfterChange();
                        }
                        catch (Exception ex) { ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error); trans.Rollback(); }
                    }
                }
            }
            catch (Exception ex) { ShowMessageWindow("Ошибка", ex.Message, MessageEnums.Error); }
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
