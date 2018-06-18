using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OuistigoProject.Models
{
    public class OuistigoProjectContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public OuistigoProjectContext() : base("name=OuistigoProjectContext")
        {
        }

        public System.Data.Entity.DbSet<OuistigoProject.Models.Formation_Unit> Formation_Unit { get; set; }

        public System.Data.Entity.DbSet<OuistigoProject.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<OuistigoProject.Models.Head_Teacher> Head_Teacher { get; set; }

        public System.Data.Entity.DbSet<OuistigoProject.Models.Learner> Learners { get; set; }

        public System.Data.Entity.DbSet<OuistigoProject.Models.Live_Meeting> Live_Meeting { get; set; }

        public System.Data.Entity.DbSet<OuistigoProject.Models.Mark> Marks { get; set; }

        public System.Data.Entity.DbSet<OuistigoProject.Models.Module> Modules { get; set; }

        public System.Data.Entity.DbSet<OuistigoProject.Models.Secretariat> Secretariats { get; set; }

        public System.Data.Entity.DbSet<OuistigoProject.Models.Teacher> Teachers { get; set; }
    }
}
