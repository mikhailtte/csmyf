using System.Globalization;
using System.Threading;
/*
Содержит статические методы логики, используемые классами,
отслеживающими конкретные страницы торгов(рынков);
*/
namespace Beeper.Models
{
    public class Logic 
    {
        public static async void mathBeepPC(double value0, double valueNow, double step, string poolId) 
        {
            var step_is = value0 / 100 * step; //шаг в процентах -> сумма равная шагу

			//если val0 = 0, то инициализируем его актуальным значением;
			if (value0 == 0) {
					value0 = valueNow;
			}

            if (valueNow > value0)
            {
                //если новые данные больше
                if ((valueNow - value0) >= step_is)
                {
                    //Если больше на шаг или более

                    Log.m(poolId +": РОСТ НА ШАГ ИЛИ БОЛЕЕ; " + valueNow.ToString("G", CultureInfo.CreateSpecificCulture("eu-ES")) + "  +");

                    string specifier = "P";
                    CultureInfo culture = CultureInfo.InvariantCulture;
                    Log.m(((valueNow - value0) / (value0 / 100)).ToString(specifier, culture));

                    BeepTo.PC(4);
                    value0 = valueNow;//НЕ ТАК НУ ЕБАНА====================================================================
                }
                else if ((valueNow - value0) < step_is)
                {
                    //рост меньше чем на шаг
                    Log.m(poolId + ": РОСТ МЕНЕЕ ЧЕМ НА ШАГ; " + valueNow.ToString("G", CultureInfo.CreateSpecificCulture("eu-ES")) + "  +");

                    string specifier = "P";
                    CultureInfo culture = CultureInfo.InvariantCulture;
                    Log.m(((valueNow - value0) / (value0 / 100)).ToString(specifier, culture));

                    BeepTo.PC(2);
                }
            } else if (valueNow == value0)
            {
                //ничего новго
                Log.m(poolId + ": Без измeнений");
                BeepTo.PC(1);
            } else if (valueNow < value0)
            {
                //если новые данные меньше
                if ((value0-valueNow) >= step_is)
                {
                    //шаг или более вниз 
                    Log.m(poolId + ": ПАДЕНИЕ НА ШАГ ИЛИ БОЛЕЕ; " + valueNow.ToString("G", CultureInfo.CreateSpecificCulture("eu-ES")) + "  -");

                    string specifier = "P";
                    CultureInfo culture = CultureInfo.InvariantCulture;
                    Log.m(((value0 - valueNow) / (value0 / 100)).ToString(specifier, culture));

                    BeepTo.PC(4);
                    value0 = valueNow;
                } else if ((value0 - valueNow) < step_is)
                {
                    //падение меньше чем на шаг
                    Log.m(poolId + ": ПАДЕНИЕ МЕНЕЕ ЧЕМ НА ШАГ; " + valueNow.ToString("G", CultureInfo.CreateSpecificCulture("eu-ES")) + "  -");

                    string specifier = "P";
                    CultureInfo culture = CultureInfo.InvariantCulture;
                    Log.m(((value0 - valueNow) / (value0 / 100)).ToString(specifier, culture));

                    BeepTo.PC(2);
                }
            }
        }
    }
}