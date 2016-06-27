using Insight.Parsing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Insight.Web.Controllers
{
    [RoutePrefix("parsing")]
    public class ParsingController : ApiController
    {
        public ParsingController(IParser parser)
        {
            Parser = parser;
        }

        [HttpGet]
        [Route]
        public void Get() { }

        [HttpPost]
        [Route("{p1?}/{p2?}/{p3?}/{p4?}/{p5?}")]
        public async Task<object> Post() =>
            Parse(await Request.Content.ReadAsStreamAsync());
        
        IEnumerable Parse(Stream stream)
        {
            using (var reader = new StreamReader(stream))
                while (true)
                {
                    var text = reader.ReadLine();
                    if (text == null)
                        yield break;
                    else
                        yield return Parser.Parse(text)
                            .ToDictionary(p => p.Name);
                };
        }

        IParser Parser { get; }
    }
}
