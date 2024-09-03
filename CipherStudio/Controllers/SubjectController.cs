using CipherStudio.CipherDbContext;
using CipherStudio.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CipherStudio.Controllers
{
    [Authorize]
     public class SubjectController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName");
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Name");
            ViewBag.studentId = new SelectList(db.Students, "StudentId", "Name");
          

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Subjects.Add(subject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", subject.ClassId);

            //***///
            ViewBag.TeacherId = new SelectList(db.Classes, "TeacherId", "TeacherName", subject.TeacherId);
            return View(subject);
        }

        public ActionResult Index()
        {
            var subjects = db.Subjects.Include(s => s.Class).Include(s => s.Teachers);
            return View(subjects.ToList());
        }
    }
}