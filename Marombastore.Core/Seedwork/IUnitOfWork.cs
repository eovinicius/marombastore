namespace Marombastore.Core.Seedwork;

public interface IUnitOfWork : IDisposable
{
    Task Commit();
    Task Rollback();
}