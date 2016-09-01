using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lexicon.Core.Repositories;
using Lexicon.Core.Entities;
namespace Lexicon.Data.EntityFramework.Repositories
{
   

    internal class ContentRepository: IContentRepository
    {
        ApplicationDbContext  db;
        public ContentRepository(ApplicationDbContext dbcontext)
        { db = dbcontext; }
       public CorpusText GetFullContent(int Id)
        { return db.CorpusTexts.Find(Id); }
    }
}
