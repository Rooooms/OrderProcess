using OrderProcess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Models.Requests
{
    public class ProductScopeRequest
    {
        public int DealCode { get; set; }
        public List<ProductProfileRequest> productprofile { get; set; }

    }

    public class ProductProfileRequest
    {
        public int prodno { get; set; }
        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public Avail CanAvail { get; set; }
    }
}

