using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

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
                using (SqlConnection con = new SqlConnection( CS))
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
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '\n' };          
            string[] words = txt.Split(delimiterChars);
            return words;
        }
    }

    }


