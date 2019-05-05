using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<ClientTask>> GetTasksAsync(int clientId);

        Task<ClientTask> GetAsync(int id);

        Task CreateAsync(ClientTask task);

        Task UpdateAsync(ClientTask task);

        Task DeleteAsync(int id);
    }
}
