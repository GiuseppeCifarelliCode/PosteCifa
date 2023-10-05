using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PosteCifa.Models
{
    public class Azienda
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Il Nominativo è obbligatorio")]
        public string Nominativo { get; set; }
        [Required(ErrorMessage = "La Ragione Sociale è obbligatoria")]
        [Display(Name = "Ragione Sociale")]
        public string RagioneSociale { get; set; }
        [Required(ErrorMessage = "La Partita Iva è obbligatoria")]
        [Display(Name = "Partita IVA")]
        public string PartitaIVA { get; set; }

        public Azienda() { }
        public Azienda( string nominativo, string ragioneSociale, string partitaIVA)
        {
            Nominativo = nominativo;
            RagioneSociale = ragioneSociale;
            PartitaIVA = partitaIVA;
        }
    }
}