using CipherStudio.CipherDbContext;
using CipherStudio.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace CipherStudio.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private AppDbContext db = new AppDbContext();
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    if (image != null && image.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(image.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                        image.SaveAs(path);
                        student.ImagePath = "/Images/" + fileName;
                    }

                    db.Students.Add(student);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException?.InnerException is SqlException sqlEx && sqlEx.Number == 2627)
                    {
                        // 2627 is the error number for unique constraint violation in SQL Server
                        ModelState.AddModelError("RollNumber", "RollNumber must be unique.");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName");
            return View(student);
        }

        public ActionResult Index(string searchString)
        {
            //var students = db.Students.Include(s => s.Class);

            //if (!string.IsNullOrEmpty(searchTerm))
            //{
            //    students = students.Where(s => s.Name.Contains(searchTerm));
            //}

            var students = from s in db.Students
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Name.Contains(searchString));
            }

            return View(students.ToList());
        }
        

    }
}