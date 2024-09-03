using CipherStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CipherStudio.ViewModel
{
    public class StudentTeacherSubjectViewModel
    {
        public int Id { get; set; }
        public StudentTeacherSubjectViewModel()
        {
           
        }                         

        public IEnumerable<Subject> Subjects { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }


        //public List<Subject> subjects { get; set; }
        //public List<Teacher> teachers { get; set; }
        //public List<Student> students { get; set; }
    }
}