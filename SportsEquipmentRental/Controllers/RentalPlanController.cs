using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class RentalPlanController : Controller
{
    private readonly AppDbContext _context;

    public RentalPlanController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var rentals = _context.RentalPlans
                              .Select(r => new
                              {
                                  r.RentalId,
                                  r.RentalDate,
                                  r.ReturnDate,
                                  EquipmentName = r.Equipment.Name,
                                  CustomerName = r.Customer.FirstName + " " + r.Customer.LastName
                              })
                              .ToList();

        return View(rentals);
    }
}
