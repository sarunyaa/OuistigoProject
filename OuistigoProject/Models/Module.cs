using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OuistigoProject.Models
{
    public class Module
    {
        [Key]
        public int IdModule { get; set; }
        [Required]
        public string Wording { get; set; }
        public string Year { get; set; }
        public string Semester { get; set; }
        public ICollection<Learner> List_learner { get; set; }
        public DateTime Date_start { get; set; }
        public DateTime Date_end { get; set; }
        public DateTime Date_exam { get; set; }
    }
}
