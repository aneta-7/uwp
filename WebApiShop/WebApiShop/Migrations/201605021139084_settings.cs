namespace WebApiShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class settings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Week = c.Boolean(nullable: false),
                        Month = c.Boolean(nullable: false),
                        From = c.DateTime(),
                        To = c.DateTime(),
                        Limit = c.Double(nullable: false),
                        User_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Shops", "Value", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shops", "Value", c => c.String(nullable: false));
            DropTable("dbo.Settings");
        }
    }
}
