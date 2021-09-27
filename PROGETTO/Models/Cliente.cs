using System;
using System.Collections.Generic;

namespace PROGETTO.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string RagioneSociale { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }

        public virtual ICollection<Commessa> Commessa { get; set; }
    }
}