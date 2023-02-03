using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);
        Task<bool> EditAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
    public interface ICustomerType : IRepository<CustomerType> { }
    public interface ICustomer : IRepository<Customer> { }
    public interface IInvoice : IRepository<Invoice> { }
}
