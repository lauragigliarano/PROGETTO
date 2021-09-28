using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PROGETTO.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        [Display(Name = "Ragione Sociale")]
        public string RagioneSociale { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }

        //public virtual ICollection<Commessa> Commessa { get; set; }
    }
}