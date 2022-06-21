using System;
using System.Collections.Generic;
using System.Text;

namespace Ps.Domain.Entities
{
  public  class Chemical :Product
    {
        public Address Address { get; set; }
        public string LabeName { get; set; }
        public override string GetMyType()
        {
            return "CHEMICAL";
        }
        public override string ToString()
        {
            return base.ToString()+" , City : "+Address.City;
        }
    }
}
