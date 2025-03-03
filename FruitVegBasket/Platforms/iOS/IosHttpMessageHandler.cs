using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitVegBasket.Interfaces;
using Security;

namespace FruitVegBasket.Platforms.iOS
{
    class IosHttpMessageHandler : IplatformHttpMessageHandler
    
    {
        public HttpMessageHandler GetHttpMessageHandler() =>
            new NSUrlSessionHandler
            {
                TrustOverrideForUrl = (NSUrlSessionHandler sender, string url, SecTrust trust) => url.StartsWith("https://localhost")
            };

    }
}
