using System;
using System.Collections.Generic;
using System.Text;

namespace Ps.Domain.Entities
{
   public class Biological :Product

    {
        public string Herbs { get; set; }
        public override string GetMyType()
        {
            return "BIOLIGICOL";
        }
    }
}
