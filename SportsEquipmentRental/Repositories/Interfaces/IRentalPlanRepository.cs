using System.Collections.Generic;
using System.Threading.Tasks;

    public interface IRentalPlanRepository
    {
        Task<IEnumerable<RentalPlan>> GetAllAsync();
        Task<RentalPlan> GetByIdAsync(int id);
        Task AddAsync(RentalPlan rentalPlan);
        Task UpdateAsync(RentalPlan rentalPlan);
        Task DeleteAsync(int id);
    }