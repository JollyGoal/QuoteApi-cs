using System;
using System.Collections.Generic;
using System.Net;
using System.Collections.Specialized;
using System.Web;
using Microsoft.Extensions.Logging;

namespace QuoteApi_cs.Utils
{
    public class MessagingService
    {
        private readonly ILogger<MessagingService> _logger;
        public MessagingService(ILogger<MessagingService> logger)
        {
            _logger = logger;
        }
        public void sendSMS(string number, string msg)
        {
            string message = HttpUtility.UrlEncode(msg);
            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("https://api.txtlocal.com/send/", new NameValueCollection()
                {
                {"apikey" , "yourapiKey"},
                {"numbers" , number},
                {"message" , message},
                {"sender" , "Jims Autos"}
                });
                string result = System.Text.Encoding.UTF8.GetString(response);
            }
        }
    }
}