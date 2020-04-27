using System;
using System.Collections.Generic;
using System.Text;
using api.Persistencia.Repositories;

namespace Persistencia.Repositories
{
    public class DepartamentosRepository : Repository<Departamentos>, IDepartamentosRepository
    {
        public DepartamentosRepository(PasadenaAppContext context) : base(context) 
        {

        }

        public PasadenaAppContext PasadenaAppContext
        {
            get { return Context as PasadenaAppContext; }
        }
    }

    
}
