namespace OuistigoProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Formation_Unit", "IdUser_IdUser", "dbo.Users");
            DropForeignKey("dbo.Head_Teacher", "IdUser_IdUser", "dbo.Users");
            DropForeignKey("dbo.Learners", "IdUser_IdUser", "dbo.Users");
            DropForeignKey("dbo.Learners", "Live_Meeting_IdLive_Meeting", "dbo.Live_Meeting");
            DropForeignKey("dbo.Learners", "Module_IdModule", "dbo.Modules");
            DropForeignKey("dbo.Teachers", "IdUser_IdUser", "dbo.Users");
            DropForeignKey("dbo.Live_Meeting", "IdTeacher_IdTeacher", "dbo.Teachers");
            DropForeignKey("dbo.Learners", "Live_Meeting_IdLive_Meeting1", "dbo.Live_Meeting");
            DropForeignKey("dbo.Learners", "Live_Meeting_IdLive_Meeting2", "dbo.Live_Meeting");
            DropForeignKey("dbo.Marks", "IdLearner_IdLearner", "dbo.Learners");
            DropForeignKey("dbo.Marks", "IdModule_IdModule", "dbo.Modules");
            DropForeignKey("dbo.Secretariats", "IdUser_IdUser", "dbo.Users");
            DropIndex("dbo.Formation_Unit", new[] { "IdUser_IdUser" });
            DropIndex("dbo.Head_Teacher", new[] { "IdUser_IdUser" });
            DropIndex("dbo.Learners", new[] { "IdUser_IdUser" });
            DropIndex("dbo.Learners", new[] { "Live_Meeting_IdLive_Meeting" });
            DropIndex("dbo.Learners", new[] { "Module_IdModule" });
            DropIndex("dbo.Learners", new[] { "Live_Meeting_IdLive_Meeting1" });
            DropIndex("dbo.Learners", new[] { "Live_Meeting_IdLive_Meeting2" });
            DropIndex("dbo.Live_Meeting", new[] { "IdTeacher_IdTeacher" });
            DropIndex("dbo.Teachers", new[] { "IdUser_IdUser" });
            DropIndex("dbo.Marks", new[] { "IdLearner_IdLearner" });
            DropIndex("dbo.Marks", new[] { "IdModule_IdModule" });
            DropIndex("dbo.Secretariats", new[] { "IdUser_IdUser" });
            CreateTable(
                "dbo.MeetingLearners",
                c => new
                    {
                        IdMeetingLearner = c.Int(nullable: false, identity: true),
                        IsPresent = c.Boolean(nullable: false),
                        IdLiveMeeting_IdLive_Meeting = c.Int(),
                        IdTeacherz_IdUser = c.Int(),
                    })
                .PrimaryKey(t => t.IdMeetingLearner)
                .ForeignKey("dbo.Live_Meeting", t => t.IdLiveMeeting_IdLive_Meeting)
                .ForeignKey("dbo.Users", t => t.IdTeacherz_IdUser)
                .Index(t => t.IdLiveMeeting_IdLive_Meeting)
                .Index(t => t.IdTeacherz_IdUser);
            
            CreateTable(
                "dbo.ModuleLearners",
                c => new
                    {
                        IdModuleLearner = c.Int(nullable: false, identity: true),
                        Mark_test_1 = c.String(),
                        Mark_test_2 = c.String(),
                        Mark_test_3 = c.String(),
                        Mark_continue = c.String(),
                        Mark_exam = c.String(),
                        Mark_final = c.String(),
                        IdLearner_IdUser = c.Int(),
                        IdModule_IdModule = c.Int(),
                    })
                .PrimaryKey(t => t.IdModuleLearner)
                .ForeignKey("dbo.Users", t => t.IdLearner_IdUser)
                .ForeignKey("dbo.Modules", t => t.IdModule_IdModule)
                .Index(t => t.IdLearner_IdUser)
                .Index(t => t.IdModule_IdModule);
            
            AddColumn("dbo.Users", "Is_active", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "Adresse_way_number", c => c.String());
            AddColumn("dbo.Users", "Adresse_way_name", c => c.String());
            AddColumn("dbo.Users", "Adresse_city", c => c.String());
            AddColumn("dbo.Users", "Adresse_postal_code", c => c.String());
            AddColumn("dbo.Users", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Gender", c => c.String());
            AddColumn("dbo.Users", "Date_birth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "Date_inscription", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "Date_interview", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "State_payment", c => c.String());
            AddColumn("dbo.Live_Meeting", "IdTeacherz_IdUser", c => c.Int());
            AddColumn("dbo.Modules", "idTeacherz_IdUser", c => c.Int());
            CreateIndex("dbo.Live_Meeting", "IdTeacherz_IdUser");
            CreateIndex("dbo.Modules", "idTeacherz_IdUser");
            AddForeignKey("dbo.Modules", "idTeacherz_IdUser", "dbo.Users", "IdUser");
            AddForeignKey("dbo.Live_Meeting", "IdTeacherz_IdUser", "dbo.Users", "IdUser");
            DropColumn("dbo.Live_Meeting", "Participant_number");
            DropColumn("dbo.Live_Meeting", "Presents_number");
            DropColumn("dbo.Live_Meeting", "Absents_number");
            DropColumn("dbo.Live_Meeting", "IdTeacher_IdTeacher");
            DropTable("dbo.Formation_Unit");
            DropTable("dbo.Head_Teacher");
            DropTable("dbo.Learners");
            DropTable("dbo.Teachers");
            DropTable("dbo.Marks");
            DropTable("dbo.Secretariats");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Secretariats",
                c => new
                    {
                        Id_secretariat = c.Int(nullable: false, identity: true),
                        IdUser_IdUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_secretariat);
            
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
                .PrimaryKey(t => t.IdMark);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        IdTeacher = c.Int(nullable: false, identity: true),
                        IdUser_IdUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTeacher);
            
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
                .PrimaryKey(t => t.IdLearner);
            
            CreateTable(
                "dbo.Head_Teacher",
                c => new
                    {
                        IdHead_Teacher = c.Int(nullable: false, identity: true),
                        IdUser_IdUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdHead_Teacher);
            
            CreateTable(
                "dbo.Formation_Unit",
                c => new
                    {
                        IdFormation_unit = c.Int(nullable: false, identity: true),
                        IdUser_IdUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdFormation_unit);
            
            AddColumn("dbo.Live_Meeting", "IdTeacher_IdTeacher", c => c.Int());
            AddColumn("dbo.Live_Meeting", "Absents_number", c => c.Int(nullable: false));
            AddColumn("dbo.Live_Meeting", "Presents_number", c => c.Int(nullable: false));
            AddColumn("dbo.Live_Meeting", "Participant_number", c => c.Int(nullable: false));
            DropForeignKey("dbo.ModuleLearners", "IdModule_IdModule", "dbo.Modules");
            DropForeignKey("dbo.ModuleLearners", "IdLearner_IdUser", "dbo.Users");
            DropForeignKey("dbo.MeetingLearners", "IdTeacherz_IdUser", "dbo.Users");
            DropForeignKey("dbo.MeetingLearners", "IdLiveMeeting_IdLive_Meeting", "dbo.Live_Meeting");
            DropForeignKey("dbo.Live_Meeting", "IdTeacherz_IdUser", "dbo.Users");
            DropForeignKey("dbo.Modules", "idTeacherz_IdUser", "dbo.Users");
            DropIndex("dbo.ModuleLearners", new[] { "IdModule_IdModule" });
            DropIndex("dbo.ModuleLearners", new[] { "IdLearner_IdUser" });
            DropIndex("dbo.MeetingLearners", new[] { "IdTeacherz_IdUser" });
            DropIndex("dbo.MeetingLearners", new[] { "IdLiveMeeting_IdLive_Meeting" });
            DropIndex("dbo.Modules", new[] { "idTeacherz_IdUser" });
            DropIndex("dbo.Live_Meeting", new[] { "IdTeacherz_IdUser" });
            DropColumn("dbo.Modules", "idTeacherz_IdUser");
            DropColumn("dbo.Live_Meeting", "IdTeacherz_IdUser");
            DropColumn("dbo.Users", "State_payment");
            DropColumn("dbo.Users", "Date_interview");
            DropColumn("dbo.Users", "Date_inscription");
            DropColumn("dbo.Users", "Date_birth");
            DropColumn("dbo.Users", "Gender");
            DropColumn("dbo.Users", "Age");
            DropColumn("dbo.Users", "Adresse_postal_code");
            DropColumn("dbo.Users", "Adresse_city");
            DropColumn("dbo.Users", "Adresse_way_name");
            DropColumn("dbo.Users", "Adresse_way_number");
            DropColumn("dbo.Users", "Is_active");
            DropTable("dbo.ModuleLearners");
            DropTable("dbo.MeetingLearners");
            CreateIndex("dbo.Secretariats", "IdUser_IdUser");
            CreateIndex("dbo.Marks", "IdModule_IdModule");
            CreateIndex("dbo.Marks", "IdLearner_IdLearner");
            CreateIndex("dbo.Teachers", "IdUser_IdUser");
            CreateIndex("dbo.Live_Meeting", "IdTeacher_IdTeacher");
            CreateIndex("dbo.Learners", "Live_Meeting_IdLive_Meeting2");
            CreateIndex("dbo.Learners", "Live_Meeting_IdLive_Meeting1");
            CreateIndex("dbo.Learners", "Module_IdModule");
            CreateIndex("dbo.Learners", "Live_Meeting_IdLive_Meeting");
            CreateIndex("dbo.Learners", "IdUser_IdUser");
            CreateIndex("dbo.Head_Teacher", "IdUser_IdUser");
            CreateIndex("dbo.Formation_Unit", "IdUser_IdUser");
            AddForeignKey("dbo.Secretariats", "IdUser_IdUser", "dbo.Users", "IdUser", cascadeDelete: true);
            AddForeignKey("dbo.Marks", "IdModule_IdModule", "dbo.Modules", "IdModule");
            AddForeignKey("dbo.Marks", "IdLearner_IdLearner", "dbo.Learners", "IdLearner");
            AddForeignKey("dbo.Learners", "Live_Meeting_IdLive_Meeting2", "dbo.Live_Meeting", "IdLive_Meeting");
            AddForeignKey("dbo.Learners", "Live_Meeting_IdLive_Meeting1", "dbo.Live_Meeting", "IdLive_Meeting");
            AddForeignKey("dbo.Live_Meeting", "IdTeacher_IdTeacher", "dbo.Teachers", "IdTeacher");
            AddForeignKey("dbo.Teachers", "IdUser_IdUser", "dbo.Users", "IdUser", cascadeDelete: true);
            AddForeignKey("dbo.Learners", "Module_IdModule", "dbo.Modules", "IdModule");
            AddForeignKey("dbo.Learners", "Live_Meeting_IdLive_Meeting", "dbo.Live_Meeting", "IdLive_Meeting");
            AddForeignKey("dbo.Learners", "IdUser_IdUser", "dbo.Users", "IdUser");
            AddForeignKey("dbo.Head_Teacher", "IdUser_IdUser", "dbo.Users", "IdUser", cascadeDelete: true);
            AddForeignKey("dbo.Formation_Unit", "IdUser_IdUser", "dbo.Users", "IdUser", cascadeDelete: true);
        }
    }
}
