using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }

        public int CustKey { get; set; }

        public string CustName { get; set; }
    }
}
