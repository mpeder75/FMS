using System.Data;

namespace ExitslipService.Application.UnitOfWork;

public interface IUnitOfWork
{
    void Commit();

    void Rollback();

    void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Serializable);
}