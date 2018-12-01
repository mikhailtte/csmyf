using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading;
//using System.Thread;

namespace getHTML {
	static class Log {
		public static void CLog(string msg) {
			Console.WriteLine(msg);
		}
		public static void CLog(string msg, int msg1) {
			Console.WriteLine(msg, " ", msg1);
		}
	}
	class getHTML 
	{
				/*
		public void ABCC_ADABTC() 
		{		
			
			double sell0 = 0.0;
			double buy0 = 0.0;
			int timewait = 60000;
			string htmlres = "0";
			string link = "https://abcc.com/markets/adabtc";
			int beep = 0; 
			static public float step = 0.5; 
		
			while(true) {
			
				HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(link);
				req.Method = "GET";
			
				
				try {
					HttpWebResponse res = (HttpWebResponse)req.GetResponse();
					
					using (StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8)) {
						htmlres = sr.ReadToEnd();
						sr.Close;
					}
				} catch(Exception ex) {
					Console.WriteLine(ex.Message);
				}
			
				//парсим цену продажи
			
				string sell = String.Copy(htmlres);
			
				int indexSell = sell.IndexOf("\"sell\":");
				sell = sell.Remove(0,indexSell+8);
				int indexEnd = sell.IndexOf("\"");
				sell = sell.Substring(0,indexEnd);
				
				//парсим цену покупки
				string buy = String.Copy(htmlres);
				int indexBuy = buy.IndexOf("\"buy\":");
				buy = buy.Remove(0,indexBuy+7);
				indexEnd = buy.IndexOf("\"");
				buy = buy.Substring(0,indexEnd);
	
				Log.CLog("ADA/BTC SELL = " + sell);
				Log.CLog("ADA/BTC BUY = " + buy);
				Log.CLog("Дата: " + DateTime.Now);
			
				double sell_new = Double.TryParse(sell);
				double buy_new = buy0 = Double.TryParse(buy);
			
				if (!sell0) {
					sell0 = sell_new;
				}
				if (!buy0) {
					buy0 = buy_new;
				}
				
				if (buy_new > buy0) {
					//если новые данные больше
					if ((buy_new - buy0) >= (buy0 / 100 * step)) {
						
						//ALARM
						if (beep == 0) {
							
							Log.CLog("ADA/BTC: РОСТ 0.5% ИЛИ БОЛЕЕ----------------------------!!!");
							for (int i = 0; i < 4; i++){
								Console.Beep();
								Thread.Sleep(300);
							}
							++beep;
							
						} else if (beep > 0) {
							
							if (buy0 / 100 * step) <= (buy_new - ((buy0 / 100 * step)* beep)) {
								
								Log.CLog("ADA/BTC: НОВЫЙ ШАГ НА 0.5% ИЛИ БОЛЕЕ----------------------------!!!");
								
								for (int i = 0; i < 4; i++){
									
									Console.Beep();
									Thread.Sleep(300);
								}
								++beep;
							} else if (buy0 / 100 * step) > (buy_new - ((buy0 / 100 * step)* beep)) {
								Log.CLog("ADA/BTC: Рост меньше нового шага");
							}
						}
					}else if ((buy_new - buy0) < (buy0 / 100 * step)) {
						Log.CLog("ADA/BTC: Рост меньше чем на 0.5%");
					}
				}else if (buy_new < buy0) {
					//если новые данные меньше
					buy0 = buy_new;
					beep = 0;
					Log.CLog("ADA/BTC: Падение ниже курса отсчета, курс отсчета изменен");
				} else if (buy_new = buy0) Log.CLog("ADA/BTC: Ничего нового");
				
				string htmlres = "0";
				Thread.Sleep(timewait);
			}
			Log.CLog("round");
		}
		*/
		public void ABCC_ATBTC() 
		{
			double sell0 = 0,0; //цена продажи входа
			double buy0 = 0,0;  //цне покупки входа
            int timewait = 60000;
			string htmlres = "0"; //HTML-содержимое сайта
			string link="https://abcc.com/markets/atbtc";
            int beep = 0;
            public float step = 1/2; 
		
			while(true) {
			
            //endless monitoring cycle 
				HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(link);
				req.Method = "GET";
			
				//------
				try {
					HttpWebResponse res = (HttpWebResponse)req.GetResponse();
					
					using (StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8)) {
					htmlres = sr.ReadToEnd();
					sr.Close();
					}
				} catch(Exception ex) {
					Console.WriteLine(ex.Message);
				}
			
				//парсим цену продажи
			
				string sell = String.Copy(htmlres);
			
				int indexSell = sell.IndexOf("\"sell\":");
				sell = sell.Remove(0,indexSell+8);
				int indexEnd = sell.IndexOf("\"");
				sell = sell.Substring(0,indexEnd);
				
				//парсим цену покупки
				string buy = String.Copy(htmlres);
				int indexBuy = buy.IndexOf("\"buy\":");
				buy = buy.Remove(0,indexBuy+7);
				indexEnd = buy.IndexOf("\"");
				buy = buy.Substring(0,indexEnd);
	
				Log.CLog("AT/BTC SELL = " + sell);
				Log.CLog("AT/BTC BUY = " + buy);
				Log.CLog("Дата: " + DateTime.Now);
			
				double sell_new = Double.TryParse(sell);
				double buy_new = Double.TryParse(buy);
			
				if (!sell0) {
					sell0 = sell_new;
				}
				if (!buy0) {
					buy0 = buy_new;
				}
				
				if (buy_new > buy0) {
					//если новые данные больше
					if ((buy_new - buy0) >= (buy0 / 100 * step)) {
						
						//ALARM
						if (beep == 0) {
							
							Log.CLog("AT/BTC: РОСТ 0.5% ИЛИ БОЛЕЕ----------------------------");
							for (int i = 0; i < 4; i++){
								Console.Beep();
								Thread.Sleep(300);
							}
							++beep;
							
						} else if (beep > 0) {
							
							if (buy0 / 100 * step) <= (buy_new - ((buy0 / 100 * step)* beep)) {
								
								Log.CLog("AT/BTC: НОВЫЙ ШАГ НА 0.5% ИЛИ БОЛЕЕ----------------------------");
								
								for (int i = 0; i < 4; i++){
									
									Console.Beep();
									Thread.Sleep(300);
								}
								++beep;
							} else if (buy0 / 100 * step) > (buy_new - ((buy0 / 100 * step)* beep)) {
								Log.CLog("AT/BTC: Рост меньше нового шага");
							}
						}
					}else if ((buy_new - buy0) < (buy0 / 100 * step)) {
						Log.CLog("AT/BTC: Рост меньше чем на 0.5%");
					}
				}else if (buy_new < buy0) {
					//если новые данные меньше
					buy0 = buy_new;
					beep = 0;
					Log.CLog("AT/BTC: Падение ниже курса отсчета, курс отсчета изменен");
				} else if (buy_new = buy0) Log.CLog("AT/BTC: Ничего нового");
				
				string htmlres = "0";
				Thread.Sleep(timewait);
			}
			Log.CLog("round");
		}
	}
	
	class program 
	{
		static void Main(string[] args) {
		 
		 
		 getHTML obj_getHTML = new getHTML();
		 
		 
		 
		 Log.CLog("1- ADA/BTC 2- AT/BTC 12 - together");
		 int press = 0;
		 Console.ReadLine(press);
		// if (press == 1) {
		//	 Console.Write("Введите шаг для ADA/BTC(например: 0.5): ");
		//	 Console.ReadLine(getHTML.ABCC_ADABTC.step);
		//	 Thread adabtc = new Thread(getHTML.ABCC_ADABTC());
		//	 adabtc.Start();
		 //} else
			 if(press == 2) {
			 Console.Write("Введите шаг для AT/BTC(например: 0.5): ");
			 Console.ReadLine(getHTML.ABCC_ATBTC.step);
			 Thread adabtc = new Thread(getHTML.ABCC_ATBTC());
			 atbtc.Start();
		 } else if (press == 12) {
			// Console.Write("Введите шаг для ADA/BTC(например: 0.5): ");
			// Console.ReadLine(getHTML.ABCC_ADABTC.step);
			// Thread adabtc = new Thread(getHTML.ABCC_ADABTC());
			// adabtc.Start();
			 
			 Console.Write("Введите шаг для AT/BTC(например: 0.5): ");
			 Console.ReadLine(getHTML.ABCC_ATBTC.step);
			 Thread adabtc = new Thread(getHTML.ABCC_ATBTC());
			 atbtc.Start();	 
		 }
		 
		 
			Log.CLog("End of Code");
			Console.Read();
			//Console.Read();
			//Console.Read();
			//Console.Read();
			//Console.Read();
		}
	}
}