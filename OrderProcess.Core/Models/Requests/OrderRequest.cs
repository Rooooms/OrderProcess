﻿using OrderProcess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Models.Requests
{
    public class OrderRequest
    { 
        public string CustKey { get; set; }

        public string CustName { get; set; }

        public int poNo { get; set; }

        public DateOnly poDate { get; set; }

        public double?[] OrderCS {get; set; }

        public string Remarks { get; set; }

        public int[] ProdNo { get; set; }

        public double[] basePrice { get; set; }

        public double[] price { get; set; }



    }
}
