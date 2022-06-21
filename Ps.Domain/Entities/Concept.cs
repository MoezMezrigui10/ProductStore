using System;
using System.Collections.Generic;
using System.Text;

namespace Ps.Domain.Entities
{
    public abstract class  Concept
    {
        public abstract string GETDetails();
        public virtual string GetDetails2()
        {
            return "this is concept class !";
        }

    }
}
