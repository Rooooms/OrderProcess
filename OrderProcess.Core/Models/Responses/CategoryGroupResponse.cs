using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Models.Responses
{
    public class CategoryGroupResponse
    {
        public Guid Id { get; set; }

        public int groupno { get; set; }

        public string groupdesc { get; set; }   
    }
}
