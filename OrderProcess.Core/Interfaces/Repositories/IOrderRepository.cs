using OrderProcess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        void Add(List<OrderEntities> order);

        void Delete(OrderEntities order);

        Task<List<OrderEntities>> GetAll();

        Task<OrderEntities> GetById(Guid id);
        Task<List<OrderEntities>> GetBypoNo(int poNo);
        Task<int> SaveChangesAsync();
    }
}
