using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ps.Domain.Entities
{
    public class Facture
    {
        public float Prix { get; set; }
        public DateTime DateAchat { get; set; }
        public int ProductFK { get; set; }
        public string ClientFK { get; set; }

        // prop de navigation
        [ForeignKey("ClientFK")]
        public virtual Client Client { get; set; }
        [ForeignKey("ProductFK")]
        public virtual Product Product { get; set; }
    }
}
