using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class EquipmentController : Controller
{
    private readonly AppDbContext _context;

    public EquipmentController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var equipmentList = _context.Equipment.ToList();
        return View(equipmentList);
    }
}
