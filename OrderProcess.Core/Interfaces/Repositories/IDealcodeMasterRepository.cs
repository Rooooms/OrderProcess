using OrderProcess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Interfaces.Repositories
{
    public interface IDealcodeMasterRepository
    {
        Task<DealcodeMaster> GetByDealDesc(string dealdesc);
        Task<DealcodeMaster> GetByDealType(int dealType);
    }
}
