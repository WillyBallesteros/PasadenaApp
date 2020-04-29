using Core.Repositories;

namespace Core
{
    public interface IUnitOfWork
    {
        IDepartamentosRepository Departamentos { get; }
        IUsuariosRepository Usuarios { get; }
        IProductosRepository Productos { get; }
        int Complete();
    }
}
