using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rodjenihm.Slagalica
{
    public sealed class WordList
    {
        private static readonly Lazy<WordList> lazy = new Lazy<WordList>(() => new WordList());
        public static WordList Instance { get { return lazy.Value; } }
        public IEnumerable<string> Words { get; }

        private WordList()
        {
            Words = LoadWords();
        }

        private IEnumerable<string> LoadWords()
        {
            List<string> dictionary;
            using (var fileStream = new FileStream(ConfigurationManager.AppSettings["dictionaryPath"], FileMode.Open, FileAccess.Read))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    var dictionarySize = int.Parse(streamReader.ReadLine());
                    dictionary = new List<string>(dictionarySize);
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        dictionary.Add(line);
                    }
                }
            }
            return dictionary;
        }
    }
}
