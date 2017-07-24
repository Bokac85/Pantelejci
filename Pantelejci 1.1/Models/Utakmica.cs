using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pantelejci_1._1.Models
{
    public enum StatusUtakmice
    {
        Nije_pocela,
        U_toku,
        Zavrsena,
    }

    public class Utakmica
    {

        public int ID { get; set; }
        [DisplayName("Termin odigravanja utakmice")]

        public DateTime vremeUtakmice { get; set; }
        [Required]
        [DisplayName("Status")]
        public StatusUtakmice StatusUtakmice { get; set; }

        public virtual Klub Domacin { get; set; }
        public virtual Klub Gost { get; set; }

        public virtual ICollection<Igrac> Igrac { get; set; }
        public virtual ICollection<Pogodak> Pogoci { get; set; }

    }
}