using OrderProcess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Models.Responses
{
    public class OrderResponse
    {
        public Guid Id { get; set; }

        public int CustKey { get; set; }

        public string CustName { get; set; }

        public int poNo { get; set; }

        public DateOnly poDate { get; set; }

        public string Remarks { get; set; }

        public int[] ProdNo { get; set; }

        public string ProdDescription { get; set; }

        public string Packing { get; set; }

        public double OrderCS { get; set; }


        public Product Products { get; set; }

        public Guid ProductId { get; set; }

        public Customer customer { get; set; }

        public Guid CustomerId { get; set; }
    }
}
