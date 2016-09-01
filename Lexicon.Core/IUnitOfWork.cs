using Lexicon.Core.Repositories;
using Lexicon.Core.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lexicon.Core
{
    public interface IUnitOfWork : IDisposable
    {
        #region Properties
        IContentRepository ContentRepository { get; }
        IExternalLoginRepository ExternalLoginRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }
        #endregion

        #region Methods
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        #endregion
    }
}
