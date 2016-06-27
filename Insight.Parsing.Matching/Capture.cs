using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Parsing.Matching
{
    public class Capture 
    {
        public Capture(string text, IStemmer stemmer)
            : this(text
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(w => Word.Keyword(w, stemmer)))
        {
        }

        public Capture(IEnumerable<Word> keywords)
        {
            Keywords = keywords;
        }

        public bool Test(Document document)
        {
            var k = Keywords.GetEnumerator();
            var w = document.Words.GetEnumerator();

            if (!k.MoveNext())
                return true;

            while (true)
            {
                while (true)
                {
                    if (!w.MoveNext())
                        return false;

                    if (k.Current.Equals(w.Current))
                        break;
                }

                while(true)
                {
                    if (k.Current == Word.Any)
                    {
                        if (!k.MoveNext())
                            return true;

                        if (k.Current == Word.Any)
                            continue;

                        while (!k.Current.Equals(w.Current))
                            if (!w.MoveNext())
                                return false;

                        continue;
                    }

                    if (!k.MoveNext())
                        return true;

                    if (!w.MoveNext())
                        return false;
                                       
                    if (!k.Current.Equals(w.Current))
                        return false;
                }
            }
        }

        IEnumerable<Word> Keywords { get; }
    }   
}
