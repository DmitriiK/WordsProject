using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Lexicon.DAL.Entities;
namespace Lexicon.DAL
{
  public  class LexiconDBContext : DbContext
    {

        public LexiconDBContext()
            :base("LingvaDB")
        { }

        public DbSet<CorpusText> CorpusTexts { get; set; }
    }
}
