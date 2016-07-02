using Infra.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public double[] Vectorize(IList<Word> words)
        {
            var vector = new double[Indecies.Count];
            foreach (var word in words.Select(w => w.Stemmed))
            {
                int index;
                if(Indecies.TryGetValue(word, out index))
                    vector[index]++;
            }

            if(words.Count != 0)
                for (int i = 0; i < vector.Length; i++)
                    vector[i] /= words.Count;

            return vector;
        }

        Dictionary<string, int> Indecies { get; }
    }
}
