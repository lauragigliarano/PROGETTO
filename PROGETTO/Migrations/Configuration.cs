namespace PROGETTO.Migrations
{
    using PROGETTO.Models;
    using PROGETTO.DAL;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PROGETTO.DAL.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PROGETTO.DAL.Context";
        }

        protected override void Seed(PROGETTO.DAL.Context context)
        {
            var cliente = new List<Cliente>
            {
            new Cliente{ClienteID=1159,RagioneSociale="Easynet S.p.A.", Telefono="0341-256911", Mail = "info@enet.it",
            Commesse = new List<Commessa>()},
            new Cliente{ClienteID=1139,RagioneSociale="Enel Italia S.p.a.", Telefono="0341-222211", Mail = "info@enei.it",
            Commesse = new List<Commessa>()},
            new Cliente{ClienteID=1149,RagioneSociale="Enel Energia S.p.a.", Telefono="0341-256333", Mail = "info@enen.it",
            Commesse = new List<Commessa>()}
            };
            cliente.ForEach(s => context.Cliente.AddOrUpdate(p => p.ClienteID, s));
            context.SaveChanges();

            var commessa = new List<Commessa>
            {
            new Commessa{CommessaID=1050, Descrizione="Chemistry", 
                DataInizio=DateTime.Parse("2005-09-01"), DataFine=DateTime.Parse("2006-09-01"), 
                Importo = 10M, ClienteID = cliente.Single(c => c.ClienteID == 1159 ).ClienteID},
            new Commessa{CommessaID=1030, Descrizione="Abbattimento", 
                DataInizio=DateTime.Parse("2015-09-01"), DataFine=DateTime.Parse("2015-10-01"), 
                Importo = 10M, ClienteID = cliente.Single(c => c.ClienteID == 1159 ).ClienteID},
            new Commessa{CommessaID=1040, Descrizione="Cablaggio",
                DataInizio=DateTime.Parse("2006-03-01"), DataFine=DateTime.Parse("2006-07-01"), 
                Importo = 10.50M, ClienteID = cliente.Single(c => c.ClienteID == 1149 ).ClienteID},
            };

            foreach (Commessa e in commessa)
            {
                var commessaInDataBase = context.Commessa.Where(
                    s =>
                         s.Cliente.ClienteID == e.ClienteID).FirstOrDefault();
                if (commessaInDataBase == null)
                {
                    context.Commessa.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
