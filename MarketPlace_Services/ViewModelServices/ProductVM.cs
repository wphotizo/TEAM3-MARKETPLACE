using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace_Services.ViewModelServices
{
    public class ProductVM
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string Picture { get; set; }

    }
}
