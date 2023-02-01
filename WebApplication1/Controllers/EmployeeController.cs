using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class EmployeeController
        : Controller
    {

        private readonly IRepository _employeeService;

        public EmployeeController(IRepository employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _employeeService.GetAllAsync());
        }
       
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Active,Date,Title,Email,Phone")] Domain.Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.AddAsync(employee);

                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public async Task<IActionResult> Update(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeService.GetByIdAsync(id.Value);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(long id, [Bind("Id,FirstName,LastName,Active,Date,Title,Email,Phone")] Domain.Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                await _employeeService.UpdateAsync(employee);


                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }



        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeService.GetByIdAsync(id.Value);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var user = await _employeeService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
    }