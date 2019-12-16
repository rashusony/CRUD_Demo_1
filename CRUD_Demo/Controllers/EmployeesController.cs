using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_Demo.Models;

namespace CRUD_Demo.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeesController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index(string SearchName,string SearchPosition)
        {
            var Name = from s in _context.Employees
                       select s;
            if(!string.IsNullOrEmpty(SearchName)&&!string.IsNullOrEmpty(SearchPosition))
            { 
            Name = Name.Where(x => x.Name.Contains(SearchName) && x.Position.Contains(SearchPosition));

            }
            else if(!string.IsNullOrEmpty(SearchName) || !string.IsNullOrEmpty(SearchPosition))
            {
                Name = Name.Where(x => x.Name.Contains(SearchName) || x.Position.Contains(SearchPosition));

            }

            return View(await Name.ToListAsync());
        }

        // GET: Employees/Details/5
      
        // GET: Employees/Create
        public IActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
                return View(new Employee());

            else
                return View(_context.Employees.Find(id));
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("EmployeeId,Name,EmpCode,OfficeLocation,Position,Gender")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.EmployeeId == 0)
                    _context.Add(employee);

                else
                    _context.Update(employee);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
     

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.


        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
