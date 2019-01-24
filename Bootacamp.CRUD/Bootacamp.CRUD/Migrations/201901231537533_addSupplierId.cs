namespace Bootcamp.CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSupplierId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Supplier_id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "Supplier_id");
        }
    }
}
