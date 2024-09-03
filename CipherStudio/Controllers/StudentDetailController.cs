using CipherStudio.CipherDbContext;
using CipherStudio.Models;
using CipherStudio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CipherStudio.Controllers
{
    [Authorize]
    public class StudentDetailController : Controller
    {
        private AppDbContext db = new AppDbContext();

        protected List<Student> _student { get; set; }
        protected List<Subject> _subject { get; set; }
        protected List<Teacher> _teacher { get; set; }
        
        public ActionResult Index()
        {
            StudentTeacherSubjectViewModel viewModelObj = new StudentTeacherSubjectViewModel();
            viewModelObj.Students = db.Students.ToList();
            viewModelObj.Subjects = db.Subjects.ToList();
            viewModelObj.Teachers = db.Teachers.ToList();
            ViewBag.viewModel = viewModelObj;

            return View(viewModelObj);
        }
    }
}