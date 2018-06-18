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

    }
}