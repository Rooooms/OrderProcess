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
    public class OrderRepository:IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context)
        {

            _context = context; 

        }

        public void Add(List<OrderEntities> order)
        {
            _context.Orders.AddRangeAsync(order);
        }

        public void Delete(OrderEntities order)
        {
            _context.Orders.Remove(order);
        }

        public Task<List<OrderEntities>> GetAll()
        {
            return _context.Orders.OrderByDescending(p=>p.poDate).ToListAsync();
        }

        public Task<OrderEntities> GetById(Guid id)
        {
            return _context.Orders.FirstOrDefaultAsync(p=>p.Id == id);
        }

        public Task<List<OrderEntities>>GetBypoNo(int poNo)
        {
            return _context.Orders.Where(p=>p.poNo == poNo).OrderByDescending(p=>p.poDate).ToListAsync();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
