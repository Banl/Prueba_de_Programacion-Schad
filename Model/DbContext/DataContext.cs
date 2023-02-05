using Microsoft.EntityFrameworkCore;

namespace Model.DbContext
{
    public class DataContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        #region Dbset
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerType> CustomerTypes { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceDeteil> InvoiceDeteils { get; set; }
        #endregion
    }
}
