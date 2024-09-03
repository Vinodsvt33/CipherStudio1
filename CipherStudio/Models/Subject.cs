using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CipherStudio.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int ClassId { get; set; }

        [Required]
        public string Language { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual Class Class { get; set; }

        //**********//
        [Required]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }


    }
}