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


        public void SaveFI(IList<FrequencyListItem> li)

        {
            //cont.Configuration.AutoDetectChangesEnabled = false;
            var ll = Words.ToLookup(x => x.WordString.ToLower(), x => x.WordID);
            var testcnt = 0;
            foreach (var fi in li)
            {
                testcnt++;
                var llw = ll[fi.Word.WordString.ToLower()];
                if (llw.Count() == 0)
                {
                    Words.Add(fi.Word);
                    SaveChanges();
                    fi.WordID = fi.Word.WordID;//note - !!? why does'n it track this
                }
                else fi.WordID = llw.FirstOrDefault();
                fi.Word = null; //todo разобраться как правильно сохранять значения с navigation propery
            }
           
            FrequencyListItems.AddRange(li);
            // cont.ChangeTracker.DetectChanges();
            SaveChanges();
        }
    }
}
