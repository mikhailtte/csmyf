using System;
using System.IO;

namespace Beeper.Models
{
    public static class Log
    {
        public static void m(string m)
        {
            Console.WriteLine(m);
        }
        public static async void txt(string m, string pool_Id)
        {
            string pathtxt = Directory.GetCurrentDirectory() + "//logs/" + pool_Id + ".txt";

            using (var sw = new StreamWriter(pathtxt))
            {
                await sw.WriteAsync(DateTime.Now + "    " + m + Environment.NewLine);
                sw.Close();
            }

        }
    }
}