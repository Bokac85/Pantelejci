using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Pantelejci_1._1.Models
{
    public class Pogodak
    {
        public int id { get; set; }
        [DisplayName("Vreme pogotka")]
        public int vremePogotka { get; set; }

        public virtual Utakmica Utakmica { get; set; }


    }
}