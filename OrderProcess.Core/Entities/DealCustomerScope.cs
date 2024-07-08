using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Entities
{
    public class DealCustomerScope
    {

        public Guid Id { get; set; }

        public int DealCode { get; set; }

        public string DealDesc { get; set; }
        [NotMapped]
        public List<CustomerScope> CustomerScope { get; set; }

        public string CustomerScopeJson { get; set; }
    }

    public class CustomerScope
    {
        public string CustKey { get; set; }

        public string CustName   {get; set;}

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public Avail CanAvail { get; set; }
    }

    public enum Avail
    {
        False,
        True,
    }
}
