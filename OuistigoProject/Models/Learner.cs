using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OuistigoProject.Models
{
    public class Learner
    {
        [Key]
        public int IdLearner { get; set; }
        [Required]

        public Boolean Is_active { get; set; }
        public string Adresse_way_number { get; set; }
        public string Adresse_way_name { get; set; }
        public string Adresse_city { get; set; }
        public string Adresse_postal_code { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime Date_birth { get; set; }
        public DateTime Date_inscription { get; set; }
        public DateTime Date_interview { get; set; }
        public string State_payment { get; set; }

        //foreign key
        public User IdUser { get; set; }

    }
}
