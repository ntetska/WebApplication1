using WebApplication1.Domain;

namespace WebApplication1.Services
{
    public interface IRepository
    {
      Task<bool> AddAsync(Employee employee);
      Task<List<Employee>> GetAllAsync();
      Task<bool> UpdateAsync(Employee employee);
        Task<Employee> GetByIdAsync(long id);
        Task<bool> DeleteAsync(long id);


    }
}
