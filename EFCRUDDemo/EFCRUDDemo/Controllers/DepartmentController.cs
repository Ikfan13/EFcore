using EFCRUDDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCRUDDemo.Controllers
{
    public class DepartmentController : Controller
    {
        private CompanyContext companyContext;

        public DepartmentController(CompanyContext cc)
        {
            companyContext = cc;
        }
        public IActionResult Create()
        {
                //var dept = new Department() { 
                //Name = "Designing",

                //};
                //var dept1 = new Department()
                //{
                //    Name = "Information Technology",

                //};
                //var dept2 = new Department()
                //{
                //    Name = "Production",

                //};
                //var dept3 = new Department()
                //{
                //    Name = "Delivery",

                //};
                //companyContext.AddRange(dept, dept1, dept2, dept3 );
                //companyContext.SaveChanges();

                //return "DepartmentAdded";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> create(Department dept)
        {
            companyContext.Add(dept);
            await companyContext.SaveChangesAsync();
            return View();
        }
        public IActionResult Index()
        {
            return View(companyContext.Departments.AsNoTracking());
        }
        public async Task<IActionResult> Edit(int id)
        {
            Department dept = await companyContext.Departments.Where(e => e.Id == id).FirstOrDefaultAsync();
            return View(dept);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Department dept)
        {
            companyContext.Update(dept);
            await companyContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]

        public async Task<IActionResult> Delete(int id)
        {
            var dept = new Department()
            {
                Id = id
            };
            companyContext.Remove(dept);
            await companyContext.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}
