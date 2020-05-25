using System;
using System.IO;

namespace fuckinator
{
    public class Program
    {
        static void Main(string[] args)
        {
                if (args.Length == 0)
                {
                    Console.WriteLine("Usage:\n\fuckinator \"path\\to\\file.txt\"");
                    return;
                }

                try
                {
                    var lines =  File.ReadAllLines(args[0]);
                    foreach(var line in lines) 
                    {
                        if(!line.Contains("-")) 
                        {
                            Console.WriteLine($"fucking {line}");
                        }
                        else
                        {
                            Console.WriteLine(InsertFuck(line));
                        }
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine($"Could not find {args[0]}. Check the file path.");
                }
        }

        private static string InsertFuck(string line)
        {
            // We'll insert 'fucking-' after the first hyphen.
            // We'll then remove the rest of the hyphens because we only want to emphasize the fucking insertion
            var preIdx = line.IndexOf("-");
            var rest = line.Substring(preIdx + 1).Replace("-", "");
            var theFuckingVersion = line.Substring(0, preIdx+1) + "fucking-" + rest;
            
            return theFuckingVersion;
        }
    }
}
