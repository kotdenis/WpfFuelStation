using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfFuelStation.Models.DataModels
{
    public class  FuelStateDataModels
    {
        public int Id { get; set; }
        public float Temperature { get; set; }
        public float Pressure { get; set; }
        public string FuelMark { get; set; }
        public DateTime CheckingDate { get; set; }
        public float Quantity { get; set; }
        public float MaxQuantity { get; set; }
        public bool IsChecked { get; set; }
    }
}
