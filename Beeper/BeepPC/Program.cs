using Beeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeepPC
{
    class Program
    {
        static void Main(string[] args)
        {
            Pool AT = new Pool();
            AT.Execute();
			
            Console.ReadKey();
        }
    }
}
