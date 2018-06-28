using OuistigoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OuistigoProject.DAO
{
    public class ModuleLearnerObject
    {
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

        public int IdModule {get; set;}
        //public Module IdModule { get; set; }
    }
}