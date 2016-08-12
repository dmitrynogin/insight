using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Parsing
{
    public class Dictionary 
    {
        public static Dictionary Empty = new Dictionary(new string[0]);

        public Dictionary(IEnumerable<string> words)
        {
            Indecies = words
                .Select((i, t) => new { t, i })
                .ToDictionary(x => x.i, x => x.t);
        }

        public int Length => Indecies.Count;

        public double[] Vectorize(IEnumerable<Word> words)
        {
            var vector = new double[Indecies.Count];
            foreach (var word in words)
            {
                int index;                
                if (Indecies.TryGetValue(word.Stemmed, out index) || Indecies.TryGetValue(word.Nonstemmed, out index))
                    vector[index]++;
            }

            var wordCount = words.Count();
            if (wordCount > 0)
                for (int i = 0; i < vector.Length; i++)
                    vector[i] /= wordCount;

            return vector;
        }

        public void WriteTo(TextWriter writer)
        {
            foreach (var word in Indecies.Keys)
                writer.WriteLine(word);
        }

        Dictionary<string, int> Indecies { get; }
    }
}
