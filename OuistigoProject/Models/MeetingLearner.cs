using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OuistigoProject.Models
{
    public class MeetingLearner
    {
        [Key]
        public int IdMeetingLearner { get; set; }
        public bool IsPresent { get; set; }

        //foreign key
        public User IdTeacherz { get; set; }
        public Live_Meeting IdLiveMeeting { get; set; }
    }
}