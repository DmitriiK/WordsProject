using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon.DAL.Entities
{
    public class CorpusText
    {
       public int CorpusTextID { get; set; }
        public int CorpusID { get; set; }
        public string HierarchyPath { get; set; }
        public string TextData { get; set; }

    }
}

