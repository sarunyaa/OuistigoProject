using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OuistigoProject.Models
{
    public class MeetingLearner
    {
        public bool isPresent { get; set; }

        //foreign key
        public User idTeacher { get; set; }
        public Live_Meeting idLiveMeeting { get; set; }
    }
}