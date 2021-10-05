namespace PROGETTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dettagli1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cliente", "Telefono", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cliente", "Telefono", c => c.String(maxLength: 20));
        }
    }
}
