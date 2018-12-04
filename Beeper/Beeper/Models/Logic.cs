using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*
Содержит статические методы логики, используемые классами,
отслеживающими конкретные страницы торгов(рынков);
*/
namespace Beeper.Models
{
    public class Logic 
    {
        public void Beep(double value0, double valueNow, double step, int beep) 
        {
//=======================================
			
			//если val0 = 0, то инициализируем его актуальным значением;
			if (!value0) {
					value0 = valueNow;
				}
				
			if (valueNow > value0) {
				//если новые данные больше
				if ((valueNow - value0) >= (value0 / 100 * step)) {
					
					//ALARM
					if (beep == 0) {
						
						Log.m("AT/BTC: РОСТ 0.5% ИЛИ БОЛЕЕ----------------------------");
						for (int i = 0; i < 4; i++){
							Console.Beep();
							Thread.Sleep(300);
						}
						++beep;
						
					} else if (beep > 0) {
						
						if (value0 / 100 * step) <= (valueNow - ((value0 / 100 * step) * beep)) {
							
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
//=======================================
        }

    }
}