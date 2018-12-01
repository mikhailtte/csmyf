using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace Beeper.Models
{
    public class ParseABCC
    {
        string GetHTML(string url)
        {
            
        }
        void ParseSellBuy(string htmlres)
        {

        }
        void GetnParse(string url)
        {
            string htmlres = GetHTML(url);
            ParseSellBuy(htmlres);
            //присвоить статик переменным полученные значения(или вернуть массив с ними)
        }
    }
}