namespace PROGETTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComplexDataModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteID = c.Int(nullable: false),
                        RagioneSociale = c.String(),
                        Telefono = c.String(),
                        Mail = c.String(),
                    })
                .PrimaryKey(t => t.ClienteID);
            
            CreateTable(
                "dbo.Commessa",
                c => new
                    {
                        CommessaID = c.Int(nullable: false),
                        Descrizione = c.String(),
                        ClienteID = c.Int(nullable: false),
                        DataInizio = c.DateTime(nullable: false),
                        DataFine = c.DateTime(nullable: false),
                        Importo = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CommessaID)
                .ForeignKey("dbo.Cliente", t => t.ClienteID, cascadeDelete: true)
                .Index(t => t.ClienteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Commessa", "ClienteID", "dbo.Cliente");
            DropIndex("dbo.Commessa", new[] { "ClienteID" });
            DropTable("dbo.Commessa");
            DropTable("dbo.Cliente");
        }
    }
}
