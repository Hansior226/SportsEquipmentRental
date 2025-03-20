using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

    public class RentalPlanRepository : IRentalPlanRepository
    {
        private readonly AppDbContext _context;

        public RentalPlanRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RentalPlan>> GetAllAsync()
        {
            return await _context.RentalPlans
                .Include(r => r.Equipment)
                .Include(r => r.Customer)
                .ToListAsync();
        }

        public async Task<RentalPlan> GetByIdAsync(int id)
        {
            return await _context.RentalPlans
                .Include(r => r.Equipment)
                .Include(r => r.Customer)
                .FirstOrDefaultAsync(r => r.RentalId == id);
        }

        public async Task AddAsync(RentalPlan rentalPlan)
        {
            _context.RentalPlans.Add(rentalPlan);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RentalPlan rentalPlan)
        {
            _context.RentalPlans.Update(rentalPlan);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var rentalPlan = await _context.RentalPlans.FindAsync(id);
            if (rentalPlan != null)
            {
                _context.RentalPlans.Remove(rentalPlan);
                await _context.SaveChangesAsync();
            }
        }
    }