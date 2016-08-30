using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using Lexicon.DAL.Entities.AuthentificationEntities;
namespace Lexicon.DAL.Interfaces.AuthentificationInterFaces
{
   
        public interface IUnitOfWork : IDisposable
        {
            ApplicationUserManager UserManager { get; }
            IClientManager ClientManager { get; }
            ApplicationRoleManager RoleManager { get; }
            Task SaveAsync();
        }
    }

