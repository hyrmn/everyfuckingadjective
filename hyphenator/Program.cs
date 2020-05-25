using System;
using System.IO;
using NHyphenator;
using NHyphenator.Loaders;

namespace hyphenator
{
    public class Program
    {
        static void Main(string[] args)
        {
                if (args.Length == 0)
                {
                    Console.WriteLine("Usage:\n\thyphenator \"path\\to\\file.txt\"");
                    return;
                }

                var opts = new ResourceHyphenatePatternsLoader(HyphenatePatternsLanguage.EnglishUs);
                var nhyphenator = new Hyphenator(opts, "-");

                try
                {
                    var lines =  File.ReadAllLines(args[0]);
                    foreach(var line in lines) 
                    {
                        Console.WriteLine(nhyphenator.HyphenateText(line));
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine($"Could not find {args[0]}. Check the file path.");
                }
        }
    }
}
