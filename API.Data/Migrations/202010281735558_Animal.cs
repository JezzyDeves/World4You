namespace API.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Animal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animal", "EquippedArtifact", c => c.Int());
            CreateIndex("dbo.Animal", "EquippedArtifact");
            AddForeignKey("dbo.Animal", "EquippedArtifact", "dbo.Artifact", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animal", "EquippedArtifact", "dbo.Artifact");
            DropIndex("dbo.Animal", new[] { "EquippedArtifact" });
            DropColumn("dbo.Animal", "EquippedArtifact");
        }
    }
}
