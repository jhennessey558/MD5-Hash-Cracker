using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD5Cracker
{
    class Program
    {
        static TextWriter output;
        static void Main(string[] args)
        {
            Console.WriteLine("NEW");
            var config = new MD5CrackerArgumentParser(args).Parse();
            if (config.OutputFile == string.Empty)
                output = Console.Out;
            else
                output = (TextWriter)new StreamWriter(config.OutputFile);
            var hashCracker = new MD5CrackerHashCracker(config);
            hashCracker.HashCracked += hashCracker_OnHashCracked;
            hashCracker.StartAttack();
        }

        static void hashCracker_OnHashCracked(object sender, HashCrackedEventArgs e)
        {
            output.WriteLine("{0} {1}", e.Name, e.PlainText);
            output.Flush();
        }
    }
}