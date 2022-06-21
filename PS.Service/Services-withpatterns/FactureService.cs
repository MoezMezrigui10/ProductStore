using Ps.Domain.Entities;
using PS.Data.Infrastructures;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Service.Services_withpatterns
{
    public class FactureService:Service<Facture>,IFactureService
    {
        public FactureService(IUnitOfWork utk):base(utk)
        {

        }
    }
}
