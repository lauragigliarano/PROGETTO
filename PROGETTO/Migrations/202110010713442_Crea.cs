namespace PROGETTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Crea : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteID = c.Int(nullable: false),
                        RagioneSociale = c.String(maxLength: 50),
                        Telefono = c.String(maxLength: 20),
                        Mail = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ClienteID);
            
            CreateTable(
                "dbo.Commessa",
                c => new
                    {
                        CommessaID = c.Int(nullable: false),
                        Descrizione = c.String(maxLength: 50),
                        ClienteID = c.Int(nullable: false),
                        DataInizio = c.DateTime(nullable: false),
                        DataFine = c.DateTime(nullable: false),
                        Importo = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CommessaID)
                .ForeignKey("dbo.Cliente", t => t.ClienteID, cascadeDelete: true)
                .Index(t => t.ClienteID);
            
            CreateTable(
                "dbo.Stackholder",
                c => new
                    {
                        StackholderID = c.Int(nullable: false),
                        Nome = c.String(maxLength: 50),
                        Cognome = c.String(maxLength: 50),
                        Telefono = c.String(maxLength: 20),
                        Cellulare = c.String(maxLength: 20),
                        Mail = c.String(maxLength: 50),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.StackholderID);
            
            CreateTable(
                "dbo.Commesse-Stackholder",
                c => new
                    {
                        StackholderID = c.Int(nullable: false),
                        CommessaID = c.Int(nullable: false),
                        NumeroRilevamentoID = c.Int(nullable: false),
                        DataRilevamento = c.DateTime(nullable: false),
                        Note = c.String(),
                })
                .PrimaryKey(t => new { t.NumeroRilevamentoID })
                .ForeignKey("dbo.Stackholder", t => t.StackholderID, cascadeDelete: true)
                .ForeignKey("dbo.Commessa", t => t.CommessaID, cascadeDelete: true)
                .Index(t => t.StackholderID)
                .Index(t => t.CommessaID);
            // Create  a department for course to point to.
          //  Sql("INSERT INTO dbo.Cliente (ClienteID, RagioneSociale, Telefono, Mail) VALUES (0, 'Temp', 'Temp', 'Temp')");
          //  default value for FK points to department created above.
          //AddColumn("dbo.Course", "ClienteID", c => c.Int(nullable: false, defaultValue: 1));
            //AddColumn("dbo.Course", "DepartmentID", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropForeignKey("dbo.Commesse-Stackholder", "CommessaID", "dbo.Commessa");
            DropForeignKey("dbo.Commesse-Stackholder", "StackholderID", "dbo.Stackholder");
            DropForeignKey("dbo.Commessa", "ClienteID", "dbo.Cliente");
            DropIndex("dbo.Commesse-Stackholder", new[] { "CommessaID" });
            DropIndex("dbo.Commesse-Stackholder", new[] { "StackholderID" });
            DropIndex("dbo.Commessa", new[] { "ClienteID" });
            DropTable("dbo.Commesse-Stackholder");
            DropTable("dbo.Stackholder");
            DropTable("dbo.Commessa");
            DropTable("dbo.Cliente");
        }
    }
}
