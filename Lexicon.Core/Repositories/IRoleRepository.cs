using Lexicon.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace  Lexicon.Core.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role FindByName(string roleName);
        Task<Role> FindByNameAsync(string roleName);
        Task<Role> FindByNameAsync(CancellationToken cancellationToken, string roleName);
    }
}

