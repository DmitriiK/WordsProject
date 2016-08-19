using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lexicon.DAL.Entities;

namespace Lexicon.DAL.Interfaces
{
    public interface IContentRepository
    {
        CorpusText GetFullContent(int Id);
    }
}
