using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Beeper.Models
{
    public static class BeepTo
    {
        public static async void PC(int t = 4)
        {
            for (int i = 0; i < t; i++)
            {
                Console.Beep();
                Thread.Sleep(300);
            }
        }

        public static async void VK()
        {
            
        }

        public static async void TG()
        {
            
        }
    }
}