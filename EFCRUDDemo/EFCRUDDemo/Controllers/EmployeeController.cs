using EFCRUDDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EFCRUDDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private CompanyContext companyContext;

        public EmployeeController(CompanyContext cc)
        {
            companyContext = cc;
        }
        public IActionResult Create()
        {
            List<SelectListItem> dept = new List<SelectListItem>();
            dept = companyContext.Departments.Select(d => new SelectListItem { Text = d.Name, Value = d.Id.ToString() }).ToList();
            ViewBag.Department = dept;
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Employee employee)
        {
            companyContext.Add(employee);
            await companyContext.SaveChangesAsync();
            return View();
        }
        public IActionResult Index()
        {
            return View(companyContext.Employees.Include(s => s.department));

        }
        public async Task<IActionResult> Edit(int id)
        {
            Employee emp = await companyContext.Employees.Where(e => e.Id == id).FirstOrDefaultAsync();
            List<SelectListItem> dept = new List<SelectListItem>();
            dept = companyContext.Departments.Select(d => new SelectListItem { Text = d.Name, Value = d.Id.ToString() }).ToList();
            ViewBag.Department = dept;
            return View(emp);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee emp)
        {
            companyContext.Update(emp);
            await companyContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]

        public async Task<IActionResult>Delete(int id)
        {
            var emp = new Employee()
            {
                Id = id
            };
            companyContext.Remove(emp);
            await companyContext.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}
