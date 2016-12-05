namespace BinaryDad.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class files : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "MimeType", c => c.String());
            AddColumn("dbo.Contents", "Data", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "Data");
            DropColumn("dbo.Contents", "MimeType");
        }
    }
}
