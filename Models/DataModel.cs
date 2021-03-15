using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoGenesis_Core.Models
{
    public class DataModel
    {
        public string MarketCap { get; set; }
        public string CirculatingSupply { get; set; }
        public decimal MarketCap_decimal { get { return Convert.ToDecimal(MarketCap); } set { } }
        public decimal CirculatingSupply_decimal { get { return Convert.ToDecimal(CirculatingSupply); } set { } }
        public decimal CurrentPrice { get { return Math.Round(Convert.ToDecimal(MarketCap) / Convert.ToDecimal(CirculatingSupply),5); } set { } }

        public string CurrencyCode { get; set; }
    } 
}
