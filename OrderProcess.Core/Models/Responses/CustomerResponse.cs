using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Models.Responses
{
    public class CustomerResponse
    {
        public Guid Id { get; set; }

        public string CustKey { get; set; }

        public string CustName { get; set; }

        public string ChainCode { get; set; }

        public string DeliveryAddress { get; set; }

        public string Whseno { get; set; }
        public int salesman { get; set; }

        public string Term { get; set; }

        public string HardTerm { get; set; }

        public string CreditLimit { get; set; }

        public string HardLimit { get; set; }
    }
}
