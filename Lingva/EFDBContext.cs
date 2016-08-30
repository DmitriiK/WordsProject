using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Lingva
{
  public  class EFDBContext:DbContext
    {

        public EFDBContext()
            :base("LingvaDB")
        { }

        public DbSet<FrequencyListItem> FrequencyListItems { get; set; }
        public DbSet<Word> Words { get; set; }
    }
}
