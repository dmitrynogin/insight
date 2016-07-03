using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.IO
{
    public class FileName : ValueObject<FileName>
    {
        public static implicit operator FileName(string text) => new FileName(text);
        public static implicit operator string(FileName fileName) => fileName.ToString();

        public FileName(string text)
        {
            Text = text;
        }

        public override string ToString() => Text;
        public string Name => Path.GetFileNameWithoutExtension(Text);
        public string Extension => Path.GetExtension(Text);
        public string Text { get; }

        public FileName ChangeExtension(string extension) => 
            Path.ChangeExtension(Text, extension);

        protected override IEnumerable<object> EqualityCheckAttributes => new[] { Text };
    }
}
