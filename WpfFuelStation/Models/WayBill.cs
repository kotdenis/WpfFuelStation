namespace WpfFuelStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WayBill")]
    public partial class WayBill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WayBill()
        {
            Charges = new HashSet<Charge>();
            DriverTransports = new HashSet<DriverTransport>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string WayBillNumber { get; set; }

        public DateTime DepartmentDate { get; set; }

        [StringLength(150)]
        public string DepartmentPlace { get; set; }

        public float FuelLimit { get; set; }

        public bool IsRegistered { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Charge> Charges { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DriverTransport> DriverTransports { get; set; }
    }
}
