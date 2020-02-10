using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECState.Models;


namespace ECState.Controllers
{
    public class employeeController : Controller
    {
        DataContext db = new DataContext();
        static string Cname = "";
        // GET: /Home/
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        // GET: /Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> lib = new List<SelectListItem>();
            lib.Add(new SelectListItem() { Text = "countryname", Value = "countryid" });
            foreach (var item in db.Countries.ToList())
            {
                lib.Add(new SelectListItem() { Text = item.country_name, Value = item.country_id.ToString() });
            }
            TempData["c"] = lib;
            TempData.Keep();



            List<SelectListItem> lil = new List<SelectListItem>();
            lil.Add(new SelectListItem() { Text = "statename", Value = "stateid" });
            foreach (var item in db.States.ToList())
            {
                lil.Add(new SelectListItem() { Text = item.state_name, Value = item.state_id.ToString() });
            }
            TempData["s"] = lil;
            TempData.Keep();

            List<SelectListItem> lic = new List<SelectListItem>();
            lic.Add(new SelectListItem() { Text = "Cname", Value = "Cid" });
            foreach (var item in db.cities.ToList())
            {
                lic.Add(new SelectListItem() { Text = item.city_name, Value = item.city_id.ToString() });
            }
            TempData["ci"] = lic;
            TempData.Keep();
            //IEnumerable<Country> s = db.Countries.ToList();
            //return View();


            var data = (from e in db.Employees

                        join c in db.Countries
                        on e.country_id equals c.country_id
                        join s in db.States
                        on e.state_id equals s.state_id
                        join ci in db.cities
                        on e.city_id equals ci.city_id
                        select new
                        {
                            empid = e.empid,
                            employeename = e.empname,
                            empfather = e.empfathername,
                            salary = e.empsalary,
                            countryname = c.country_name,
                            statename = s.state_name,
                            cityname = ci.city_name,
                            email = e.email,
                        }).ToList()

               .Select(x => new emp
               {
                   empid = x.empid,
                   empname = x.employeename,
                   empfathername = x.empfather,
                   empsalary = x.salary,
                   email = x.email,
                   country_name = x.countryname,
                   state_name = x.statename,
                   city_name = x.cityname,
               }).ToList();

            TempData["e"] = data;
            TempData.Keep();

            return View();
        }

        public JsonResult getstates(int id)
        {
            var states = db.States.Where(x => x.country_id == id);
            List<SelectListItem> liccc = new List<SelectListItem>();
            liccc.Add(new SelectListItem() { Text = "select states", Value = "0" });

            foreach (var item in states)
            {
                liccc.Add(new SelectListItem() { Text = item.state_name, Value = item.state_id.ToString() });
            }

            return Json(new SelectList(liccc, "Value", "Text", JsonRequestBehavior.AllowGet));
        }

        public JsonResult getcity(int id)
        {

            var cities = db.cities.Where(x => x.state_id == id);
            List<SelectListItem> lic = new List<SelectListItem>();
            lic.Add(new SelectListItem() { Text = "select citys", Value = "0" });

            foreach (var item in cities)
            {
                lic.Add(new SelectListItem() { Text = item.city_name, Value = item.city_id.ToString() });
            }

            return Json(new SelectList(lic, "Value", "Text", JsonRequestBehavior.AllowGet));
        }







        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection f)
        {
            Employee emp = new Employee();
            //emp ed=new emp();
            //e.empid= Convert.ToInt32(f[0]);
            emp.empname = f[1];
            emp.empfathername = f[2];
            emp.empsalary = (f[3]);
            emp.country_id = Convert.ToInt32(f[4]);
            emp.state_id = Convert.ToInt32(f[5]);
            emp.city_id = Convert.ToInt32(f[6]);
            emp.email = f[7];
            db.Employees.Add(emp);
            db.SaveChanges();

            return RedirectToAction("Create");
        }








        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [HttpGet]
        public ActionResult country()
        {
            IEnumerable<Country> s = db.Countries.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult country(Country c)
        {
            db.Countries.Add(c);
            db.SaveChanges();
            return RedirectToAction("State");
        }
        //[HttpGet]
        //public ActionResult getstate()
        //{
        //    List<SelectListItem> li = new List<SelectListItem>();
        //    li.Add(new SelectListItem() { Text = "country_name", Value = "country_id" });
        //    foreach (var item in db.Countries.ToList())
        //    {
        //        li.Add(new SelectListItem() { Text = item.country_name, Value = item.country_id.ToString() });
        //    }
        //    TempData["s"] = li;
        //    TempData.Keep();
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult getstate(State s)
        //{
        //    db.States.Add(s);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        [HttpGet]
        public ActionResult savestate()
        {
            List<SelectListItem> lib = new List<SelectListItem>();
            lib.Add(new SelectListItem() { Text = "countryname", Value = "country_id" });
            foreach (var item in db.Countries.ToList())
            {
                lib.Add(new SelectListItem() { Text = item.country_name, Value = item.country_id.ToString() });
            }
            TempData["c"] = lib;
            TempData.Keep();
            return View();
        }
        [HttpPost]
        public ActionResult savestate(State state)
        {
            State s = new State();

            db.States.Add(s);
            db.SaveChanges();
            return View("Index");
        }
    }
}

