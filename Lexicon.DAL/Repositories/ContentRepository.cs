using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lexicon.DAL.Interfaces;
using Lexicon.DAL.Entities;
namespace Lexicon.DAL.Repositories
{
   

    public class ContentRepository: IContentRepository
    {
        LexiconDBContext db;
        public ContentRepository(LexiconDBContext dbcontext)
        { db = dbcontext; }
       public CorpusText GetFullContent(int Id)
        { return db.CorpusTexts.Find(Id); }
    }
}
