using CipherStudio.CipherDbContext;
using CipherStudio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CipherStudio.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Teacher
        public ActionResult Create()
        {
            //ViewBag.genderlist = db.genders.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher teacher, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null && image.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(image.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    image.SaveAs(path);
                    teacher.ImagePath = "/Images/" + fileName;
                }
                //var a = teacher.GenderId.ToString();
                //teacher.Name = a;
                //if(a=="1")
                //{
                //    teacher.Gender =int.Parse"Male";
                //}
                //else
                //{
                //    teacher.Gender = "Female";
                //}
                db.Teachers.Add(teacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.genderlist = db.genders.ToList();

            return View(teacher);
        }
        public ActionResult Index()
        {
            return View(db.Teachers.ToList());
        }
    }
}