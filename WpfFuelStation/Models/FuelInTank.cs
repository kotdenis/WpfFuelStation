namespace WpfFuelStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FuelInTank")]
    public partial class FuelInTank
    {
        public int Id { get; set; }

        public float? Quantity { get; set; }

        public DateTime? CerrentDate { get; set; }

        public int? FuelId { get; set; }

        public float? ArrivingQuantity { get; set; }

        public DateTime? ArrivingDate { get; set; }

        public virtual Fuel Fuel { get; set; }
    }
}
