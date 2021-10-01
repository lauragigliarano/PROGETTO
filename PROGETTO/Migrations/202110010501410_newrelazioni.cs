namespace PROGETTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newrelazioni : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.StackholderCommessa", newName: "Commesse-Stackholder");
            RenameColumn(table: "dbo.Commesse-Stackholder", name: "Stackholder_StackholderID", newName: "StackholderID");
            RenameColumn(table: "dbo.Commesse-Stackholder", name: "Commessa_CommessaID", newName: "CommessaID");
            RenameIndex(table: "dbo.Commesse-Stackholder", name: "IX_Commessa_CommessaID", newName: "IX_CommessaID");
            RenameIndex(table: "dbo.Commesse-Stackholder", name: "IX_Stackholder_StackholderID", newName: "IX_StackholderID");
            DropPrimaryKey("dbo.Commesse-Stackholder");
            AddPrimaryKey("dbo.Commesse-Stackholder", new[] { "CommessaID", "StackholderID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Commesse-Stackholder");
            AddPrimaryKey("dbo.Commesse-Stackholder", new[] { "Stackholder_StackholderID", "Commessa_CommessaID" });
            RenameIndex(table: "dbo.Commesse-Stackholder", name: "IX_StackholderID", newName: "IX_Stackholder_StackholderID");
            RenameIndex(table: "dbo.Commesse-Stackholder", name: "IX_CommessaID", newName: "IX_Commessa_CommessaID");
            RenameColumn(table: "dbo.Commesse-Stackholder", name: "CommessaID", newName: "Commessa_CommessaID");
            RenameColumn(table: "dbo.Commesse-Stackholder", name: "StackholderID", newName: "Stackholder_StackholderID");
            RenameTable(name: "dbo.Commesse-Stackholder", newName: "StackholderCommessa");
        }
    }
}
