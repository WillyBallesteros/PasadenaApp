﻿using System;
using System.Collections.Generic;
using System.Text;
using api.Persistence.Repositories;
using Core.Domain;
using Core.Repositories;

namespace Persistence.Repositories
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