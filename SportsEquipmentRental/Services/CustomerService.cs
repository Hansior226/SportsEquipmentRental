using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<CustomerViewModel> GetCustomerByIdAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        return customer == null ? null : _mapper.Map<CustomerViewModel>(customer);
    }

    public async Task<List<CustomerViewModel>> GetAllCustomersAsync(int pageNumber, int pageSize)
    {
        var customers = await _customerRepository.GetAllAsync();
        var pagedCustomers = customers
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        return _mapper.Map<List<CustomerViewModel>>(pagedCustomers);
    }

    public async Task AddCustomerAsync(CustomerViewModel model)
    {
        var customer = _mapper.Map<Customer>(model);
        await _customerRepository.AddAsync(customer);
    }

    public async Task UpdateCustomerAsync(CustomerViewModel model)
    {
        var customer = await _customerRepository.GetByIdAsync(model.CustomerID);
        if (customer == null) return;

        _mapper.Map(model, customer);
        await _customerRepository.UpdateAsync(customer);
    }

    public async Task DeleteCustomerAsync(int id)
    {
        await _customerRepository.DeleteAsync(id);
    }
}
