using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OuistigoProject.DAO
{
    public class InscriptionObject
    {
        public string Id_connexion { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string Statut_connexion { get; set; }
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
        public string State_payment { get; set; }


    }
}