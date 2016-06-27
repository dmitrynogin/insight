using Infra.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.IO
{
    public class SearchPath : Enumerable<SearchPath>
    {        
        public static implicit operator SearchPath(string text) => new SearchPath(text);
        public static implicit operator string(SearchPath path) => path.ToString();
        public static readonly SearchPath Root = new SearchPath(string.Empty);

        public SearchPath(string text)
            : this(text.Split('/')
                  .Select(s => s.Trim())
                  .Where(s => !string.IsNullOrWhiteSpace(s)))
        {
        }

        SearchPath(IEnumerable<string> directories)
        {
            Directories = directories;
        }

        public override IEnumerator<SearchPath> GetEnumerator()
        {
            for (var path = this; !path.IsRoot; path = path.Up())
                yield return path;
                
            yield return Root;
        }

        bool IsRoot => !Directories.Any();
        SearchPath Up() => new SearchPath(Directories.Reverse().Skip(1).Reverse());

        public override string ToString() => string.Join("/", Directories);
        IEnumerable<string> Directories { get; }
    }
}
