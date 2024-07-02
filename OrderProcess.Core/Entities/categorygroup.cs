using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Entities
{
    public class categorygroup
    {
        public Guid Id { get; set; }

        public int groupno { get; set; }

        public string groupdesc { get; set; }
    }
}
