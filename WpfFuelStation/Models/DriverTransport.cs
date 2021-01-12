namespace WpfFuelStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DriverTransport")]
    public partial class DriverTransport
    {
        public int Id { get; set; }

        public int? TransportId { get; set; }

        public int? DriverId { get; set; }

        public int? FuelId { get; set; }

        public int? WayBillId { get; set; }

        public virtual WayBill WayBill { get; set; }
    }
}
