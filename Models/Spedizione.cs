using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PosteCifa.Models
{
    public class Spedizione
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La Data Spedizione è obbligatoria")]
        [Display(Name = "Data di Spedizione")]
        public DateTime DataSpedizione { get; set; }
        [Required(ErrorMessage = "Il peso è obbligatorio")]
        [Display(Name = "Peso")]
        public double Weight { get; set; }
        [Required(ErrorMessage = "La Destinazione è obbligatorio")]
        [Display(Name = "Destinazione")]
        public string Destination { get; set; }
        [Required(ErrorMessage = "L'indirizzo è obbligatorio")]
        [Display(Name = "Indirizzo")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Il nome del Destinatario è obbligatorio")]
        public string Destinatario { get; set; }
        [Required(ErrorMessage = "Il Prezzo è obbligatorio")]
        [Display(Name = "Prezzo")]
        public double Price { get; set; }
        [Required(ErrorMessage = "La Data Consegna è obbligatorio")]
        [Display(Name = "Data di Consegna")]
        public DateTime DataConsegna { get; set; }
        [Required(ErrorMessage = "Il Codice ID del Cliente è obbligatorio")]
        [Display(Name = "Codice Cliente")]
        public int IdCliente { get; set; }

        public Spedizione() { }
        public Spedizione(DateTime dataSpedizione, double weight, string destination, string address, string destinatario, double price, DateTime dataConsegna)
        {
            DataSpedizione = dataSpedizione;
            Weight = weight;
            Destination = destination;
            Address = address;
            Destinatario = destinatario;
            Price = price;
            DataConsegna = dataConsegna;
        }
    }
}