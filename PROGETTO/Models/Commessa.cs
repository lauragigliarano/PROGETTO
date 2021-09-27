using System;
using System.Collections.Generic;

namespace PROGETTO.Models
{
    public class Commessa
    {
        public int CommessaID { get; set; }
        public string Descrizione { get; set; }
        public int ClienteID { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}