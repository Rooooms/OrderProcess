using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Entities
{
    public class Products
    {
        public Guid Id { get; set; }

        public int prodno { get; set; }

        public string proddesc { get; set; }

        public double unitcost { get; set; }

        public int catcode { get; set; }

        public string category { get; set; }

        public double basePrice { get; set; }

        public DateOnly basePriceEffDate { get; set; }
        public double TaxRate { get; set; } = 0.12;

        public double pricewtax { get; set; }
    }
}
