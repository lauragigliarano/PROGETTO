using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PROGETTO.Models
{
    public class Commessa
    {
        [Display(Name = "Commessa")]
        public int CommessaID { get; set; }
        public string Descrizione { get; set; }
        public int ClienteID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Inizio")]
        public DateTime DataInizio { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Fine")]
        public DateTime DataFine { get; set; }

        //public virtual Cliente Cliente { get; set; }
    }
}