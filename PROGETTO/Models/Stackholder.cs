using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROGETTO.Models
{
    public class Stackholder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StackholderID { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(50)]
        public string Cognome { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        [StringLength(20)]
        public string Cellulare { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        public string Mail { get; set; }

        public string Note { get; set; }

        public virtual ICollection<Commessa> Commesse { get; set; }
    }
}