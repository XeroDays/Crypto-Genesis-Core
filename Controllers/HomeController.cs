using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CryptoGenesis_Core.Models;
using HtmlAgilityPack;
using System.Net;

namespace CryptoGenesis_Core.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        { 
            return RedirectToAction("ProfitCalc");
        }
         
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("ProfitCalc")]
        public IActionResult ProfitCalc()
        {
            ServerViewModel obj = new ServerViewModel();
            obj.ServerCoin.Add("Bitcoin");
            obj.ServerCoin.Add("Ethereum");
            obj.ServerCoin.Add("Tether");
            obj.ServerCoin.Add("XRP");
            obj.ServerCoin.Add("LiteCoin");
            obj.ServerCoin.Add("binance-Coin");
            obj.ServerCoin.Add("Ocean-Protocol");
            obj.ServerCoin.Add("ChainLink");
            obj.ServerCoin.Add("REEF");
            obj.ServerCoin.Add("The-Graph"); 


            return View(obj);
        }
        [Route("MarketChecker")]
        public IActionResult MarketChecker()
        {
            return View();
        }

        [HttpGet]
        [Route("Coin/{code}")]
        public async Task<IActionResult> scrapeCoin(string code)
        {
            string link = "https://coinmarketcap.com/currencies/" + code;
            HtmlWeb web = new HtmlWeb();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HtmlAgilityPack.HtmlDocument doc = web.Load(link);
            HtmlNode circulatingSupply = doc.DocumentNode.SelectNodes("//div[@class='statsValue___2iaoZ']").Last();
            HtmlNode marketCap = doc.DocumentNode.SelectNodes("//div[@class='statsValue___2iaoZ']").First();
            string mc_number = returnNumber_filter(marketCap.InnerText);
            string cs_number = returnNumber_filter(circulatingSupply.InnerText);

            DataModel model = new DataModel();
            model.CirculatingSupply = cs_number;
            model.MarketCap = mc_number;
            model.CurrencyCode = code;
             
            return new JsonResult(model);
        }

        public static string returnNumber_filter(string tx)
        {
            string value = "";

            foreach (char ch in tx)
            {
                if (char.IsDigit(ch) || ch == '.')
                {
                    value += ch;
                }
            }
            return value;
        }

    }
}
