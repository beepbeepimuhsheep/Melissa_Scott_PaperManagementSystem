namespace Melissa_Scott_9189_SA2_IPG521_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class B : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        PaperId = c.Int(nullable: false, identity: true),
                        PaperTitle = c.String(nullable: false),
                        PaperAbstract = c.String(nullable: false),
                        PaperAuthor = c.String(nullable: false),
                        TopicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaperId);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        PaperTopicIdId = c.Int(nullable: false, identity: true),
                        TopicName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PaperTopicIdId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Topics");
            DropTable("dbo.Authors");
        }
    }
}
