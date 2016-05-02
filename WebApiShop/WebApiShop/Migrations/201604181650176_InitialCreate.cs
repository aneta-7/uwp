namespace WebApiShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(nullable: false),
                        Value = c.String(nullable: false),
                        Descripion = c.String(),
                        Category = c.String(nullable: false),
                        User_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Shops");
        }
    }
}
