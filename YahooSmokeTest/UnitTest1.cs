using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace YahooSmokeTest
{
    [TestClass]
    public class UnitTest1
    {

        IWebDriver driver;



        ExtentHtmlReporter reporter = new ExtentHtmlReporter("C:\\Users\\Satyanarayan\\source\\git\\YahooSmokeTest\\YahooSmokeTest\\Reports\\Local\\" + FunctionLibrary.Genaratedate() + "\\yahoo.html");
        ExtentReports extent = new ExtentReports();


        [TestMethod]
      
        public void Local() 
        {

            IWebDriver driver = new ChromeDriver();


            extent.AttachReporter(reporter);
            var test = extent.CreateTest("yahoolocal");

            try
            {
              

                driver.Url = "http://192.168.100.119:9097/";

                driver.Manage().Window.Maximize();



                for (int i = 2; i <= 10; i++)
                {

                    string title = driver.FindElement(By.XPath("/html/body/div[1]/header/div/section/div/div[3]/div/nav/ul/li[" + i + "]/a")).GetAttribute("title");


                    string actTitle = FunctionLibrary.ReadDataExcel(1, 1, i);

                    title.Contains(actTitle);

                    test.Log(Status.Info, "Title verified");

                    FunctionLibrary.waitForElement(driver, "/html/body/div[1]/header/div/section/div/div[3]/div/nav/ul/li[" + i + "]/a");


                    FunctionLibrary.clickAction(driver, "/html/body/div[1]/header/div/section/div/div[3]/div/nav/ul/li[" + i + "]/a", "xpath");



                    Console.WriteLine(title);

                   

                    test.Log(Status.Pass, title  +  "Test case Passsed");



                    if (title.Contains("Series"))
                    {


                        driver.Navigate().GoToUrl("http://192.168.100.119:9097//series/big-bash-league-2019-20-1182");

                        Thread.Sleep(2000);

                        for (int j = 2; j <= 10; j++)
                        {
                            FunctionLibrary.waitForElement(driver, "/html/body/div[1]/div/myapp/section[1]/div/div/div/div/section/div/div/div[2]/div/a[" + j + "]");

                            FunctionLibrary.clickAction(driver, "/html/body/div[1]/div/myapp/section[1]/div/div/div/div/section/div/div/div[2]/div/a[" + j + "]", "xpath");

                            test.Log(Status.Pass, driver.Title +  "Test case Passsed");


                            string expSerTitle = driver.Title;
                                
                            string actSerTitile = FunctionLibrary.ReadDataExcel(1, 2, j);

                            actSerTitile.Contains(expSerTitle);

                            test.Log(Status.Info, "Title verified");

                            Console.WriteLine(driver.Title);



                        }


                    }




                }
                driver.Close();
            }



            catch(Exception)
            {

                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

                ss.SaveAsFile(@"C:\Users\Satyanarayan\source\git\YahooSmokeTest\YahooSmokeTest\Screenshot\\" + FunctionLibrary.Genaratedate()+ ".png");

                test.Log(Status.Fail,driver.Title + "Test case failed");
            }

           

            extent.Flush();

        }

        [TestMethod]
        public void beta()
        {

            IWebDriver driver = new ChromeDriver();


           
            extent.AttachReporter(reporter);

            var test = extent.CreateTest("yahoobeta");

            try
            {
       

                driver.Url = "http://beta.cricket.yahoo.sportz.io/";

                driver.Manage().Window.Maximize();



                for (int i = 2; i <= 10; i++)
                {

                    string title = driver.FindElement(By.XPath("//nav[@class='site-nav']/ul/li[" + i + "]/a")).GetAttribute("title");

                    FunctionLibrary.waitForElement(driver, "//nav[@class='site-nav']/ul/li[" + i + "]/a");


                    FunctionLibrary.clickAction(driver, "//nav[@class='site-nav']/ul/li[" + i + "]/a", "xpath");



                    Console.WriteLine(title);

                    test.Log(Status.Pass, title + "Test case Passsed");



                    if (title.Contains("Series"))
                    {


                        driver.Navigate().GoToUrl("https://beta.cricket.yahoo.sportz.io/series/big-bash-league-2019-20-1182");

                        Thread.Sleep(2000);
                                                                
                        for (int j = 2; j <= 10; j++)
                        {
                            FunctionLibrary.waitForElement(driver, "//div[@class='swiper-wrapper']/a[" + j + "]");

                            FunctionLibrary.clickAction(driver, "//div[@class='swiper-wrapper']/a[" + j + "]", "xpath");

                            test.Log(Status.Pass, driver.Title + "Test case Passsed");
                            Console.WriteLine(driver.Title);

                        }


                    }




                }
                driver.Close();
            }



            catch (Exception)
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

                ss.SaveAsFile(@"C:\Users\Satyanarayan\source\git\YahooSmokeTest\YahooSmokeTest\Screenshot\Beta\" +FunctionLibrary.Genaratedate() + ".png");
                test.Log(Status.Fail,driver.Title +"Test case failed");
            }





            extent.Flush();
        }

      
    }
    
}
