using System.Threading.Tasks;
using Core.Repositories;

namespace Core
{
    public interface IUnitOfWork
    {
        IDepartamentosRepository Departamentos { get; }
        IUsuariosRepository Usuarios { get; }
        IProductosRepository Productos { get; }
        IDocumentsRepository Documents { get; }
        int Complete();
        Task<int> SaveChangesAsync();

    }
}
