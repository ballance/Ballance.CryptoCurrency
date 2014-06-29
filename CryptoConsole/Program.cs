using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var bitThing = new Ballance.Crypto.Bitcoin();
            var currentPriceRetrieved = bitThing.GetCurrentPrice();

            //Console.WriteLine("Current Price: {0}", currentPriceRetrieved);

            //var livePrice = bitThing.GetLivePrice("https://bitcoinaverage.com/#USD", "global-last");
            
            //Console.WriteLine("Current Live Price: {0}", livePrice);
            
            ////Console.Write("Press any key to continue. 'q' to quit.");
            var entered = string.Empty;

            while (!entered.Equals("x", StringComparison.InvariantCultureIgnoreCase))
            {
                var livePrice = bitThing.GetLivePriceJSON("https://api.bitcoinaverage.com/ticker/USD/", "global-last");

                Console.WriteLine("{0}", livePrice);

                entered = Console.ReadKey().Key.ToString();
            }
            //Console.ReadKey();
        }
    }
}
