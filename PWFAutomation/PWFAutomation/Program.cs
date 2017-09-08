using System;
using OpenQA.Selenium.Chrome;

namespace PWFAutomation
{
    class Program
    {
        static ChromeDriver driver;
        static void Main(string[] args)
        {
            initialization();
            
        }

        static void initialization()
        {
            
            ChromeOptions options = new ChromeOptions();
            options.AddArguments(@"C:\Users\saranachoni\AppData\Local\Google\Chrome\User Data\Default");

            driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl(@"http://10.10.5.200:83/");
            Console.WriteLine("Please login and press any key to continue.");
            Console.ReadKey();
        }
    }
}
