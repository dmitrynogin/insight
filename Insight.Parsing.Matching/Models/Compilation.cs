using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Insight.Parsing.Matching.Models
{
    delegate bool ExpressionDelegate(Predicate<string> capture, Predicate<string> label);
    
    static class Compilation
    {
        static ConcurrentDictionary<string, ExpressionDelegate> Expressions { get; } =
            new ConcurrentDictionary<string, ExpressionDelegate>();

        public static ExpressionDelegate Compile(this string pattern) =>
            Expressions.GetOrAdd(
                string.Join(" ", pattern.Tokenize()),
                e => CreateFunction(e));

        static readonly Regex Regex = new Regex(@"([\|\&\(\)\!])", RegexOptions.Compiled);
        static IEnumerable<string> Tokenize(this string text) =>
            Regex
                .Split(text)
                .Select(t => t.Trim())
                .Where(t => !string.IsNullOrWhiteSpace(t))
                .Select(t =>
                {
                    switch (t)
                    {
                        case "(":
                        case ")":
                        case "!":
                            return t;
                        case "&":
                            return "&&";
                        case "|":
                            return "||";
                        default:
                            if (t.StartsWith("{") && t.EndsWith("}"))
                                return $"label(\"{t.Trim('{', '}')}\")";
                            else
                                return $"capture(\"{t}\")";
                    }
                });

        static ExpressionDelegate CreateFunction(string expression)
        {
            var ns = "Expression" + Guid.NewGuid().ToString().Replace("-", "");
            var code =
                @"using System;
                namespace " + ns + @"
                {
                    public class Functions
                    {
                        public static bool Function(Predicate<string> capture, Predicate<string> label)
                        {  
                            return " + expression + @";
                        }
                    }
                }";

            var provider = new CSharpCodeProvider();
            var parameters = new CompilerParameters { GenerateInMemory = true, GenerateExecutable = false };
            var results = provider.CompileAssemblyFromSource(parameters, code);
            if (results.Errors.Count > 0)
                throw new FormatException(string.Join("\n", from e in results.Errors.OfType<CompilerError>()
                                                            select e.ErrorText));

            var function = results.CompiledAssembly.GetType(ns + ".Functions").GetMethod("Function");
            return (ExpressionDelegate)Delegate.CreateDelegate(typeof(ExpressionDelegate), function);
        }
    }
}
