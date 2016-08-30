using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using AngleSharp.Dom.Events;
using AngleSharp.Dom.Html;
using AngleSharp.Dom;
using AngleSharp.Extensions;
using AngleSharp.Services.Media;
using AngleSharp;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lingva;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
     
        public void TestMethod1()
        {
            var tl = new TextLoader();
            tl.TraversePath(@"D:\MY_DOCS\American Nation Corpus\masc_500k_texts", 1);
        }

  
        public void TestLoadFreqLstFromSite()
        {
            var x = new HtmlParscer();
            x.LoadFreqListFromSite();

        }
[TestMethod]
        public void TestLoadFreqLstFromTextFile()
        {
            var x = new TextLoader();
            x.LoadFreqListFromText(@"D:\MY_DOCS\from e-libs\The Lost Symbol.txt",2);

        }


        public async Task TestParseURl()
        {
            var address = "https://en.wiktionary.org/wiki/Wiktionary:Frequency_lists/TV/2006/1-1000";
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address);
            //var div = document.All.Where(x => x.Id == "mw-content-text").ToList();
            var tableElement = (document.All.Where(x => x.LocalName == "table").FirstOrDefault()) as IHtmlTableElement;
            // var tableRows = tableElement.Children.Where(m => m.LocalName == "tr");
            foreach (IHtmlTableRowElement row in tableElement.Rows)
            {
                if (row.Index==0)
                {
                    if (row.Cells[0].TextContent.Trim().ToLower() != "rank" || row.Cells[1].TextContent.Trim().ToLower() != "word" || row.Cells[2].TextContent.Trim().ToLower() != "count")
                        throw new ApplicationException("wrong table format");
                    continue;
                }
                var rank = int.Parse(row.Cells[0].TextContent);
                var word = row.Cells[1].TextContent.Trim();
                var cntstr = row.Cells[2].TextContent;
                var cnt=int.Parse(Regex.Match(cntstr, @"^\d+").ToString());
            }



        }
        public async Task ContextFormSubmission()
        {
             var address = "http://anglesharp.azurewebsites.net/PostUrlEncodeNormal";
                var config = Configuration.Default.WithDefaultLoader();
                var context = BrowsingContext.New(config);
                var document = await context.OpenAsync(address);

                Assert.AreEqual(1, document.Forms.Length);

                var form = document.Forms[0];
                var name = form.Elements["Name"] as IHtmlInputElement;
                var number = form.Elements["Number"] as IHtmlInputElement;
                var isactive = form.Elements["IsActive"] as IHtmlInputElement;

                Assert.IsNotNull(name);
                Assert.IsNotNull(number);
                Assert.IsNotNull(isactive);
                Assert.AreEqual("text", name.Type);
                Assert.AreEqual("number", number.Type);
                Assert.AreEqual("checkbox", isactive.Type);

                name.Value = "Test";
                number.Value = "1";
                isactive.IsChecked = true;
                var result = await form.SubmitAsync();

                Assert.IsNotNull(result);
                Assert.AreEqual(result, context.Active);
                Assert.AreEqual("okay", context.Active.Body.TextContent);
            }
       
    }
}
