using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewMvcApplication.Models;
using MvcApplication.DAL;
using MvcApplication.Core;
using System.Linq.Dynamic;
using System.Text;

namespace NewMvcApplication.Controllers
{

    public class Filtering
    {
        public string type { get; set; }
        public string value { get; set; }
        public string field { get; set; }
    }

    public class Sorting
    {
        public string property { set; get; }
        public string direction { set; get; }
    }

    public class PersonController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        //
        // GET: /Person/

        public ActionResult Index()
        {
            return View(db.Persons.ToList()[1]);
        }


        public ActionResult ListJson()
        {
            return Json(db.Persons.ToList(), JsonRequestBehavior.AllowGet);
        }


        public ActionResult ListExtJs(int start, int limit,string sort, string filter)
        {
            int totalcount = db.Persons.Count();
            List<FilterData> filters;
            List<SortData> sorts;
            List<Person> persons;

            filters = FilterData.GetData(filter);
            sorts = SortData.GetData(sort);
            if (sorts.Count() == 0)
            {
                sorts.Add(new SortData() { direction = "ASC", property = "FirstName" });
            }
            string sortproperty = sorts[0].property;
            string sortdirection = sorts[0].direction;

            persons = db.Persons.Where(FilterData.GetWhereCriteria(filters)).OrderBy(sortproperty + " " + sortdirection).Skip(start).Take(limit).ToList();
            
            return Json(new { data = persons.ToArray(), totalCount = totalcount }, JsonRequestBehavior.AllowGet);

        }

        

        //
        // GET: /Person/Details/5

        public ActionResult Details(long id = 0)
        {
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        //
        // GET: /Person/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Person/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        //
        // GET: /Person/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        //
        // POST: /Person/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        //
        // GET: /Person/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        //
        // POST: /Person/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Person person = db.Persons.Find(id);
            db.Persons.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult UpdatePerson(Person person)
        {
            try
            {

                if (person.Id == 0)
                {
                    db.Persons.Add(person);
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(person).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return Json(true);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}