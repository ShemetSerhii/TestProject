using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Domain.Entities;
using Services.Interfaces;

namespace Services.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<ClientTask>> GetTasksAsync(int clientId)
        {
            var tasks = _unitOfWork.TaskRepository.GetAsync(
                task => task.ClientId == clientId);

            return tasks;
        }

        public Task<ClientTask> GetAsync(int id)
        {
            return _unitOfWork.TaskRepository.FindAsync(id);
        }

        public async Task CreateAsync(ClientTask task)
        {
            await _unitOfWork.TaskRepository.CreateAsync(task);

            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(ClientTask task)
        {
            _unitOfWork.TaskRepository.Update(task);

            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.TaskRepository.Delete(id);

            await _unitOfWork.SaveAsync();
        }
    }
}
