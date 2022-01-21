using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeMvcCrud.Models;
namespace EmployeeMvcCrud.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee/Index
        public ActionResult Index()
        {
            using (DBModels dBModels = new DBModels())
            {
                return View(dBModels.employees.ToList());
            }
            
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            using (DBModels dbModel = new DBModels())
            {
                return View(dbModel.employees.Where(x=> x.Id == id).FirstOrDefault());
            }
            
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(employee Employee)
        {
            try
            {
                using(DBModels dbModel = new DBModels())
                {
                    dbModel.employees.Add(Employee);
                    dbModel.SaveChanges();
                }
             
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/ Query Selected
        public ActionResult Edit(int id)
        {
            using (DBModels dbModel = new DBModels())
            {
                return View(dbModel.employees.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Employee/Edit/ - POST
        [HttpPost]
        public ActionResult Edit(int id, employee Employee)
        {
            try
            {
                using (DBModels dbModel = new DBModels())
                {
                    dbModel.Entry(Employee).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/ Query Selected
        public ActionResult Delete(int id)
        {
            using (DBModels dbModel = new DBModels())
            {
                return View(dbModel.employees.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Employee/Delete/ - POST
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (DBModels dbModel = new DBModels())
                {
                   employee Employee = dbModel.employees.Where(x => x.Id == id).FirstOrDefault();
                    dbModel.employees.Remove(Employee);
                    dbModel.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
