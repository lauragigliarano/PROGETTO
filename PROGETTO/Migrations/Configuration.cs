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
                Importo = 10, ClienteID = cliente.Single(c => c.ClienteID == 1159 ).ClienteID, Stackholders=new List<Stackholder>()},
            new Commessa{CommessaID=1030, Descrizione="Abbattimento", 
                DataInizio=DateTime.Parse("2015-09-01"), DataFine=DateTime.Parse("2015-10-01"), 
                Importo = 10, ClienteID = cliente.Single(c => c.ClienteID == 1159 ).ClienteID, Stackholders=new List<Stackholder>() },
            new Commessa{CommessaID=1040, Descrizione="Cablaggio",
                DataInizio=DateTime.Parse("2006-03-01"), DataFine=DateTime.Parse("2006-07-01"), 
                Importo = 10, ClienteID = cliente.Single(c => c.ClienteID == 1149 ).ClienteID, Stackholders=new List<Stackholder>()},
            };

            commessa.ForEach(s => context.Commessa.AddOrUpdate(p => p.CommessaID, s));
            context.SaveChanges();

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

            var stackholder = new List<Stackholder>
            {
            new Stackholder{StackholderID=1159,Nome="Investitore", Cognome="uno", Telefono = "034113147634", Cellulare="33825427428", Mail="info@enet.it", Note="Lorem ipsum dolor sit amet, consectetur adipisci elit, sed do eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrum exercitationem ullamco laboriosam, nisi ut aliquid ex ea commodi consequatur. Duis aute irure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            Commesse = new List<Commessa>()},
            new Stackholder{StackholderID=1139,Nome="Investitore", Cognome="due", Telefono = "034113147634", Cellulare="33825427428", Mail="info@enet.it", Note="Lorem ipsum dolor sit amet, consectetur adipisci elit, sed do eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrum exercitationem ullamco laboriosam, nisi ut aliquid ex ea commodi consequatur. Duis aute irure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            Commesse = new List<Commessa>()},
            new Stackholder{StackholderID=1229,Nome="Investitore", Cognome="tre", Telefono = "034113147634", Cellulare="33825427428", Mail="info@enet.it", Note="Lorem ipsum dolor sit amet, consectetur adipisci elit, sed do eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrum exercitationem ullamco laboriosam, nisi ut aliquid ex ea commodi consequatur. Duis aute irure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            Commesse = new List<Commessa>()}
            };
            stackholder.ForEach(s => context.Stackholder.AddOrUpdate(p => p.StackholderID, s));
            context.SaveChanges();

            //var commesseStackholder = new Commesse-Stackholder
            //{
            //new Stackholder{StackholderID=1159,Nome="Investitore", Cognome="uno", Telefono = "034113147634", Cellulare="33825427428", Mail="info@enet.it", Note="Lorem ipsum dolor sit amet, consectetur adipisci elit, sed do eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrum exercitationem ullamco laboriosam, nisi ut aliquid ex ea commodi consequatur. Duis aute irure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            //Commesse = new List<Commessa>()},
            //new Stackholder{StackholderID=1139,Nome="Investitore", Cognome="due", Telefono = "034113147634", Cellulare="33825427428", Mail="info@enet.it", Note="Lorem ipsum dolor sit amet, consectetur adipisci elit, sed do eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrum exercitationem ullamco laboriosam, nisi ut aliquid ex ea commodi consequatur. Duis aute irure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            //Commesse = new List<Commessa>()},
            //new Stackholder{StackholderID=1229,Nome="Investitore", Cognome="tre", Telefono = "034113147634", Cellulare="33825427428", Mail="info@enet.it", Note="Lorem ipsum dolor sit amet, consectetur adipisci elit, sed do eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrum exercitationem ullamco laboriosam, nisi ut aliquid ex ea commodi consequatur. Duis aute irure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            //Commesse = new List<Commessa>()}
            //};
            //stackholder.ForEach(s => context.Stackholder.AddOrUpdate(p => p.StackholderID, s));
            //context.SaveChanges();

            AddOrUpdateStackholder(context, 1050, 1159);
            AddOrUpdateStackholder(context, 1030, 1139);
            AddOrUpdateStackholder(context, 1040, 1229);

            context.SaveChanges();
        }

        void AddOrUpdateStackholder(Context context, int commessaId, int stackholderId)
        {
            var crs = context.Stackholder.FirstOrDefault(c => c.StackholderID == stackholderId);
            var inst = crs.Commesse.FirstOrDefault(i => i.CommessaID == commessaId);
            if (inst == null)
                crs.Commesse.Add(context.Commessa.Single(i => i.CommessaID == commessaId));
        }
    }
}
