using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfFuelStation.Models.DataModels
{
    public class ChargeDataModel
    {
        public int WayBillId { get; set; }
        public string WayBillNumber { get; set; }
        public string Driver { get; set; }
        public string Transport { get; set; }
        public string TransportNamber { get; set; }
        public string DepartmentPlace { get; set; }
        public string FuelMark { get; set; }
        public int ServiceNamber { get; set; }
        public DateTime DepartmentDate { get; set; }
        public float FuelForCharge { get; set; }
        public decimal Price { get; set; }
    }
}
