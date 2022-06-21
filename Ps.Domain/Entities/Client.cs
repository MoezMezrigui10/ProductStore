using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ps.Domain.Entities
{
    public class Client
    {
        [Key]
        public string CIN { get; set; }
        public DateTime DateNaisssance { get; set; }
        public string Email { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        //prop de navigation
        public virtual IList<Facture> Factures { get; set; }

    }
}
