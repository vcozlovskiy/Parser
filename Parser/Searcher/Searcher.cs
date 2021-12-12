using Parser.ITextElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser.TextElements;

namespace Parser.StaticSearcher
{
    class Searcher
    {
        private IEnumerable<ILine> Words;
        private IText text;
        private IEnumerable<ILine> wordsContiner;

        public Searcher(IText text)
        {
            this.text = text;
            
            Words = new List<ILine>();
        }

        private void GetAllWords()
        {
            StringBuilder stringBuilder = new StringBuilder();

            text.Pages.ToList().ForEach((x) => stringBuilder.Append(x.ToString()));

            List<string> words = stringBuilder.ToString().Split(' ', ',','.', '\n',
                '\r',':',';','(',')','?','!', '“', '’').ToList();

            var wordsTrimd = words.Where(
                (word) => !string.IsNullOrEmpty(word) && !int.TryParse(word, out int g));

            wordsTrimd.ToList().ForEach((word) => Words = Words.Append(new Line(word)));
        }

        public void SortByAlphabet()
        {
            GetAllWords();
            IEnumerable<ILine> sortedWords = Words.OrderBy((word) => word.Words.First()).ToList();
            Words = sortedWords;
        }
        
        private int CountOccurrence(string searcheblyWord)
        {
            Line searcheblyLine = new Line(searcheblyWord);
            return  Words.Where((word) => word.Words.First() == searcheblyWord).Count();
        }

        public void WordsRepeats()
        {
            var wordWithoutRepeats = Words.GroupBy((word) => word.Words.First()).Select(g => new { Word = g.Key, Count = g.Count() });
            Words = Words.GroupBy((word) => word.Words.First()).Select(g => new Line(g.Key.Trim())).ToList();


            List<ILine> wordRepeatsConut = new List<ILine>();

            wordWithoutRepeats.ToList().ForEach((word) => wordRepeatsConut.Add(new Line(word.Word + " ... " + word.Count)));

            wordsContiner = wordRepeatsConut;
        }

        public string FindWordInLines(string seacheblyWord)
        {
            Line seacheblyLine = new Line(seacheblyWord);
            StringBuilder stringBuilder = new StringBuilder();
            List<int> indexArray = new List<int>();

            int index = 0;
            foreach (IPage page in text.Pages)
            {
                foreach (ILine line1 in page.Lines)
                {
                    index++;
                    
                    foreach(string word in line1.Words)
                    {
                        if (word == seacheblyLine.Words.First())
                        {
                            indexArray.Add(index);
                        }
                    }
                }
            }

            var i = indexArray.GroupBy((index) => index).Select((s) => s.Key);

            foreach (var w in i)
            {
                stringBuilder.Append(w.ToString() + " ");
            }

            return stringBuilder.ToString();
        }

        public void WordsShow()
        {
            int index = 0;
            List<ILine> s = Words.ToList();

            foreach (ILine line in wordsContiner)
            {
                Console.WriteLine(line + ":" + FindWordInLines(s[index].Words.First()));
                index++;
            }
        }
    }
}
