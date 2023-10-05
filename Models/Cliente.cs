using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PosteCifa.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Il nome è obbligatorio")]
        [Display(Name ="Nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Il cognome è obbligatorio")]
        [Display(Name = "Cognome")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "La Data di Nascita è obbligatoria")]
        [Display(Name = "Data di Nascita")]
        public DateTime BirthDay { get; set; }
        [Required(ErrorMessage = "Il Codice Fiscale è obbligatorio")]
        [Display(Name = "Codice Fiscale")]
        public string CF { get; set; }
        public Cliente () { }
        public Cliente( string name, string surname, DateTime birthDay, string cF)
        {
            Name = name;
            Surname = surname;
            BirthDay = birthDay;
            CF = cF;
        }
    }
}