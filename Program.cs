using System;
using System.Linq;

namespace Wget
{
    public class Program
    {
        public static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                try
                {
                    var uri = new Uri(arg);
                }
                catch
                {
                    Console.WriteLine($"Invalid URL was provided: {arg}");
                    return;
                }

                var dest = arg.Split('/').Last();
                try
                {
                    using (var wc = new WebClient())
                    {
                        wc.DownloadFile(arg, dest);
                    }
                }
                catch
                {
                    Console.WriteLine($"Failed to download {dest}");
                }
            }
        }
    }
}