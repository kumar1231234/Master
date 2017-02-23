using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //PostRequest("https://posttestserver.com/post.php");

            PostRequest("https://posttestserver.com/post.php");
            Console.ReadLine();
        }

        async static void PostRequest(string url)
        {
            IEnumerable<KeyValuePair<string, string>> quaries = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("query1","jamal"),
            new KeyValuePair<string, string>("query2", "hussain")
            };
            HttpContent q = new FormUrlEncodedContent(quaries);

            using (HttpClient httpclient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMsg = await httpclient.PostAsync(url, q))
                {
                    using (HttpContent content = httpResponseMsg.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        HttpContentHeaders headers = content.Headers;
                        Console.WriteLine(mycontent);

                    }
                }

            }
        }
    }
}
