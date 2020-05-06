using Core.Domain;
using Core.Repositories;

namespace Persistence.Repositories
{
    public class DocumentsRepository : Repository<Documents>, IDocumentsRepository
    {
        public DocumentsRepository(PasadenaAppContext context) : base(context)
        {

        }

        public PasadenaAppContext PasadenaAppContext
        {
            get { return Context as PasadenaAppContext; }
        }
    }
}
