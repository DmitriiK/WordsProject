using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
namespace Lingva
{
    public class TextLoader
    {
        string CS = ConfigurationManager.ConnectionStrings["LingvaDB"].ConnectionString;
        public void TraversePath(string path, int CorpusID)
        {
            var fs = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);



            foreach (var f in fs)
            {
                var subpath = f.Substring(path.Length).TrimStart('\\');
                var flTxt = File.ReadAllText(f);
                var words = SplitTextToWords(flTxt);
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    try
                    {
                        using (SqlCommand command = new SqlCommand("INSERT INTO CorpusTexts(CorpusID,HierarchyPath,TextData) VALUES(@CorpusID, @HierarchyPath, @txt)", con))
                        {
                            command.Parameters.Add(new SqlParameter("CorpusID", CorpusID));
                            command.Parameters.Add(new SqlParameter("HierarchyPath", subpath));
                            command.Parameters.Add(new SqlParameter("txt", flTxt));
                            // command.ExecuteNonQuery();
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }

        public string[] SplitTextToWords(string txt)
        {
            Regex reg_exp = new Regex("[^a-zA-Z0-9]");
            txt = reg_exp.Replace(txt, " ");

            // Split the text into words.
            return txt.Split(
                new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);


        }

        public IEnumerable<Tuple<string, int>> CountWordsFromTxt(string path)
        {
            var content = File.ReadAllText(path);
            var lstWords = SplitTextToWords(content);
            decimal dummy;
            var distWords = lstWords.Where(x => !Decimal.TryParse(x, out dummy)).GroupBy(x => x.ToLower()).Select(gr => new Tuple<string, int>(gr.Key, gr.Count()));
            return distWords;
        }

        public void LoadFreqListFromText(string path, int FrLstID)
        {

            var lst = CountWordsFromTxt(path);
            var ordLst = lst.Select(x => new FrequencyListItem { FrequencyListID = FrLstID, Word = new Word { WordString = x.Item1 }, Count = x.Item2 }).ToList().ReRank();

            //var words = lst.GroupBy(x => x.Word).Select(w => new Word { WordString = w.First().Word.WordString }).ToList();           

            using (EFDBContext cont = new EFDBContext())
            {
                cont.SaveFI(ordLst);
            }
        }
    }
}
