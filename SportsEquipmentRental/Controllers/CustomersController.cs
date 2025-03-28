using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class CustomersController : Controller
{
    private readonly CustomerService _customerService;

    public CustomersController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
    {
        var customers = await _customerService.GetAllCustomersAsync(pageNumber, pageSize);
        return View(customers);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,Phone")] Customer customer)
    {
        if (ModelState.IsValid)
        {
            await _customerService.AddCustomerAsync(customer);
            return RedirectToAction(nameof(Index));
        }
        return View(customer);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var customer = await _customerService.GetCustomerByIdAsync(id.Value);
        if (customer == null)
            return NotFound();

        return View(customer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("CustomerID,FirstName,LastName,Email,Phone")] Customer customer)
    {
        if (id != customer.CustomerID)
            return NotFound();

        if (ModelState.IsValid)
        {
            await _customerService.UpdateCustomerAsync(customer);
        }
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

