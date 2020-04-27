﻿using System;
using System.Collections.Generic;
using System.Text;
using Core;
using Core.Repositories;
using Persistence.Repositories;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PasadenaAppContext _context;

        public UnitOfWork(PasadenaAppContext context)
        {
            _context = context;
            Departamentos = new DepartamentosRepository(_context);
        }

        public IDepartamentosRepository Departamentos { get; private set; }

        IDepartamentosRepository IUnitOfWork.Departamentos => throw new NotImplementedException();

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
