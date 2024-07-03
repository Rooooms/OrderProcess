using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Entities
{
    public class DealCodes
    {
        public Guid Id { get; set; }

        public int Dealcode { get; set; }

        public string DealDesc { get; set; }

        public int whseno {  get; set; }

        public string branch { get; set; }

        public DateOnly DealStart {  get; set; }

        public DateOnly DealEnd { get; set; }

        public double rate { get; set; }

        public double Amount { get; set; }

        public int freegoods { get; set; }

        public int minimumQty { get; set; }

        public DealType dealType { get; set; }

        public string Status { get; set; }
    }

    public enum DealType
    {
        FixRate,
        FixAmount,
        FreeGoods
    }
}
