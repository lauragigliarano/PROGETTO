namespace PROGETTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dettagli : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stackholder", "Telefono", c => c.String(maxLength: 10));
            AlterColumn("dbo.Stackholder", "Cellulare", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stackholder", "Cellulare", c => c.String(maxLength: 20));
            AlterColumn("dbo.Stackholder", "Telefono", c => c.String(maxLength: 20));
        }
    }
}
