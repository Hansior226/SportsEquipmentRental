using SportsEquipmentRental.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync(); 
        Task<Customer> GetByIdAsync(int id); 
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(int id);
    }
