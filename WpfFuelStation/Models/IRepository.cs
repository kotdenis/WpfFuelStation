using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfFuelStation.Models
{
    public interface IRepository
    {
        IEnumerable<Charge> Charges { get; }
        IEnumerable<Fuel> Fuels { get; }
        IEnumerable<WayBill> WayBills { get; }
        IEnumerable<TransportVehicle> TransportVehicles { get; }
        IEnumerable<Driver> Drivers { get; }
        IEnumerable<FuelState> FuelStates { get; }
        IEnumerable<DriverTransport> DriverTransports { get; }
        IEnumerable<FuelInTank> FuelInTanks { get;  }
    }

    public class Repository : IRepository
    {
        private FuelContext context;

        public Repository(FuelContext context)
        {
            this.context = context;
        }

        public IEnumerable<Charge> Charges => context.Charges;
        public IEnumerable<FuelInTank> FuelInTanks => context.FuelInTanks;
        public IEnumerable<Fuel> Fuels => context.Fuels;
        public IEnumerable<WayBill> WayBills => context.WayBills;
        public IEnumerable<TransportVehicle> TransportVehicles => context.TransportVehicles;
        public IEnumerable<Driver> Drivers => context.Drivers;
        public IEnumerable<FuelState> FuelStates => context.FuelStates;
        public IEnumerable<DriverTransport> DriverTransports => context.DriverTransports;
    }
}
