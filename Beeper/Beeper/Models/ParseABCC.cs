using System;
using System.Net;
using System.IO;

namespace Beeper.Models
{
    public static class ParseABCC
    {
        static string GetHTML(string url, string PoolId)
        {
            //configuring request to need url
            
            //Log.m(url);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url+PoolId);
            req.Method = "GET";

            //try to get a response to our request in htmlres
            string htmlres = "0";
            try
            {
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                using (System.IO.StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.UTF8))
                {
                    htmlres = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                Log.m(ex.Message);
                Log.txt(ex.Message, PoolId);
            }
            
            return htmlres;
        }

        static void ParseSellBuy(string htmlres, ref double refSell, ref double refBuy)
        {
            //create copy htmlres couse will cut him
            string sell = String.Copy(htmlres);

            //find sell word
            int indexSell = sell.IndexOf("\"sell\":");
            //delete all from start to start sell numbers(sell+8)
            sell = sell.Remove(0, indexSell + 8);
            //find end of sell number
            int indexEnd = sell.IndexOf("\"");
            //cut only number
            sell = sell.Substring(0, indexEnd);

            //the same for buy

            int indexBuy = htmlres.IndexOf("\"buy\":");
            htmlres = htmlres.Remove(0, indexBuy + 7);
            indexEnd = htmlres.IndexOf("\"");
            htmlres = htmlres.Substring(0, indexEnd);

            sell = sell.Replace(".", ",");
            htmlres = htmlres.Replace(".", ",");
            refSell = Convert.ToDouble(sell);
            refBuy = Convert.ToDouble(htmlres); //(htmlres = buy)
        }

        public static void GetSellBuy(string PoolId, ref double refSell, ref double refBuy)
        {
            string url = "https://abcc.com/markets/";
            string htmlres = GetHTML(url, PoolId);
            ParseSellBuy(htmlres, ref refSell, ref refBuy);
        }
    }
}