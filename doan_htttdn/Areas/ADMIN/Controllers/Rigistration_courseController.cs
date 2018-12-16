using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using doan_htttdn.FF;

namespace doan_htttdn.Areas.ADMIN.Controllers
{
    public class Rigistration_courseController : Controller
    {
        private QL_SCN db = new QL_SCN();

        // GET: ADMIN/Rigistration_course
        public ActionResult Index()
        {
            var rIGISTRATION_COURSE = db.RIGISTRATION_COURSE.Include(r => r.COURSE);
            return View(rIGISTRATION_COURSE.ToList());
        }

        // GET: ADMIN/Rigistration_course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RIGISTRATION_COURSE rIGISTRATION_COURSE = db.RIGISTRATION_COURSE.Find(id);
            if (rIGISTRATION_COURSE == null)
            {
                return HttpNotFound();
            }
            return View(rIGISTRATION_COURSE);
        }

        // GET: ADMIN/Rigistration_course/Create
        public ActionResult Create()
        {
            ViewBag.IDCourse = new SelectList(db.COURSEs, "IDCourse", "Name");
            return View();
        }

        // POST: ADMIN/Rigistration_course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDRegist,NameParent,Phone,Email,NameStudent,BIRTHDAY,ADDRESS,IDCourse,State")] RIGISTRATION_COURSE rIGISTRATION_COURSE)
        {
            if (ModelState.IsValid)
            {
                db.RIGISTRATION_COURSE.Add(rIGISTRATION_COURSE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCourse = new SelectList(db.COURSEs, "IDCourse", "Name", rIGISTRATION_COURSE.IDCourse);
            return View(rIGISTRATION_COURSE);
        }

        // GET: ADMIN/Rigistration_course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RIGISTRATION_COURSE rIGISTRATION_COURSE = db.RIGISTRATION_COURSE.Find(id);
            if (rIGISTRATION_COURSE == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCourse = new SelectList(db.COURSEs, "IDCourse", "Name", rIGISTRATION_COURSE.IDCourse);
            return View(rIGISTRATION_COURSE);
        }

        // POST: ADMIN/Rigistration_course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDRegist,NameParent,Phone,Email,NameStudent,BIRTHDAY,ADDRESS,IDCourse,State")] RIGISTRATION_COURSE rIGISTRATION_COURSE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rIGISTRATION_COURSE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCourse = new SelectList(db.COURSEs, "IDCourse", "Name", rIGISTRATION_COURSE.IDCourse);
            return View(rIGISTRATION_COURSE);
        }

        // GET: ADMIN/Rigistration_course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RIGISTRATION_COURSE rIGISTRATION_COURSE = db.RIGISTRATION_COURSE.Find(id);
            if (rIGISTRATION_COURSE == null)
            {
                return HttpNotFound();
            }
            return View(rIGISTRATION_COURSE);
        }

        // POST: ADMIN/Rigistration_course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RIGISTRATION_COURSE rIGISTRATION_COURSE = db.RIGISTRATION_COURSE.Find(id);
            db.RIGISTRATION_COURSE.Remove(rIGISTRATION_COURSE);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
