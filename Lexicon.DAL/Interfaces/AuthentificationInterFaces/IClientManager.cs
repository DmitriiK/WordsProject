using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lexicon.DAL.Entities.AuthentificationEntities;
namespace Lexicon.DAL.Interfaces.AuthentificationInterFaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
    }
}
