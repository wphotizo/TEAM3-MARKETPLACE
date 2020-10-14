using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPlace_DAL;

namespace MarketPlace_Services.ViewModelServices
{
    public class ProductProductDetailVM
    {
        public int Product_Detail_ID { get; set; }
        public string ModelName { get; set; }
        public Nullable<int> ManufacturerID { get; set; }
        public string Fan_Speed_Min { get; set; }
        public string Power_Min { get; set; }
        public string Color { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string Series { get; set; }
        public string Model_Year { get; set; }
        public string Application { get; set; }
        public string Airflow { get; set; }
        public string Operating_Voltage_Min { get; set; }
        public string Accessories { get; set; }
        public string Fan_Sweep_Diameter { get; set; }
        public string Sound_Max_Speed { get; set; }
        public string Picture { get; set; }
        public string Power_Max { get; set; }
        public string Operating_Voltage_Max { get; set; }
        public string Fan_Speed_Max { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string Mounting_Location { get; set; }
    }
}
