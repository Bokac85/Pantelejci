using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pantelejci_1._1.Models
{
    public class Klub
    {

        public int ID { get; set; }
        [Required]
        [DisplayName("Naziv")]
        public string naziv { get; set; }
        [Required]
        [DisplayName("Grad")]
        public string grad { get; set; }
        [Required]
        [DisplayName("Godina osnivanja")]
        public int godinaOsnivanja { get; set; }

        //[Required]
        public string SlikaKluba { get; set; }

        public virtual Stadion Stadion { get; set; }

        public virtual ICollection<Igrac> Igrac { get; set; }
        //ovo se kuca u klasi gde je 1 a ide ka N (vise igraca)

        public virtual ICollection<ApplicationUser> User { get; set; }
    }
}