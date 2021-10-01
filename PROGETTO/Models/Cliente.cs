﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROGETTO.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID")]
        public int ClienteID { get; set; }

        [StringLength(50)]
        [Display(Name = "Ragione Sociale")]
        public string RagioneSociale { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        [StringLength(50)]
        public string Mail { get; set; }

        public virtual ICollection<Commessa> Commesse { get; set; }
    }
}