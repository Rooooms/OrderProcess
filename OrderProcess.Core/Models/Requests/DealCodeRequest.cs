using OrderProcess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Models.Requests
{
    public class DealCodeRequest
    {
        public int Dealcode { get; set; }

        public string DealDesc { get; set; }

        public int whseno { get; set; }

        public string branch { get; set; }

        public DateOnly DealStart { get; set; }

        public DateOnly DealEnd { get; set; }

        public double rate { get; set; }

        public double Amount { get; set; }

        public int freegoods { get; set; }

        public int minimumQty { get; set; }

    }
}
