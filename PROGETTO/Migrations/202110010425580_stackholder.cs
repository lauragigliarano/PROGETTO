namespace PROGETTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stackholder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cliente", "RagioneSociale", c => c.String(maxLength: 50));
            AlterColumn("dbo.Cliente", "Telefono", c => c.String(maxLength: 20));
            AlterColumn("dbo.Cliente", "Mail", c => c.String(maxLength: 50));
            AlterColumn("dbo.Commessa", "Descrizione", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Commessa", "Descrizione", c => c.String());
            AlterColumn("dbo.Cliente", "Mail", c => c.String());
            AlterColumn("dbo.Cliente", "Telefono", c => c.String());
            AlterColumn("dbo.Cliente", "RagioneSociale", c => c.String());
        }
    }
}
