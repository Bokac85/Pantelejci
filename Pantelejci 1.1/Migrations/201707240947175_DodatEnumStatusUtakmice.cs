namespace Pantelejci_1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodatEnumStatusUtakmice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utakmicas", "StatusUtakmice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Utakmicas", "StatusUtakmice");
        }
    }
}
