using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Entities
{
    public class DealProductScope
    {
        public Guid Id { get; set; }

        public int DealCode { get; set; }

        public string DealDesc { get; set; }
        [NotMapped]
        public List<ProductScope> ProductScope { get; set; }

        public string ProductScopeJson { get; set; }
    }

    public class ProductScope
    {
        public int prodno { get; set; }

        public string proddesc { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public Avail CanAvail { get; set; }
    }

}
