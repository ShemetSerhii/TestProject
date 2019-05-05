using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAsync(
            Expression<Func<Client, bool>> filters = null);

        Task<Client> GetAsync(int id);
    }
}