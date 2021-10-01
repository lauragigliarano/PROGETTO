namespace PROGETTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relazioni : DbMigration
    {
        public override void Up()
        {
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
                "dbo.StackholderCommessa",
                c => new
                    {
                        Stackholder_StackholderID = c.Int(nullable: false),
                        Commessa_CommessaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Stackholder_StackholderID, t.Commessa_CommessaID })
                .ForeignKey("dbo.Stackholder", t => t.Stackholder_StackholderID, cascadeDelete: true)
                .ForeignKey("dbo.Commessa", t => t.Commessa_CommessaID, cascadeDelete: true)
                .Index(t => t.Stackholder_StackholderID)
                .Index(t => t.Commessa_CommessaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StackholderCommessa", "Commessa_CommessaID", "dbo.Commessa");
            DropForeignKey("dbo.StackholderCommessa", "Stackholder_StackholderID", "dbo.Stackholder");
            DropIndex("dbo.StackholderCommessa", new[] { "Commessa_CommessaID" });
            DropIndex("dbo.StackholderCommessa", new[] { "Stackholder_StackholderID" });
            DropTable("dbo.StackholderCommessa");
            DropTable("dbo.Stackholder");
        }
    }
}
