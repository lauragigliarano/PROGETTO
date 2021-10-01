using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROGETTO.Models
{
    public class Commessa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Commessa")]
        [Required]
        public int CommessaID { get; set; }
       
         [StringLength(50)]
        public string Descrizione { get; set; }

        [ForeignKey("Cliente")]
        //[Display(Name = "Cliente")]
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
        public virtual ICollection<Stackholder> Stackholders { get; set; }

    }
}