using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Insight.Parsing
{
    public static class Stemming
    {
        static readonly Regex Markup = new Regex("<[^<>]+>", RegexOptions.Compiled);
        static readonly Regex Number = new Regex("[0-9]+", RegexOptions.Compiled);
        static readonly Regex HttpAddr = new Regex("(http|https)://[^\\s]*", RegexOptions.Compiled);
        static readonly Regex EmailAddr = new Regex("[^\\s]+@[^\\s]+", RegexOptions.Compiled);
        static readonly Regex Dollar = new Regex("[$]+", RegexOptions.Compiled);
        static readonly Regex Jibberish = new Regex("[^\x30-\x7E]+|[-]", RegexOptions.Compiled);

        public static Word StemWord(this string word, IStemmer stemmer)
        {
            var nonstemmed = word
                .NoMarkup()
                .NoNumbers()
                .NoLinks()
                .NoEmails()
                .NoMoney()
                .NoJibberish()
                .ToLower();

            return new Word(nonstemmed, stemmer.Stem(nonstemmed));
        }

        public static Word[] StemText(this string text, IStemmer stemmer) => 
            text
                .NoMarkup()
                .NoNumbers()
                .NoLinks()
                .NoEmails()
                .NoMoney()
                .NoJibberish()
                .ToLower()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(w => new Word(w, stemmer.Stem(w)))
                .ToArray();
        
        public static string NoMarkup(this string text) =>
            Markup.Replace(text, " ");

        public static string NoNumbers(this string text) =>
            Number.Replace(text, "number");

        public static string NoLinks(this string text) =>
            HttpAddr.Replace(text, "httpAddr");

        public static string NoEmails(this string text) =>
            EmailAddr.Replace(text, "emailAddr");

        public static string NoMoney(this string text) =>
            Dollar.Replace(text, "dollar");

        public static string NoJibberish(this string text) =>
            Jibberish.Replace(text, " ");
    }
}
