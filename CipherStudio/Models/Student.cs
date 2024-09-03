using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CipherStudio.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(5, 100)]
        public int Age { get; set; }
        [Display(Name ="Image")]
        public string ImagePath { get; set; }
        public string SearchTerm { get; set; }

        [Required]
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }

        [Required]
        [Index(IsUnique =true)]

        public int RollNumber { get; set; }

    }

}