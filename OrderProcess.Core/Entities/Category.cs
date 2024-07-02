using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Entities
{
    public class Category
    {
        public Guid Id { get; set; }

        public int CategoryCode { get; set; }

        public string CategoryName { get; set; }    

        public int groupno { get; set; }
    }
}
