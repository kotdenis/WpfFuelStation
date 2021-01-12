using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfFuelStation.Models
{
    [Table("Setting")]
    public partial class Setting
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string ServerName { get; set; }
    }
}
