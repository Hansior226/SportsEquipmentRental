using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class CustomerController : Controller
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
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

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,Phone")] CustomerViewModel customer)
    {
        if (!ModelState.IsValid)
        {
            return View(customer);
        }

        await _customerService.AddCustomerAsync(customer);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        return View(customer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("CustomerID,FirstName,LastName,Email,Phone")] CustomerViewModel customer)
    {
        if (id != customer.CustomerID)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(customer);
        }

        await _customerService.UpdateCustomerAsync(customer);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var customer = await _customerService.GetCustomerByIdAsync(id.Value);
        if (customer == null)
            return NotFound();

        return View(customer);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _customerService.DeleteCustomerAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
