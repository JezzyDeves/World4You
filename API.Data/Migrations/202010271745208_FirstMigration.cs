namespace API.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "EquippedArtifact", c => c.Int());
            CreateIndex("dbo.Person", "EquippedArtifact");
            AddForeignKey("dbo.Person", "EquippedArtifact", "dbo.Artifact", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Person", "EquippedArtifact", "dbo.Artifact");
            DropIndex("dbo.Person", new[] { "EquippedArtifact" });
            DropColumn("dbo.Person", "EquippedArtifact");
        }
    }
}
