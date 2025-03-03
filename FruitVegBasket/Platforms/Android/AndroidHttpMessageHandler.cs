using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using FruitVegBasket.Interfaces;
using Xamarin.Android.Net;

namespace FruitVegBasket.Platforms.Android
{
    class AndroidHttpMessageHandler : IplatformHttpMessageHandler
    {
        public HttpMessageHandler GetHttpMessageHandler() =>
            new AndroidMessageHandler
            {
                ServerCertificateCustomValidationCallback = (httpRequestMessage, certificate, chain, sslPolicyErrors) =>
                        certificate?.Issuer == "CN=localhost" || sslPolicyErrors == SslPolicyErrors.None
            };
        
    }
}
