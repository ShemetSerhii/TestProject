using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Domain.Entities;
using Services.Interfaces;

namespace Services.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client> _clientRepository;

        public ClientService(IRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Task<IEnumerable<Client>> GetAsync(Expression<Func<Client, bool>> filters = null)
        {
            return _clientRepository.GetAsync(filters);
        }

        public Task<Client> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
