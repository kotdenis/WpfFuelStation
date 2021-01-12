namespace WpfFuelStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Charge")]
    public partial class Charge
    {
        public int Id { get; set; }

        public int WaybillId { get; set; }

        public DateTime ChargeDate { get; set; }

        public float Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public virtual WayBill WayBill { get; set; }
    }
}
