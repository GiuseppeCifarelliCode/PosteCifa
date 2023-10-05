using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PosteCifa.Models
{
    public class AggiornamentoSpedizione
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Lo Stato attuale è obbligatorio")]
        [Display(Name = "Stato")]
        public string State { get; set; }
        [Required(ErrorMessage = "La citta' attuale è obbligatoria")]
        [Display(Name = "Citta'")]
        public string City { get; set; }
        [Required(ErrorMessage = "La descrizione è obbligatoria")]
        [Display(Name = "Descrizione")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Un aggiornamento è obbligatorio")]
        [Display(Name = "Aggiornamento")]
        public DateTime Update { get; set; }
        [Required(ErrorMessage = "Il codice di Spedizione è obbligatorio")]
        [Display(Name = "Codice Spedizione")]
        public int IdSpedizione { get; set; }

        public AggiornamentoSpedizione() { }
        public AggiornamentoSpedizione( string state, string city, string description, DateTime update, int idSpedizione)
        {
            State = state;
            City = city;
            Description = description;
            Update = update;
            IdSpedizione = idSpedizione;
        }
    }
}