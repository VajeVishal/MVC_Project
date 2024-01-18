using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace ModelController2.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController
        public ActionResult Index()
        {
            //List<Employee> lstEmps = new List<Employee>();

            //lstEmps.Add(new Employee { EmpNo = 1, Name = "Yash", Basic = 12345, DeptNo = 10 });
            //lstEmps.Add(new Employee { EmpNo = 2, Name = "Lalit", Basic = 12345, DeptNo = 10 });
            //lstEmps.Add(new Employee { EmpNo = 3, Name = "Saurabh", Basic = 12345, DeptNo = 10 });

            //return View(lstEmps);
            List<Employee> list = Employee.GetAllEmployees();
            return View(list);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
                return NotFound();
            Employee emp = Employee.GetSingleEmployee(id.Value);
            return View(emp);
           // return View();
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
       // public ActionResult Create(IFormCollection collection)
        public ActionResult Create(Employee obj, IFormCollection collection, string Name)
        {
            try
            {
                //string EmpNo = collection["EmpNo"];
                //string Name1 = collection["Name"];
                //string Basic = collection["Basic"];
                //string DeptNo = collection["DeptNo"];

                Employee.Create(obj);
                ViewBag.Message = "success!";
                return View();
                //return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int? id)
        {
            Employee emp = Employee.GetSingleEmployee(id.Value);
            return View(emp);
            //return View();
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee obj)
        {
            try
            {
                Employee.Update(obj);
               return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int? id,Employee emp)
        {
            Employee obj = Employee.GetSingleEmployee(id.Value);
            return View(obj);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id, IFormCollection collection)
        {
            try
            {
                Employee.Delete(id.Value);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
