using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pantelejci_1._1.Models
{
    public class Stadion
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Naziv stadiona")]
        public string naziv { get; set; }
        [Required]
        [DisplayName("Grad")]
        public string grad { get; set; }



        public virtual ICollection<Klub> Klub { get; set; }
        // vise klubova moze u jedan stadion
    }
}