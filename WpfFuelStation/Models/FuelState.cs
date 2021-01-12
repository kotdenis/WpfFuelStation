namespace WpfFuelStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FuelState")]
    public partial class FuelState
    {
        public int Id { get; set; }

        public float Temperature { get; set; }

        public float Pressure { get; set; }

        public int FuelId { get; set; }

        public DateTime CheckingDate { get; set; }

        public bool IsChecked { get; set; }

        public virtual Fuel Fuel { get; set; }
    }
}
