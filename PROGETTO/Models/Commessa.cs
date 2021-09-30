using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROGETTO.Models
{
    public class Commessa
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Commessa")]
        public int CommessaID { get; set; }
        public string Descrizione { get; set; }
        [Display(Name = "Cliente")]
        public int ClienteID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Inizio")]
        public DateTime DataInizio { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Fine")]
        public DateTime DataFine { get; set; }
        public decimal Importo { get; set; }
        public virtual Cliente Cliente { get; set; }

    }
}