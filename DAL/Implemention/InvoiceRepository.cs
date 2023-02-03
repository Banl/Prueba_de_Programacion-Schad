using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implemention
{
    public class InvoiceRepository : IInvoice
    {
        private readonly DataContext _context;

        public InvoiceRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddAsync(Invoice entity)
        {
            _context.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Invoice entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EditAsync(Invoice entity)
        {
            _context.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            return await _context.Invoices.
                Include(c => c.Customer).
                Include(c => c.InvoiceDeteils).
                ToListAsync();
        }

        public async Task<Invoice> GetByIdAsync(int id)
        {
            return await _context.Invoices.
                Include(c => c.Customer).
                Include(c => c.InvoiceDeteils).
                SingleAsync(c => c.Id == id);
        }
    }
}
