using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OuistigoProject.Models
{
    public class Teacher
    {
        [Key]
        public int IdTeacher { get; set; }
        [Required]

        //foreign key
        public User IdUser { get; set; }
    }
}