using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Hobbits.Services
{
    public class DatabaseAccess
    {
        RetryPolicy rp = new RetryPolicy(new DetectionStrategy(), 5);

        public string Get()
        {

            var result = rp.ExecuteAction(() =>
            {
                var request = WebRequest.Create("https://www.google.com");
                request.Method = "GET";
                var response = request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                return responseString;
            });

            rp.Retrying += (sender, args) =>
            {
                Console.WriteLine("We are trying again.");
            };

            // here if the responseString was JSON (like it will be in assignment 7), we could call
            // Json.Parse(responseString);

            return result;
        }
    }
}
