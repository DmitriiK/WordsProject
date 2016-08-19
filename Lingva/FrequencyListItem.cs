using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lingva
{
 public   class FrequencyListItem
    {
      
        public int FrequencyListItemID { get; set; }
        public int FrequencyListID { get; set; }
        public int  Rank{ get; set; }
        public string Word { get; set; }
        public decimal Count { get; set; }
    }
}
