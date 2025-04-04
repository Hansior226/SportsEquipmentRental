using System.Collections.Generic;
using System.Threading.Tasks;
public interface ICustomerService
{
    Task<List<CustomerViewModel>> GetAllCustomersAsync(int pageNumber, int pageSize);
    Task<CustomerViewModel> GetCustomerByIdAsync(int id);
    Task AddCustomerAsync(CustomerViewModel customer);
    Task UpdateCustomerAsync(CustomerViewModel customer);
    Task DeleteCustomerAsync(int id);
}