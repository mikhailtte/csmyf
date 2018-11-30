using System;
using System.Threading;
using OpenQA.Selenium;
using System.IO;

namespace jselooker
{
    class jselooker
    {
        static void Main(string[] args)
        {
            OpenQA.Selenium.Chrome.ChromeOptions co = new OpenQA.Selenium.Chrome.ChromeOptions();

            string login = "nologin";
            string pass = "nopass";

            Console.Write("Your jsecoin E-mail: ");
            Console.ReadLine(login);
            Console.Write("Your jsecoin password: ");
            Console.ReadLine(pass);

            IWebDriver Browser = new OpenQA.Selenium.Chrome.ChromeDriver();

            Browser.Navigate().GoToUrl("https://platform.jsecoin.com/");
            Thread.Sleep(5000);
            IWebElement loginLine = Browser.FindElement(By.Id("loginemail"));
            IWebElement passLine = Browser.FindElement(By.Id("loginpassword"));
            IWebElement goButton = Browser.FindElement(By.Id("login-button"));

            loginLine.SendKeys(login);
            passLine.SendKeys(pass);
            Thread.Sleep(2000);
            goButton.Click();

            Console.WriteLine("Is CAPTCH OK?");
            Console.Read();

            while (true)
            {
                Thread.Sleep(300000);
                Console.WriteLine(DateTime.Now + "    Looking Is Work.");
            }
        }
    }
}