using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CipherStudio.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }
        [Display(Name ="Image")]
        public string ImagePath { get; set; }

        

        public gen Gender { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}