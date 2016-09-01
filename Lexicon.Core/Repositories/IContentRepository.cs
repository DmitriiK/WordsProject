using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lexicon.Core.Entities;

namespace Lexicon.Core.Repositories
{
    public interface IContentRepository
    {
        CorpusText GetFullContent(int Id);
    }
}
