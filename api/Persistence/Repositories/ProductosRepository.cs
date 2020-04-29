using api.Persistence.Repositories;
using Core.Domain;
using Core.Repositories;

namespace Persistence.Repositories
{
    class ProductosRepository : Repository<Productos>, IProductosRepository
    {
        public ProductosRepository(PasadenaAppContext context) : base(context)
        {

        }

        public PasadenaAppContext PasadenaAppContext
        {
            get { return Context as PasadenaAppContext; }
        }
    }
}
