using System;
using System.ServiceModel;
using Services;

namespace Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(CalculatorService)))
            {
                //host.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "http://127.0.0.1:9999/calculatorservice");
                //if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
                //{
                //    var behavior = new ServiceMetadataBehavior
                //    {
                //        HttpGetEnabled = true,
                //        HttpGetUrl = new Uri("http://127.0.0.1:9999/calculatorservice/metadata")
                //    };
                //    host.Description.Behaviors.Add(behavior);
                //}
                host.Opened += delegate
                {
                    Console.WriteLine("CalculaorService已经启动，按任意键终止服务！");
                };

                host.Open();
                Console.Read();
            }
        }
    }
}