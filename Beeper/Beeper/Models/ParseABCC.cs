using System;
using System.Net;
using System.IO;

namespace Beeper.Models
{
    public class ParseABCC
    {
        string GetHTML(string url, string PoolId)
        {
            //configuring request to need url
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
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

        void ParseSellBuy(string htmlres, double refSell, double refBuy)
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



            refSell = Convert.ToDouble(sell);
            refBuy = Convert.ToDouble(htmlres); //(htmlres = buy)
        }

        void GetSellBuy(string url, string PoolId, ref double refSell, ref double refBuy)
        {
            string htmlres = GetHTML(url, PoolId);
            ParseSellBuy(htmlres, refSell, refBuy);
        }
    }
}