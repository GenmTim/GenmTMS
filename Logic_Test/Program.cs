
using RestSharp;
using RestSharp.Authenticators;
using System;

namespace Logic_Test
{
    class Program
    {
        public class Point
        {
            public int x;
            public int y;
        }

        public class HomeTimeline
        {
            int t;
            int b;
        }



        static async System.Threading.Tasks.Task Main(string[] args)
        {
            //HttpClient serviceApi = new HttpClient();

            //serviceApi.GetCompany(101);

            //var client = new RestClient("https://api.twitter.com/1.1");
            //client.Authenticator = new HttpBasicAuthenticator("username", "password");
            //var request = new RestRequest("statuses/home_timeline.json", DataFormat.Json);

            //var timeline = await client.ExecuteAsync<HomeTimeline>(request);

            //client.Req

            //var timeline = await client.GetAsync<HomeTimeline>(request, cancellationToken);

            float sum = 0;
            int i = 0;
            while (sum < 100)
            {
                Console.Write("输入第{0}次筹款的金额（单位：万元） : ", i);
                float x = Convert.ToSingle(Console.ReadLine());
                sum += x;
                Console.WriteLine("{0} 次筹款总金额 ：{1}", i, sum);
                i++;

            }
            Console.ReadKey();
        }
    }
}
