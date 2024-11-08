﻿using System.Threading.Tasks;
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
            Usuarios = new UsuariosRepository(_context);
            Productos = new ProductosRepository(_context);
            Documents = new DocumentsRepository(_context);
        }

        public IDepartamentosRepository Departamentos { get; private set; }
        public IUsuariosRepository Usuarios { get; private set; }
        public IProductosRepository Productos { get; private set; }
        public IDocumentsRepository Documents { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
