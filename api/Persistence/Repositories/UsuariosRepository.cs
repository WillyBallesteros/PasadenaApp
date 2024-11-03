using Core.Domain;
using Core.Repositories;

namespace Persistence.Repositories
{
    public class UsuariosRepository : Repository<Usuarios>, IUsuariosRepository
    {
        public UsuariosRepository(PasadenaAppContext context) : base(context)
        {

        }

        public PasadenaAppContext PasadenaAppContext
        {
            get { return Context as PasadenaAppContext; }
        }
    }
}
