using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CipherStudio.Models
{
    public class Gender
    {
        public int Id { get; set; }
        [Display(Name = "Gender")]
        public string Name { get; set; }
    }
}