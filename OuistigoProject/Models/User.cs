using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OuistigoProject.Models
{
    public class User
    {

        [Key]
        public int IdUser { get; set; }
        [Required]
        public string Id_connexion { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string Statut_connexion { get; set; }
        public DateTime Date_last_connexion { get; set; }
        public DateTime Time_last_connexion { get; set; }
        public string Mail_adress { get; set; }
        public string Phone_number { get; set; }
        public string Mdp { get; set; }
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

    }
}