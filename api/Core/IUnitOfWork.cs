using Core.Repositories;

namespace Core
{
    public interface IUnitOfWork
    {
        IDepartamentosRepository Departamentos { get; }
        int Complete();
    }
}
