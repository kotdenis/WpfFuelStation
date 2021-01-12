namespace WpfFuelStation.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FuelContext : DbContext
    {
        public FuelContext()
            : base("name=FuelContext")
        {
        }

        public virtual DbSet<Charge> Charges { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<DriverTransport> DriverTransports { get; set; }
        public virtual DbSet<Fuel> Fuels { get; set; }
        public virtual DbSet<FuelInTank> FuelInTanks { get; set; }
        public virtual DbSet<FuelState> FuelStates { get; set; }
        public virtual DbSet<TransportVehicle> TransportVehicles { get; set; }
        public virtual DbSet<WayBill> WayBills { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Charge>()
                .Property(e => e.TotalPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Fuel>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Fuel>()
                .HasMany(e => e.FuelStates)
                .WithRequired(e => e.Fuel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WayBill>()
                .HasMany(e => e.Charges)
                .WithRequired(e => e.WayBill)
                .WillCascadeOnDelete(false);
        }
    }
}
