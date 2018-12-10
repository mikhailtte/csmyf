using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace Beeper.Models
{
    public class Pool
    {
        string Id { get; set; }

        double step { get; set; }

        int delay { get; set; }

        double sell { get; set; }

        double buy { get; set; }

        bool work { get; set; }

        public Pool()
        {
            this.Id = "atbtc";
            this.step = 0.5;
            this.delay = 60000;
            sell = 0;
            buy = 0;
            work = true;
        }

        public Pool(string Id, double step, int delay)
        {
            this.Id = Id;
            this.step = step;
            this.delay = delay;
            sell = 0;
            buy = 0;
            work = true;
        }

        public async void Execute()
        {
            while (work)
            {
                double sellNew = 0;
                double buyNew = 0;

                ParseABCC.GetSellBuy(Id, ref sellNew, ref buyNew);

                if (buy == 0)
                {
                    buy = buyNew;
                    Console.Write("Initialisation Succesfull by " + buy.ToString("#,########"));

                } else if(buy != 0)
                {
                    Logic.mathBeepPC(buy, buyNew, step, Id);
                }
                

                if (buyNew > buy)
                {
                    if ((buyNew - buy) > buy / 100 * step) buy = buyNew;
                }
                else if (buyNew < buy)
                {
                    if ((buy - buyNew) > buy / 100 * step) buy = buyNew;
                }
                Thread.Sleep(delay);
            }
        }
    }
}