using Application.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain;
using WebApplication1.Services;

namespace WebApplication1.Persistance
{
    public class EmployeeRepository : IRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddAsync(Employee employee)
        {
            try
            {
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<List<Employee>> GetAllAsync()
        {
            var result = await _context.Employees.ToListAsync();
            return result;
        }
        public async Task<Employee> GetByIdAsync(long id)
        {
            var result = await _context.Employees.Where(e => e.Id == id).FirstOrDefaultAsync();
            return result;
        }
        public async Task<bool> UpdateAsync(Employee employee)
        {
            try
            {
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var result = await _context.Employees.Where(e => e.Id == id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _context.Employees.Remove(result);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }

}
