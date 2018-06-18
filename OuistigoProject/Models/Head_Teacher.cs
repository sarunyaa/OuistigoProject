using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OuistigoProject.Models
{
    public class Head_Teacher
    {
        [Key]
        public int IdHead_Teacher { get; set; }
        [Required]

        //foreign key
        public User IdUser { get; set; }
    }
}
