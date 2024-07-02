using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Models.Requests
{
    public class ProductsRequest
    {

        public int prodno { get; set; }
        public string proddesc { get; set; }

        public double unitcost { get; set; }

        public int catcode { get; set; }

        public double basePrice { get; set; }

        public DateOnly basePriceEffDate { get; set; }
 
    }
}
