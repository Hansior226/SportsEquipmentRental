using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

    public class RentalPlanController : Controller
    {
        private readonly IRentalPlanRepository _rentalPlanRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly ICustomerRepository _customerRepository;

        public RentalPlanController(IRentalPlanRepository rentalPlanRepository, IEquipmentRepository equipmentRepository, ICustomerRepository customerRepository)
        {
            _rentalPlanRepository = rentalPlanRepository;
            _equipmentRepository = equipmentRepository;
            _customerRepository = customerRepository;
        }

        public async Task<IActionResult> Index()
        {
            var rentalPlans = await _rentalPlanRepository.GetAllAsync();
            return View(rentalPlans);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["EquipmentId"] = new SelectList(await _equipmentRepository.GetAllAsync(), "EquipmentId", "Name");
            ViewData["CustomerId"] = new SelectList(await _customerRepository.GetAllAsync(), "CustomerId", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentalDate,ReturnDate,EquipmentId,CustomerId")] RentalPlan rentalPlan)
        {
            if (ModelState.IsValid)
            {
                await _rentalPlanRepository.AddAsync(rentalPlan);
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipmentId"] = new SelectList(await _equipmentRepository.GetAllAsync(), "EquipmentId", "Name", rentalPlan.EquipmentId);
            ViewData["CustomerId"] = new SelectList(await _customerRepository.GetAllAsync(), "CustomerId", "FullName", rentalPlan.CustomerId);
            return View(rentalPlan);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var rentalPlan = await _rentalPlanRepository.GetByIdAsync(id.Value);
            if (rentalPlan == null)
                return NotFound();

            ViewData["EquipmentId"] = new SelectList(await _equipmentRepository.GetAllAsync(), "EquipmentId", "Name", rentalPlan.EquipmentId);
            ViewData["CustomerId"] = new SelectList(await _customerRepository.GetAllAsync(), "CustomerId", "FullName", rentalPlan.CustomerId);
            return View(rentalPlan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentalId,RentalDate,ReturnDate,EquipmentId,CustomerId")] RentalPlan rentalPlan)
        {
            if (id != rentalPlan.RentalId)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _rentalPlanRepository.UpdateAsync(rentalPlan);
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipmentId"] = new SelectList(await _equipmentRepository.GetAllAsync(), "EquipmentId", "Name", rentalPlan.EquipmentId);
            ViewData["CustomerId"] = new SelectList(await _customerRepository.GetAllAsync(), "CustomerId", "FullName", rentalPlan.CustomerId);
            return View(rentalPlan);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var rentalPlan = await _rentalPlanRepository.GetByIdAsync(id.Value);
            if (rentalPlan == null)
                return NotFound();

            return View(rentalPlan);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _rentalPlanRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }