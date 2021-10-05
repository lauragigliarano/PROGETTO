namespace PROGETTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dettagli3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cliente", "Telefono", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cliente", "Telefono", c => c.String());
        }
    }
}
