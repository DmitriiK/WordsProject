using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  Microsoft.AspNet.Identity.EntityFramework;

namespace Lexicon.DAL.Entities.AuthentificationEntities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
