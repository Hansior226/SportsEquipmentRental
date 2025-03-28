using System.Collections.Generic;
using System.Threading.Tasks;
public interface ICustomerService
{
    Task<List<Customer>> GetAllCustomersAsync(int pageNumber, int pageSize);
    Task<Customer> GetCustomerByIdAsync(int id);
    Task AddCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(Customer customer);
    Task DeleteCustomerAsync(int id);
}
