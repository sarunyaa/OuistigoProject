using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OuistigoProject.Models
{
    public class Mark
    {
        [Key]
        public int IdMark { get; set; }
        [Required]
        public string Year { get; set; }
        public string Semester { get; set; }
        public string Mark_test_1 { get; set; }
        public string Mark_test_2 { get; set; }
        public string Mark_test_3 { get; set; }
        public string Mark_continue { get; set; }
        public string Mark_exam { get; set; }
        public string Mark_final { get; set; }
        public string Number_inscription { get; set; }

        //foreign key
        public Learner IdLearner { get; set; }
        //foreign key
        public Module IdModule { get; set; }
    }
}
