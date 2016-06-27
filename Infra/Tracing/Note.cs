using Infra.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Tracing
{
    [IoC(AsSelf = true)]
    public class Note : IDisposable
    {
        public void Tag(string tag) => Tags.Add(tag.Replace(' ', '-'));
        public void Comment(string line = "") => Lines.Add(line);
        public void Report(string name, object value) => Table[name] = value;

        public void Dispose()
        {
            if (!Tags.Any())
                return;

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("insight.notifier@gmail.com", "6zhPttQz")
            };

            client.Send(
                "insight.notifier@gmail.com", 
                "insight.notifier@gmail.com", 
                Subject,
                Body);
        }

        public override string ToString() => Subject + "\n\r\n\r" + Body;
        string Subject => string.Join("; ", Tags.OrderBy(t => t));
        string Body => string.Join("\n\r", Lines) + 
            "\n\r\n\r" + 
            string.Join("\n\r", 
                Table.Select(kvp => $"{kvp.Key}\t: {kvp.Value}"));

        Dictionary<string, object> Table { get; } = new Dictionary<string, object>();
        HashSet<string> Tags { get; } = new HashSet<string>();
        List<string> Lines { get; } = new List<string>();
    }
}
