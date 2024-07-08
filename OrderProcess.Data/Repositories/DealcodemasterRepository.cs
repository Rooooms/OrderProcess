using Microsoft.EntityFrameworkCore;
using OrderProcess.Core.Entities;
using OrderProcess.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Data.Repositories
{
    public class DealcodemasterRepository : IDealcodeMasterRepository
    {
        private readonly AppDbContext _context;

        public DealcodemasterRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<DealcodeMaster> GetByDealDesc(string dealdesc)
        {
            return _context.Set<DealcodeMaster>().FirstOrDefaultAsync(p=>p.dldesc == dealdesc);
        }
        public Task<DealcodeMaster> GetByDealType(int dealType)
        {
            return _context.Set<DealcodeMaster>().FirstOrDefaultAsync(p => p.dltype == dealType);
        }


    }
}
