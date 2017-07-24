using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pantelejci_1._1.Models
{   
    public enum pozicija { golman, odbrana, sredina, napad }

    public class Igrac
    {

        public int ID { get; set; }
        [Required]
        [DisplayName("Ime")]
        public string ime { get; set; }
        [Required]
        [DisplayName("Prezime")]
        public string prezime { get; set; }
        [Required]
        [DisplayName("Datum rodjenja")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime godinaRodjenja { get; set; }
        [Required]
        public pozicija Pozicija { get; set; }
        [Required]
        [Range(1, 99, ErrorMessage = "Broj dresa mora biti izmedju 1 i 99")]
        [DisplayName("Broj dresa")]
        public int brojDresa { get; set; } // id = brojDresa u istom timu

        [Required]
        public string SlikaIgraca { get; set; }

        public virtual Klub Klub { get; set; }
        public virtual ICollection<Utakmica> Utakmica { get; set; }
    }
}