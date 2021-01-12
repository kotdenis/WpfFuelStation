namespace WpfFuelStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fuel")]
    public partial class Fuel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fuel()
        {
            FuelInTanks = new HashSet<FuelInTank>();
            FuelStates = new HashSet<FuelState>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FuelMark { get; set; }

        public decimal Price { get; set; }

        public float MaxFuelValue { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FuelInTank> FuelInTanks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FuelState> FuelStates { get; set; }
    }
}
