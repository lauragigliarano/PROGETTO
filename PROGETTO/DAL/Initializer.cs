using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PROGETTO.Models;

namespace PROGETTO.DAL
{
    public class Initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            var cliente = new List<Cliente>
            {
            new Cliente{ClienteID=1159,RagioneSociale="Easynet S.p.A.", Telefono="0341-256911", Mail = "info@enet.it"},
            new Cliente{ClienteID=1139,RagioneSociale="Enel Italia S.p.a.", Telefono="0341-222211", Mail = "info@enei.it"},
            new Cliente{ClienteID=1149,RagioneSociale="Enel Energia S.p.a.", Telefono="0341-256333", Mail = "info@enen.it"}
            };

            cliente.ForEach(s => context.Cliente.Add(s));
            context.SaveChanges();

            var commessa = new List<Commessa>
            { 
            new Commessa{CommessaID=1050,Descrizione="Cablaggio",ClienteID=1149,DataInizio=DateTime.Parse("2006-03-01"),DataFine=DateTime.Parse("2006-03-01") }
            };
            commessa.ForEach(s => context.Commessa.Add(s));
            context.SaveChanges();
        }
    }
}