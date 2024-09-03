using CipherStudio.CipherDbContext;
using CipherStudio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CipherStudio.Controllers
{
   

    [Authorize]
    public class ClassController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            return View(db.Classes.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Class studentClass)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Classes.Add(studentClass);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                catch (DbUpdateException ex)
                {
                    if (ex.InnerException?.InnerException is SqlException sqlEx && sqlEx.Number == 2627)
                    {
                        // 2627 is the error number for unique constraint violation in SQL Server
                        ModelState.AddModelError("ClassName", "ClassName must be unique.");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View("Index");
        }
    }
}