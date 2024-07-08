using OrderProcess.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Models.Responses
{
    public class CustomerScopeResponse
    {
        public Guid Id { get; set; }

        public int DealCode { get; set; }

        public string DealDesc { get; set; }
        public string CustomerScopeJson { get; set; }
    }
}
