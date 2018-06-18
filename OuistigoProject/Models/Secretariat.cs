﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OuistigoProject.Models
{
    public class Secretariat
    {
        [Key]
        public int Id_secretariat { get; set; }
        [Required]

        //foreign key
        public User IdUser { get; set; }

    }
}
