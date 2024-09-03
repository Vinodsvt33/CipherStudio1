using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CipherStudio.Models
{
    public class Class
    {
        public int ClassId { get; set; }

        [Required]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string ClassName { get; set; }

        //***//
        [Required]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }

}