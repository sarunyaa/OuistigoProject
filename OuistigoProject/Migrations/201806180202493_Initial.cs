namespace OuistigoProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Formation_Unit",
                c => new
                    {
                        IdFormation_unit = c.Int(nullable: false, identity: true),
                        IdUser_IdUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdFormation_unit)
                .ForeignKey("dbo.Users", t => t.IdUser_IdUser, cascadeDelete: true)
                .Index(t => t.IdUser_IdUser);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        Id_connexion = c.String(nullable: false),
                        Role = c.String(),
                        FirstName = c.String(),
                        Name = c.String(),
                        Statut_connexion = c.String(),
                        Date_last_connexion = c.DateTime(nullable: false),
                        Time_last_connexion = c.DateTime(nullable: false),
                        Mail_adress = c.String(),
                        Phone_number = c.String(),
                    })
                .PrimaryKey(t => t.IdUser);
            
            CreateTable(
                "dbo.Head_Teacher",
                c => new
                    {
                        IdHead_Teacher = c.Int(nullable: false, identity: true),
                        IdUser_IdUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdHead_Teacher)
                .ForeignKey("dbo.Users", t => t.IdUser_IdUser, cascadeDelete: true)
                .Index(t => t.IdUser_IdUser);
            
            CreateTable(
                "dbo.Learners",
                c => new
                    {
                        IdLearner = c.Int(nullable: false, identity: true),
                        Is_active = c.Boolean(nullable: false),
                        Adresse_way_number = c.String(),
                        Adresse_way_name = c.String(),
                        Adresse_city = c.String(),
                        Adresse_postal_code = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.String(),
                        Date_birth = c.DateTime(nullable: false),
                        Date_inscription = c.DateTime(nullable: false),
                        Date_interview = c.DateTime(nullable: false),
                        State_payment = c.String(),
                        IdUser_IdUser = c.Int(),
                        Live_Meeting_IdLive_Meeting = c.Int(),
                        Module_IdModule = c.Int(),
                        Live_Meeting_IdLive_Meeting1 = c.Int(),
                        Live_Meeting_IdLive_Meeting2 = c.Int(),
                    })
                .PrimaryKey(t => t.IdLearner)
                .ForeignKey("dbo.Users", t => t.IdUser_IdUser)
                .ForeignKey("dbo.Live_Meeting", t => t.Live_Meeting_IdLive_Meeting)
                .ForeignKey("dbo.Modules", t => t.Module_IdModule)
                .ForeignKey("dbo.Live_Meeting", t => t.Live_Meeting_IdLive_Meeting1)
                .ForeignKey("dbo.Live_Meeting", t => t.Live_Meeting_IdLive_Meeting2)
                .Index(t => t.IdUser_IdUser)
                .Index(t => t.Live_Meeting_IdLive_Meeting)
                .Index(t => t.Module_IdModule)
                .Index(t => t.Live_Meeting_IdLive_Meeting1)
                .Index(t => t.Live_Meeting_IdLive_Meeting2);
            
            CreateTable(
                "dbo.Live_Meeting",
                c => new
                    {
                        IdLive_Meeting = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Start_time = c.DateTime(nullable: false),
                        End_time = c.DateTime(nullable: false),
                        Participant_number = c.Int(nullable: false),
                        Presents_number = c.Int(nullable: false),
                        Absents_number = c.Int(nullable: false),
                        IdModule_IdModule = c.Int(),
                        IdTeacher_IdTeacher = c.Int(),
                    })
                .PrimaryKey(t => t.IdLive_Meeting)
                .ForeignKey("dbo.Modules", t => t.IdModule_IdModule)
                .ForeignKey("dbo.Teachers", t => t.IdTeacher_IdTeacher)
                .Index(t => t.IdModule_IdModule)
                .Index(t => t.IdTeacher_IdTeacher);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        IdModule = c.Int(nullable: false, identity: true),
                        Wording = c.String(nullable: false),
                        Year = c.String(),
                        Semester = c.String(),
                        Date_start = c.DateTime(nullable: false),
                        Date_end = c.DateTime(nullable: false),
                        Date_exam = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdModule);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        IdTeacher = c.Int(nullable: false, identity: true),
                        IdUser_IdUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTeacher)
                .ForeignKey("dbo.Users", t => t.IdUser_IdUser, cascadeDelete: true)
                .Index(t => t.IdUser_IdUser);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        IdMark = c.Int(nullable: false, identity: true),
                        Year = c.String(nullable: false),
                        Semester = c.String(),
                        Mark_test_1 = c.String(),
                        Mark_test_2 = c.String(),
                        Mark_test_3 = c.String(),
                        Mark_continue = c.String(),
                        Mark_exam = c.String(),
                        Mark_final = c.String(),
                        Number_inscription = c.String(),
                        IdLearner_IdLearner = c.Int(),
                        IdModule_IdModule = c.Int(),
                    })
                .PrimaryKey(t => t.IdMark)
                .ForeignKey("dbo.Learners", t => t.IdLearner_IdLearner)
                .ForeignKey("dbo.Modules", t => t.IdModule_IdModule)
                .Index(t => t.IdLearner_IdLearner)
                .Index(t => t.IdModule_IdModule);
            
            CreateTable(
                "dbo.Secretariats",
                c => new
                    {
                        Id_secretariat = c.Int(nullable: false, identity: true),
                        IdUser_IdUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_secretariat)
                .ForeignKey("dbo.Users", t => t.IdUser_IdUser, cascadeDelete: true)
                .Index(t => t.IdUser_IdUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Secretariats", "IdUser_IdUser", "dbo.Users");
            DropForeignKey("dbo.Marks", "IdModule_IdModule", "dbo.Modules");
            DropForeignKey("dbo.Marks", "IdLearner_IdLearner", "dbo.Learners");
            DropForeignKey("dbo.Learners", "Live_Meeting_IdLive_Meeting2", "dbo.Live_Meeting");
            DropForeignKey("dbo.Learners", "Live_Meeting_IdLive_Meeting1", "dbo.Live_Meeting");
            DropForeignKey("dbo.Live_Meeting", "IdTeacher_IdTeacher", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "IdUser_IdUser", "dbo.Users");
            DropForeignKey("dbo.Live_Meeting", "IdModule_IdModule", "dbo.Modules");
            DropForeignKey("dbo.Learners", "Module_IdModule", "dbo.Modules");
            DropForeignKey("dbo.Learners", "Live_Meeting_IdLive_Meeting", "dbo.Live_Meeting");
            DropForeignKey("dbo.Learners", "IdUser_IdUser", "dbo.Users");
            DropForeignKey("dbo.Head_Teacher", "IdUser_IdUser", "dbo.Users");
            DropForeignKey("dbo.Formation_Unit", "IdUser_IdUser", "dbo.Users");
            DropIndex("dbo.Secretariats", new[] { "IdUser_IdUser" });
            DropIndex("dbo.Marks", new[] { "IdModule_IdModule" });
            DropIndex("dbo.Marks", new[] { "IdLearner_IdLearner" });
            DropIndex("dbo.Teachers", new[] { "IdUser_IdUser" });
            DropIndex("dbo.Live_Meeting", new[] { "IdTeacher_IdTeacher" });
            DropIndex("dbo.Live_Meeting", new[] { "IdModule_IdModule" });
            DropIndex("dbo.Learners", new[] { "Live_Meeting_IdLive_Meeting2" });
            DropIndex("dbo.Learners", new[] { "Live_Meeting_IdLive_Meeting1" });
            DropIndex("dbo.Learners", new[] { "Module_IdModule" });
            DropIndex("dbo.Learners", new[] { "Live_Meeting_IdLive_Meeting" });
            DropIndex("dbo.Learners", new[] { "IdUser_IdUser" });
            DropIndex("dbo.Head_Teacher", new[] { "IdUser_IdUser" });
            DropIndex("dbo.Formation_Unit", new[] { "IdUser_IdUser" });
            DropTable("dbo.Secretariats");
            DropTable("dbo.Marks");
            DropTable("dbo.Teachers");
            DropTable("dbo.Modules");
            DropTable("dbo.Live_Meeting");
            DropTable("dbo.Learners");
            DropTable("dbo.Head_Teacher");
            DropTable("dbo.Users");
            DropTable("dbo.Formation_Unit");
        }
    }
}
