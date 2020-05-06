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
