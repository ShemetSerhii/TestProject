using System.Threading.Tasks;
using Domain.Entities;

namespace DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Client> ClientRepository { get; }

        IRepository<ClientTask> TaskRepository { get; }

        Task SaveAsync();
    }
}