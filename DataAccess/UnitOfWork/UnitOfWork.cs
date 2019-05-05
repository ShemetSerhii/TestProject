using System;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Repository;
using Domain.Entities;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Client>> _clientRepository;
        private readonly Lazy<IRepository<ClientTask>> _taskRepository;
        
        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            _clientRepository = new Lazy<IRepository<Client>>(() => new Repository<Client>(_context));
            _taskRepository = new Lazy<IRepository<ClientTask>>(() => new Repository<ClientTask>(_context));
        }

        public IRepository<Client> ClientRepository => _clientRepository.Value;

        public IRepository<ClientTask> TaskRepository => _taskRepository.Value;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }        
    }
}
