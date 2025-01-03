namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_writer_edit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterAbout", c => c.String(maxLength: 100));
            AlterColumn("dbo.Writers", "Mail", c => c.String(maxLength: 200));
            AlterColumn("dbo.Writers", "MWriterPassword", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "MWriterPassword", c => c.String(maxLength: 20));
            AlterColumn("dbo.Writers", "Mail", c => c.String(maxLength: 50));
            DropColumn("dbo.Writers", "WriterAbout");
        }
    }
}
