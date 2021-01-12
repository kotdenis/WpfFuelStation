namespace WpfFuelStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TransportVehicle")]
    public partial class TransportVehicle
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Transport { get; set; }

        [Required]
        [StringLength(50)]
        public string TransportNumber { get; set; }
    }
}
