using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp;
using AngleSharp.Dom.Html;
using System.Diagnostics;
using AngleSharp.Parser.Html;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
namespace Lingva
{
    public class HtmlParscer
    {

        public void LoadFreqListFromSite()
        {

            var lst = ParseProjectGutenbergFL().Result.Where(x=>!String.IsNullOrEmpty(x.Word.WordString));
            /**/
            //с сайта приходят дубликаты, поэтому приходитя снова группировать и делать общий ранг
            var groupedList = lst.GroupBy(x => new { x.FrequencyListID, x.Word }).Select(group => new FrequencyListItem { FrequencyListID = group.Key.FrequencyListID, Word = group.Key.Word, Count = group.Sum(x => x.Count) }).OrderBy(y=>y.Count).ToList();
            for (int ind = 0; ind < groupedList.Count; ind++) groupedList[ind].Rank = ind + 1;
            //var words = lst.GroupBy(x => x.Word).Select(w => new Word { WordString = w.First().Word.WordString }).ToList();           

             using (EFDBContext cont = new EFDBContext())
            {
                //cont.Configuration.AutoDetectChangesEnabled = false;
                var ll = cont.Words.ToLookup(x=>x.WordString.ToLower(), x=>x.WordID);
                var testcnt = 0;
                foreach (var fi in groupedList)
                {
                    testcnt++;
                    var llw =ll[fi.Word.WordString.ToLower()];
                    if (llw.Count()==0)
                    {
                        cont.Words.Add(fi.Word);
                        cont.SaveChanges();
                        fi.WordID = fi.Word.WordID;//note - !!? why does'n it track this
                    }
                    else fi.WordID = llw.FirstOrDefault();
                    fi.Word = null; //todo разобраться как правильно сохранять значения с navigation propery
                }
                cont.FrequencyListItems.AddRange(groupedList);
               // cont.ChangeTracker.DetectChanges();
                cont.SaveChanges();
            }
        }
        public async Task<List<FrequencyListItem>> ParseProjectGutenbergFL()
        {
            var lst = new List<FrequencyListItem>();
            var urls = new List<string>();

            var ulrTemplate = @"https://en.wiktionary.org/wiki/Wiktionary:Frequency_lists/PG/2006/04/{0}-{1}";//   @"https://en.wiktionary.org/wiki/Wiktionary:Frequency_lists/TV/2006/{0}-{1}"; 


            for (int ten_th = 0; ten_th < 4; ten_th++)
            {
                var url = string.Format(ulrTemplate, ten_th * 10000 + 1, (ten_th + 1) * 10000);
                urls.Add(url);
            }



            foreach (var url in urls)
            {

                var config = Configuration.Default.WithDefaultLoader();
                var context = BrowsingContext.New(config);
                var document = await context.OpenAsync(url);
                //var div = document.All.Where(x => x.Id == "mw-content-text").ToList();
                var tableElements = document.All.Where(x => x.LocalName == "table");

                foreach (IHtmlTableElement tableElement in tableElements)
                {
                    // var tableRows = tableElement.Children.Where(m => m.LocalName == "tr");
                    foreach (IHtmlTableRowElement row in tableElement.Rows)
                    {
                        if (row.Index == 0)
                        {
                            if (row.Cells[0].TextContent.Trim().ToLower() != "rank" || row.Cells[1].TextContent.Trim().ToLower() != "word" || !row.Cells[2].TextContent.Trim().ToLower().Contains("count"))
                                throw new ApplicationException("wrong table format");
                            continue;
                        }
                        var rank = int.Parse(row.Cells[0].TextContent);
                        var word = row.Cells[1].TextContent.Trim();
                        if (word.Contains(" or "))
                            word = word.Substring(0, word.IndexOf(" or "));
                        var cntstr = row.Cells[2].TextContent;
                        var cnt = decimal.Parse(Regex.Match(cntstr, @"^\d+").ToString());
                        lst.Add(new FrequencyListItem { FrequencyListID = 1, Rank = rank, Word = new Word { WordString = word}, Count = cnt });
                    }

                    //var tst = lst.Where(x => x.Word == "quartermaine").FirstOrDefault();
                    //if (tst == null;)  continue;    

                }
            }

            return lst;
        }
    }
}

