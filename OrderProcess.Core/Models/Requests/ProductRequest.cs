﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Models.Requests
{
    public class ProductRequest
    {
        public int ProdNo { get; set; }

        public string ProdDescription { get; set; }

        public string Packing { get; set; }

        public double OrderCS { get; set; }
        public double OrderPC { get; set; }
        public double BasePrice { get; set; }
    }
}
