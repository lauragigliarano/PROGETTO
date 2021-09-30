using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROGETTO.Models
{
    public class Cliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID")]
        public int ClienteID { get; set; }
        [Display(Name = "Ragione Sociale")]
        public string RagioneSociale { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }

        //public virtual ICollection<Commessa> Commessa { get; set; }
    }
}