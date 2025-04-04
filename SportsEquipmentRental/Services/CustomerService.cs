using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<List<CustomerViewModel>> GetAllCustomersAsync(int pageNumber, int pageSize)
    {
        var customers = await _customerRepository
            .GetAllAsync()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return customers.Select(c => new CustomerViewModel
        {
            CustomerID = c.CustomerID,
            FirstName = c.FirstName,
            LastName = c.LastName,
            Email = c.Email,
            Phone = c.Phone
        }).ToList();
    }

    public async Task<CustomerViewModel> GetCustomerByIdAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer == null)
            return null;

        return new CustomerViewModel
        {
            CustomerID = customer.CustomerID,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            Phone = customer.Phone
        };
    }

    public async Task AddCustomerAsync(CustomerViewModel customerViewModel)
    {
        var customer = new Customer
        {
            FirstName = customerViewModel.FirstName,
            LastName = customerViewModel.LastName,
            Email = customerViewModel.Email,
            Phone = customerViewModel.Phone
        };

        await _customerRepository.AddAsync(customer);
    }

    public async Task UpdateCustomerAsync(CustomerViewModel customerViewModel)
    {
        var customer = await _customerRepository.GetByIdAsync(customerViewModel.CustomerID);
        if (customer == null)
            return;

        customer.FirstName = customerViewModel.FirstName;
        customer.LastName = customerViewModel.LastName;
        customer.Email = customerViewModel.Email;
        customer.Phone = customerViewModel.Phone;

        await _customerRepository.UpdateAsync(customer);
    }

    public async Task DeleteCustomerAsync(int id)
    {
        await _customerRepository.DeleteAsync(id);
    }
}
