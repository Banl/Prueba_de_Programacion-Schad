using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DbContext;

namespace DAL.Implemention
{
    public class TypeCustomerRepository : ICustomerType
    {
        private readonly DataContext _context;

        public TypeCustomerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(CustomerType entity)
        {
            _context.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(CustomerType entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EditAsync(CustomerType entity)
        {
            _context.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<CustomerType>> GetAllAsync()
        {
            return await _context.CustomerTypes.ToListAsync();
        }

        public async Task<CustomerType> GetByIdAsync(int id)
        {
            return await _context.CustomerTypes.SingleAsync(c => c.Id == id);
        }
    }
}
