using CascadeFlow.Backend.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeFlow.Backend.Application.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByNameAsync(string username);
    }
}
