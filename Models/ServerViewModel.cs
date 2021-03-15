using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoGenesis_Core.Models
{
    public class ServerViewModel
    {
        public List<string> ServerCoin { get; set; }

        public ServerViewModel()
        {
            ServerCoin = new List<string>();
        }
    }
}
