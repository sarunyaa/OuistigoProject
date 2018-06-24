using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OuistigoProject.Models
{
    public class Live_Meeting
    {

        [Key]
        public int IdLive_Meeting { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public DateTime Start_time { get; set; }
        public DateTime End_time { get; set; }

        //foreign key
        public User IdTeacherz { get; set; }
        //foreign key
        public Module IdModule { get; set; }

    }
}
