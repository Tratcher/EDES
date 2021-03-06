﻿using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;

namespace TestClient
{
    public static class Program
    {
        private static HttpClient Client = new HttpClient();

        // Compare to https://github.com/EDCD/EDDI/blob/b124d02a24f4a3cbef615f6553a127d0ba7d294c/Utilities/Logging.cs#L129-L136
        public static void Main(string[] args)
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("ApiKey", "1BFFB29F-3B95-4F07-BFD7-167590C81A29");

            for (int i = 1; ; i++)
            {
                Console.WriteLine("Press any key to send report");
                Console.ReadKey();
                Report("Report message", $"{{ \"Report#\": \"{i}\" }}");
            }
        }

        public static void Report(string message, string data = "{}")
        {
            if (data == null)
            {
                data = "{}";
            }

            string body = @"{""message"":""" + message + @""", ""version"":""" + "2.4.6-b3" + @""", ""json"":" + data + @"}";

            try
            {
                var response = Client.PostAsync(@"http://localhost:53879/error", new StringContent(body, Encoding.UTF8, "application/json")).Result;
                Console.WriteLine("Report sent: " + body);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response);
                    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (ThreadAbortException)
            {
                Console.WriteLine("Thread aborted");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to send error to EDDP\r\n" + ex);
            }
        }
    }
}
