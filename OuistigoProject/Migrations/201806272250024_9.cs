namespace OuistigoProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ModuleLearners", "IdLearner_IdUser", "dbo.Users");
            DropForeignKey("dbo.ModuleLearners", "IdModule_IdModule", "dbo.Modules");
            DropIndex("dbo.ModuleLearners", new[] { "IdLearner_IdUser" });
            DropIndex("dbo.ModuleLearners", new[] { "IdModule_IdModule" });
            RenameColumn(table: "dbo.Modules", name: "idTeacherz_IdUser", newName: "idTeacher_IdUser");
            RenameIndex(table: "dbo.Modules", name: "IX_idTeacherz_IdUser", newName: "IX_idTeacher_IdUser");
            AddColumn("dbo.ModuleLearners", "IdLearner", c => c.Int(nullable: false));
            AddColumn("dbo.ModuleLearners", "IdModule", c => c.Int(nullable: false));
            DropColumn("dbo.ModuleLearners", "IdLearner_IdUser");
            DropColumn("dbo.ModuleLearners", "IdModule_IdModule");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ModuleLearners", "IdModule_IdModule", c => c.Int());
            AddColumn("dbo.ModuleLearners", "IdLearner_IdUser", c => c.Int());
            DropColumn("dbo.ModuleLearners", "IdModule");
            DropColumn("dbo.ModuleLearners", "IdLearner");
            RenameIndex(table: "dbo.Modules", name: "IX_idTeacher_IdUser", newName: "IX_idTeacherz_IdUser");
            RenameColumn(table: "dbo.Modules", name: "idTeacher_IdUser", newName: "idTeacherz_IdUser");
            CreateIndex("dbo.ModuleLearners", "IdModule_IdModule");
            CreateIndex("dbo.ModuleLearners", "IdLearner_IdUser");
            AddForeignKey("dbo.ModuleLearners", "IdModule_IdModule", "dbo.Modules", "IdModule");
            AddForeignKey("dbo.ModuleLearners", "IdLearner_IdUser", "dbo.Users", "IdUser");
        }
    }
}
