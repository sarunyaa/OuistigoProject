﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OuistigoProject.Models
{
    public class ModuleLearner
    {
        [Key]
        public int IdModuleLearner { get; set; }
        public string Mark_test_1 { get; set; }
        public string Mark_test_2 { get; set; }
        public string Mark_test_3 { get; set; }
        public string Mark_continue { get; set; }
        public string Mark_exam { get; set; }
        public string Mark_final { get; set; }
        
        //foreign key
        
        public int IdLearner { get; set; }
        //public User IdLearner { get; set; }

        //foreign key
        public int IdModule { get; set; }
        //public Module IdModule { get; set; }
    }
}
