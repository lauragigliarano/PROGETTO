using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROGETTO.ViewModels
{
    public class AssignedStackholderData
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Numero rilevamento")]
        [Required]
        public int RilevamentoID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data rilevamento")]
        public DateTime DataRilevamento { get; set; }
        [Range(1,5)]
        public int Interesse { get; set; }
        [Range(1, 5)]
        public int Potere { get; set; }
        [Range(1, 5)]
        public int Impatto { get; set; }

        public string Note { get; set; }
    }
}