using Microsoft.AspNetCore.Mvc;
using System.Linq;

    public class EquipmentController : Controller
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentController(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task<IActionResult> Index()
        {
            var equipment = await _equipmentRepository.GetAllAsync();
            return View(equipment);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Material,Type,Availability,Cost")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                await _equipmentRepository.AddAsync(equipment);
                return RedirectToAction(nameof(Index));
            }
            return View(equipment);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var equipment = await _equipmentRepository.GetByIdAsync(id.Value);
            if (equipment == null)
                return NotFound();

            return View(equipment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EquipmentId,Name,Material,Type,Availability,Cost")] Equipment equipment)
        {
            if (id != equipment.EquipmentId)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _equipmentRepository.UpdateAsync(equipment);
                return RedirectToAction(nameof(Index));
            }
            return View(equipment);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var equipment = await _equipmentRepository.GetByIdAsync(id.Value);
            if (equipment == null)
                return NotFound();

            return View(equipment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _equipmentRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }