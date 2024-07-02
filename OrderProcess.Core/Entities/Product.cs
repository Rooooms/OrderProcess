using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Entities
{

    //For testing ginagamit ni laurence
    public class Product
    {
        public Guid Id { get; set; }

        public int ProdNo { get; set; }

        public string ProdDescription { get; set; }

        public string Packing {  get; set; }

        public double? OrderCS { get; set; }
        public double? OrderPC { get; set; }
        public double BasePrice { get; set; }

    }
}
