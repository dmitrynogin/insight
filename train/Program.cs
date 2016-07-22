using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.IO.Path;
using static System.IO.Directory;
using static System.IO.File;
using static System.String;
using static System.Text.Encoding;
using System.IO;
using Insight.Snowball;
using Insight.Parsing;
using Accord.Statistics.Kernels;
using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using Infra.IO;
using Infra.Csv;
using Infra.IO.Readers.Tabular;
using ICSharpCode.SharpZipLib.Zip;
using Infra.AccordNet;

namespace train
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 1)
            {
                WriteLine("Usage:\n\n\ttrain.exe <folder path>");
                return;
            }

            WriteLine("Platform: " + IntPtr.Size);

            var stemmer = new SnowballStemmer();
            using (var zip = new ZipOutputStream(
                OpenWrite(
                    Combine(
                        GetDirectoryName(args[0]),
                        GetFileName(args[0]) + ".cl"))))
            {

                WriteLine("Building dictionary...");
                var text = ReadAllLines(Combine(args[0], "text.txt"));
                var dic = new Dictionary(text
                    .SelectMany(jd => jd.StemText(stemmer))
                    .ToLookup(w => w.Stemmed)
                    .Select(l => new { Stemmed = l.Key, Count = l.Count() })
                    .OrderByDescending(w => w.Count)
                    .Select(w => w.Stemmed)
                    .Take(5000)
                    .ToArray());

                zip.PutNextEntry(new ZipEntry("dic.txt"));
                using (var writer = new StreamWriter(zip, Encoding.UTF8, 4096, true))
                    dic.WriteTo(writer);
                zip.CloseEntry();

                WriteLine("Vectorizing...");
                var input = new double[text.Length][];
                for (int i = 0; i < text.Length; i++)
                    input[i] = dic.Vectorize(new Document(text[i], stemmer));

                var classifiers = from f in GetFiles(args[0])
                                  where GetFileName(f) != "text.txt"
                                  where GetExtension(f) == ".txt"
                                  let ll = ReadAllLines(f)
                                  let ld = ll.Distinct().ToArray()
                                  let li = ld
                                    .Select((l, i) => new { l, i })
                                    .ToDictionary(x => x.l, x => x.i)
                                  select new
                                  {
                                      Name = GetFileNameWithoutExtension(f),
                                      Labels = ld,
                                      Output = ll.Select(l => li[l]).ToArray()
                                  };

                foreach (var classifier in classifiers)
                {
                    Write($"Training: {classifier.Name}");
                    IKernel kernel = new Linear();
                    var machine = new MulticlassSupportVectorMachine(input[0].Length, kernel, classifier.Labels.Length);
                    var teacher = new MulticlassSupportVectorLearning(machine, input, classifier.Output);
                    teacher.Algorithm = (svm, classInputs, classOutputs, i, j) =>
                    {
                        //var sequentialMinimalOptimization = new SequentialMinimalOptimization(svm, classInputs, classOutputs);
                        //sequentialMinimalOptimization.Run();
                        var linearCoordinateDescent = new LinearCoordinateDescent(svm, classInputs, classOutputs);
                        linearCoordinateDescent.Run();

                        var probabilisticOutputLearning = new ProbabilisticOutputCalibration(svm, classInputs, classOutputs);
                        return probabilisticOutputLearning;
                    };                    
                    WriteLine($", error = {teacher.Run()}");

                    zip.PutNextEntry(new ZipEntry(classifier.Name + ".svm"));
                    using (var stream = new MemoryStream())
                    {
                        machine.Save(stream);
                        stream.Position = 0;
                        stream.CopyTo(zip);
                    }
                    zip.CloseEntry();

                    zip.PutNextEntry(new ZipEntry(classifier.Name + ".txt"));
                    using (var writer = new StreamWriter(zip, UTF8, 4096, true))
                        foreach (var lable in classifier.Labels)
                            writer.WriteLine(lable);

                    zip.CloseEntry();
                }

                WriteLine("Done.");
            }       
        }
    } 
}
