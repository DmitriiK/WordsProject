using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Lingva
{
 public   class FrequencyListItem
    {
      
        public int FrequencyListItemID { get; set; }
        public int FrequencyListID { get; set; }
        public int  Rank{ get; set; }
        [ForeignKey("Word")]
        public int WordID { get; set; }
        public Word Word { get; set; }
        public decimal Count { get; set; }
    }
    public class Word
    {

        [Key]
        public int WordID { get; set; }
        [NotMapped]
        public int LemmaID { get; set; }
        public string WordString { get; set; }

    }
    public static class FrequencyListItemExt
    {
        public static IList<FrequencyListItem> ReRank(this IList<FrequencyListItem> lst)
        {
            var ordLst = lst.OrderByDescending(x => x.Count).ToList();
            var ind = 0;
            foreach (var fi in ordLst)
            {
                ind++;
                fi.Rank = ind;
            }
            return ordLst;
        }

    }
}
