using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using System.Collections.Concurrent;

public class Program
{
    static string api_location = "";

    static Guid myNodeId,
                myTestId;

    static void Main()
    {
        if (!Directory.Exists(Environment.CurrentDirectory + "\\" + 1))
        {
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\" + 1);
            File.Copy(Environment.CurrentDirectory + "\\" + "msedgedriver.exe", Directory.GetCurrentDirectory() + "\\" + 1 + "\\" + "msedgedriver.exe");
        }

        api_location = File.ReadAllText("api.txt");

        Console.WriteLine(api_location);

        register();
        sinc();

        // -----------------------
        // work cycle
        // -----------------------

        IRestResponse response;

        while (true)
        {
            do
            {
                RestClient client = new RestClient(api_location);
                RestRequest request = new RestRequest("wait", Method.POST);

                request.AddHeader("Content-Type", "application/json");

                request.AddJsonBody(new
                {
                    id = myNodeId,
                });

                response = client.Execute(request);

                if (response.Content.ToString().ToLower() == "\"w\"")
                {
                    // -----------------------
                    // work!
                    // -----------------------

                    Console.WriteLine("\nWORK!\n");

                    RegisterTime("UI Login");

                    Thread.Sleep(5000 + new Random().Next(1000, 2000));
                    // WorkerThread(1);

                    RegisterTime("UI Login");

                    // -----------------------
                    // work done!
                    // -----------------------

                    workDone();

                    // -----------------------
                    // sinc
                    // -----------------------

                    sinc();
                }
                else
                    Console.Write(".");

                Thread.Sleep(1000);
            }
            while (!response.IsSuccessful);
        }        
    }

    static void register()
    {
        #region - code - 

        // ------------
        // node
        // ------------

        {
            IRestResponse response;

            do
            {
                RestClient client = new RestClient(api_location);
                RestRequest request = new RestRequest("registerNode", Method.POST);

                request.AddHeader("Content-Type", "application/json");

                myNodeId = Guid.NewGuid();

                request.AddJsonBody(new
                {
                    id = myNodeId,
                });

                response = client.Execute(request);
            }
            while (!response.IsSuccessful);
        }

        // ------------
        // test id
        // ------------

        {
            IRestResponse response;

            do
            {
                RestClient client = new RestClient(api_location);
                RestRequest request = new RestRequest("regId", Method.POST);

                request.AddHeader("Content-Type", "application/json");

                response = client.Execute(request);

                myTestId = Guid.Parse(response.Content.Replace ("\"", ""));
            }
            while (!response.IsSuccessful);
        }

        #endregion
    }

    static void RegisterTime(string label)
    {
        RestClient client = new RestClient(api_location);
        RestRequest request = new RestRequest("regTime", Method.POST);

        request.AddHeader("Content-Type", "application/json");

        request.AddJsonBody(new
        {
            id = myTestId,
            label = label
        });

        var response = client.Execute(request);
    }

    static void sinc()
    {
        #region - code - 

        IRestResponse response;

        do
        {
            Thread.Sleep(100);

            RestClient client = new RestClient(api_location);
            RestRequest request = new RestRequest("sinc", Method.GET);

            request.AddHeader("Content-Type", "application/json");

            response = client.Execute(request);
        }
        while (!response.IsSuccessful);

        #endregion
    }

    static void workDone()
    {
        #region - code - 

        IRestResponse response;

        do
        {
            RestClient client = new RestClient(api_location);
            RestRequest request = new RestRequest("workDone", Method.POST);

            request.AddHeader("Content-Type", "application/json");

            request.AddJsonBody(new
            {
                id = myNodeId,
            });

            response = client.Execute(request);
        }
        while (!response.IsSuccessful);

        #endregion
    }

    static void WorkerThread(int threadNumber)
    {
        #region - code - 

        var helper = new Helper();

        helper.Log(threadNumber, "Started!");

        string chromeDriverPath = Environment.CurrentDirectory + "\\" + threadNumber;

        EdgeDriver driver = null;

        while (true)
        {
            try
            {
                Console.WriteLine(" --- Start ");

                string
                    site = "https://biolabecs.pharmalinkonline.com.br/#/autenticacao",
                    user = "rep.ecs",
                    senha = "A123456@",
                    pdv = "97.222.376/0001-82",
                    pdv_desc = "VERA CRUZ DROGARIA",
                    ean = "7896241225530",
                    qtd_produtos = "1";

                EdgeOptions options = new EdgeOptions();

                bool bAbort = false;

                options.AddArgument("--headless=new"); // Run Chrome in headless mode
                options.AddArgument("--incognito"); // Disable sandbox
                options.AddArgument("--silent"); // Disable sandbox
                options.AddArgument("--log-level=3");
                options.AddArgument("user-data-dir=" + Directory.GetCurrentDirectory());

                options.AddUserProfilePreference("user_experience_metrics", new
                {
                    personalization_data_consent_enabled = true
                });

                driver = new EdgeDriver(chromeDriverPath, options);

                driver.Manage().Cookies.DeleteAllCookies();
                Thread.Sleep(300);
                driver.Manage().Window.Size = new System.Drawing.Size(1920, 2080);
                driver.Navigate().GoToUrl(site);
                Thread.Sleep(300);
                driver.ExecuteScript("window.localStorage.clear();");
                Thread.Sleep(300);

                int timeout_milis = 250,
                    max_tries = 10,
                    cur_try = 0;

                while (true)
                {
                    qtd_produtos = new Random().Next(1, 50).ToString();

                    helper.Log(threadNumber, "Produtos: " + qtd_produtos);

                    try
                    {
                        int try_max_open_site = 10,
                            try_cur_open_site = 0;

                        bool failed = true;

                        while (true)
                        {
                            if (++try_cur_open_site < try_max_open_site)
                            {
                                try
                                {
                                    Thread.Sleep(1000);

                                    // aguardar carregar toda a tela
                                    while (!driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[4]/div/div[2]")).Text.Trim().StartsWith("Bem-vindo"))
                                    {
                                        if (driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[4]/div/div[2]")).Text.Trim().
                                                StartsWith("{{"))
                                        {
                                            helper.Log(threadNumber, "failed Ax0 - tela não carregou ({{)");
                                            driver.Navigate().GoToUrl(site);
                                            throw (new Exception());
                                        }

                                        if (driver.Url.EndsWith("error"))
                                        {
                                            helper.Log(threadNumber, "failed Ax1 - erro 404 ");
                                            bAbort = true;
                                            break;
                                        }
                                    }

                                    if (driver.Url.EndsWith("error"))
                                    {
                                        helper.Log(threadNumber, "failed Ax1 - erro 404 ");
                                        bAbort = true;
                                        break;
                                    }

                                    failed = false;
                                    break;
                                }
                                catch
                                {
                                    Thread.Sleep(3000);
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (bAbort || failed)
                        {
                            break;
                        }

                        Thread.Sleep(300);

                        if (driver.Url.EndsWith("error"))
                        {
                            helper.Log(threadNumber, "failed Ax2");
                            bAbort = true;
                            break;
                        }

                        helper.Wait(driver, By.Id("login"));
                        driver.FindElement(By.Id("login")).Clear();
                        driver.FindElement(By.Id("login")).SendKeys(user);
                        driver.FindElement(By.Id("senha")).Clear();
                        driver.FindElement(By.Id("senha")).SendKeys(senha);

                        // logar
                        driver.FindElement(By.CssSelector(".btn-custom-default")).Click();

                        break;
                    }
                    catch (System.Exception e)
                    {
                        helper.Log(threadNumber, "failed AxE " + e.ToString());

                        if (driver.Url.EndsWith("error"))
                        {
                            bAbort = true;
                            break;
                        }
                    }
                }

                if (driver.Url.EndsWith("error"))
                {
                    helper.Log(threadNumber, "failed Ax1 - erro 404 ");
                }

                if (bAbort)
                {
                    driver.Close();
                    driver.Quit();
                    continue;
                }

                //helper.Log(threadNumber, "login OK!");

                cur_try = 0;

                while (true)
                {
                    if (++cur_try == max_tries)
                    {
                        bAbort = true;
                        break;
                    }

                    try
                    {
                        Thread.Sleep(timeout_milis);

                        // erro 404
                        if (driver.Url.EndsWith("error"))
                        {
                            bAbort = true;
                            break;
                        }

                        try
                        {
                            helper.Wait(driver, By.XPath("//*[@id=\"menu-92\"]/span"));
                            driver.FindElement(By.XPath("//*[@id=\"menu-92\"]/span")).Click();
                            helper.Wait(driver, By.XPath("//*[@id=\"menu-213\"]"));
                            driver.FindElement(By.XPath("//*[@id=\"menu-213\"]")).Click();
                            break;
                        }
                        catch
                        {

                        }
                    }
                    catch
                    {
                        if (driver.Url.EndsWith("error"))
                        {
                            bAbort = true;
                            break;
                        }
                    }
                }

                if (bAbort || driver.Url.EndsWith("error"))
                {
                    helper.Log(threadNumber, "failed B");
                    driver.Close();
                    driver.Quit();
                    continue;
                }

                cur_try = 0;

                while (true)
                {
                    if (++cur_try == max_tries)
                    {
                        bAbort = true;
                        break;
                    }

                    try
                    {
                        Thread.Sleep(timeout_milis);

                        if (driver.Url.EndsWith("error"))
                        {
                            bAbort = true;
                            break;
                        }

                        try
                        {
                            helper.Wait(driver, By.Id("selecionar-loja"));
                            driver.FindElement(By.Id("selecionar-loja")).Click();
                            driver.FindElement(By.Id("selecionar-loja")).Clear();
                            driver.FindElement(By.Id("selecionar-loja")).SendKeys(pdv);
                            break;
                        }
                        catch
                        {

                        }
                    }
                    catch
                    {
                        if (driver.Url.EndsWith("error"))
                        {
                            bAbort = true;
                            break;
                        }
                    }
                }

                if (bAbort || driver.Url.EndsWith("error"))
                {
                    helper.Log(threadNumber, "failed C");
                    driver.Close();
                    driver.Quit();
                    continue;
                }

                cur_try = 0;

                while (true)
                {
                    if (++cur_try == max_tries)
                    {
                        bAbort = true;
                        break;
                    }

                    try
                    {
                        Thread.Sleep(timeout_milis);

                        if (driver.Url.EndsWith("error"))
                        {
                            bAbort = true;
                            break;
                        }

                        string concat = pdv + " - " + pdv_desc;

                        try
                        {
                            helper.Wait(driver, By.LinkText(concat));
                            driver.FindElement(By.LinkText(concat)).Click();
                            break;
                        }
                        catch
                        {

                        }
                    }
                    catch
                    {
                        if (driver.Url.EndsWith("error"))
                        {
                            bAbort = true;
                            break;
                        }
                    }
                }

                if (bAbort || driver.Url.EndsWith("error"))
                {
                    Console.WriteLine("failed!");
                    helper.Log(threadNumber, "failed D");
                    driver.Close();
                    driver.Quit();
                    continue;
                }

                cur_try = 0;

                while (true)
                {
                    if (++cur_try == max_tries)
                    {
                        bAbort = true;
                        break;
                    }

                    try
                    {
                        Thread.Sleep(timeout_milis);

                        if (driver.Url.EndsWith("error"))
                        {
                            bAbort = true;
                            break;
                        }

                        try
                        {
                            helper.Wait(driver, By.CssSelector(".tipoPedido-descricao-rep"));
                            driver.FindElement(By.CssSelector(".tipoPedido-descricao-rep")).Click();
                            break;
                        }
                        catch
                        {

                        }
                    }
                    catch
                    {
                        if (driver.Url.EndsWith("error"))
                        {
                            bAbort = true;
                            break;
                        }
                    }
                }

                if (bAbort || driver.Url.EndsWith("error"))
                {
                    helper.Log(threadNumber, "failed E");
                    driver.Close();
                    driver.Quit();
                    continue;
                }

                cur_try = 0;

                while (true)
                {
                    if (++cur_try == max_tries)
                    {
                        bAbort = true;
                        break;
                    }

                    try
                    {
                        Thread.Sleep(timeout_milis);

                        if (driver.Url.EndsWith("error"))
                        {

                            bAbort = true;
                            break;
                        }

                        try
                        {
                            helper.Wait(driver, By.Id("slcPrazoPagamento"));
                            driver.FindElement(By.Id("slcPrazoPagamento")).Click();
                            {
                                var dropdown = driver.FindElement(By.Id("slcPrazoPagamento"));
                                dropdown.FindElement(By.XPath("//option[. = 'À Vista']")).Click();
                            }
                            break;
                        }
                        catch
                        {

                        }
                    }
                    catch
                    {
                        if (driver.Url.EndsWith("error"))
                        {
                            bAbort = true;
                            break;
                        }
                    }
                }

                if (bAbort || driver.Url.EndsWith("error"))
                {
                    helper.Log(threadNumber, "failed F");
                    driver.Close();
                    driver.Quit();
                    continue;
                }

                cur_try = 0;

                while (true)
                {
                    if (++cur_try == max_tries)
                    {
                        bAbort = true;
                        break;
                    }

                    try
                    {
                        Thread.Sleep(timeout_milis);

                        if (driver.Url.EndsWith("error"))
                        {

                            bAbort = true;
                            break;
                        }

                        try
                        {
                            driver.FindElement(By.CssSelector(".fa-angle-double-right")).Click();
                            driver.FindElement(By.CssSelector(".btn-margin")).Click();
                            break;
                        }
                        catch
                        {

                        }
                    }
                    catch
                    {
                        if (driver.Url.EndsWith("error"))
                        {
                            bAbort = true;
                            break;
                        }
                    }
                }

                if (bAbort || driver.Url.EndsWith("error"))
                {
                    helper.Log(threadNumber, "failed G");
                    driver.Close();
                    driver.Quit();
                    continue;
                }

                cur_try = 0;

                while (true)
                {
                    if (++cur_try == max_tries)
                    {
                        bAbort = true;
                        break;
                    }

                    try
                    {

                        Thread.Sleep(timeout_milis * 3);

                        if (driver.Url.EndsWith("error"))
                        {
                            bAbort = true;
                            break;
                        }

                        try
                        {
                            driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[3]/div/div[1]/div[1]/div/input")).Clear();
                            driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[3]/div/div[1]/div[1]/div/input")).SendKeys(ean);
                            break;
                        }
                        catch
                        {

                        }
                    }
                    catch
                    {
                        if (driver.Url.EndsWith("error"))
                        {
                            bAbort = true;
                            break;
                        }
                    }
                }

                if (bAbort || driver.Url.EndsWith("error"))
                {
                    helper.Log(threadNumber, "failed H");
                    driver.Close();
                    driver.Quit();
                    continue;
                }

                cur_try = 0;

                while (true)
                {
                    if (++cur_try == max_tries)
                    {
                        bAbort = true;
                        break;
                    }

                    try
                    {
                        Thread.Sleep(timeout_milis);

                        if (driver.Url.EndsWith("error"))
                        {

                            bAbort = true;
                            break;
                        }

                        try
                        {
                            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                            helper.Wait(driver, By.CssSelector(".quantidade-pedido-item"));
                            driver.FindElement(By.CssSelector(".quantidade-pedido-item")).Clear();
                            driver.FindElement(By.CssSelector(".quantidade-pedido-item")).SendKeys(qtd_produtos);
                            driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[4]/div/div[2]/div[4]/div/button[2]")).Click();
                            break;
                        }
                        catch
                        {

                        }
                    }
                    catch
                    {
                        if (driver.Url.EndsWith("error"))
                        {
                            bAbort = true;
                            break;
                        }
                    }
                }

                if (bAbort || driver.Url.EndsWith("error"))
                {
                    helper.Log(threadNumber, "failed I");
                    driver.Close();
                    driver.Quit();
                    continue;
                }

                cur_try = 0;

                while (true)
                {
                    if (++cur_try == max_tries)
                    {
                        bAbort = true;
                        break;
                    }

                    try
                    {
                        Thread.Sleep(timeout_milis);

                        if (driver.Url.EndsWith("error"))
                        {
                            bAbort = true;
                            break;
                        }

                        try
                        {
                            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                            helper.Wait(driver, By.CssSelector(".btn-custom-default:nth-child(4)"));
                            driver.FindElement(By.CssSelector(".btn-custom-default:nth-child(4)")).Click();
                            break;
                        }
                        catch
                        {

                        }
                    }
                    catch
                    {
                        if (driver.Url.EndsWith("error"))
                        {
                            bAbort = true;
                            break;
                        }
                    }
                }

                if (bAbort || driver.Url.EndsWith("error"))
                {
                    helper.Log(threadNumber, "failed J");
                    driver.Close();
                    driver.Quit();
                    continue;
                }

                cur_try = 0;

                while (true)
                {
                    if (++cur_try == max_tries)
                    {
                        bAbort = true;
                        break;
                    }

                    try
                    {
                        Thread.Sleep(timeout_milis);

                        if (driver.Url.EndsWith("error"))
                        {

                            bAbort = true;
                            break;
                        }

                        try
                        {
                            var numero = driver.FindElement(By.CssSelector("body > div.sweet-alert.showSweetAlert.visible > p")).Text;
                            helper.Log(threadNumber, "Pedido OK!;" + numero);
                            driver.FindElement(By.CssSelector(".confirm")).Click();
                            break;
                        }
                        catch
                        {

                        }
                    }
                    catch
                    {
                        if (driver.Url.EndsWith("error"))
                        {
                            bAbort = true;
                            break;
                        }
                    }
                }

                driver.Close();
                driver.Quit();
            }

            catch (Exception e) 
            {
                helper.Log(threadNumber, "Exception; " + e.ToString());
                Console.WriteLine(" --- Exception handled " + e.ToString());

                if (driver != null)
                {
                    driver.Close();
                    driver.Quit();
                }
            }
        }

        #endregion
    }
}

public class Helper
{
    #region - code - 

    private ConcurrentQueue<string> logQueue = new ConcurrentQueue<string>();
    private object fileLock = new object();
    private bool isWriting = false;

    public void Log(int threadNumber, string msg)
    {
        string logEntry = "#" + threadNumber + "; " + msg + " ; " + DateTime.Now.ToString("HHmmss_ffff");
        logQueue.Enqueue(logEntry);

        if (!isWriting)
        {
            Task.Run(WriteLogsToFile);
        }
    }

     void WriteLogsToFile()
    {
        if (isWriting)
        {
            return;
        }

        lock (fileLock)
        {
            if (isWriting)
            {
                return;
            }

            isWriting = true;

            try
            {
                while (logQueue.TryDequeue(out string logEntry))
                {
                    File.AppendAllText("results.txt", logEntry + "\n");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions that may occur during writing
                Console.WriteLine("Error writing logs: " + ex.Message);
            }
            finally
            {
                isWriting = false;
            }
        }
    }

    public void Wait(IWebDriver driver, By elementLocator, int seconds = 900)
    {
        try
        {
            // Wait until the element is present
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(driver => driver.FindElements(elementLocator).Count > 0);
        }
        catch
        {

        }
    }

    #endregion
}
