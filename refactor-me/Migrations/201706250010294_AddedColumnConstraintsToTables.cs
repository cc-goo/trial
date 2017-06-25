namespace refactor_me.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedColumnConstraintsToTables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductOptions", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ProductOptions", "Description", c => c.String(maxLength: 500));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.ProductOptions", "Description", c => c.String());
            AlterColumn("dbo.ProductOptions", "Name", c => c.String());
        }
    }
}
