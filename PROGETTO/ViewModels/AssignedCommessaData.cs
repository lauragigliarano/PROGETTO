using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROGETTO.ViewModels
{
    public class AssignedCommessaData
    {

        public int CommessaID { get; set; }

        public string Descrizione { get; set; }


        public DateTime DataInizio { get; set; }

        public DateTime DataFine { get; set; }


        public float Importo { get; set; }

        public bool Assigned { get; set; }
    }
}