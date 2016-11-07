using System;
using System.ServiceModel;
using Service.Contracts;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var proxy = new CalculatorServiceClient())
            //{
            //     Console.WriteLine("x + y = {2} when x = {0} and y = {1}", 1, 2, proxy.Add(1, 2));
            // }
            //using (var channelFactory = new ChannelFactory<ICalculator>(new WSHttpBinding(), "http://127.0.0.1:9999/calculatorservice"))
            //{
            //    ICalculator proxy = channelFactory.CreateChannel();
            //    Console.WriteLine("x + y = {2} when x = {0} and y = {1}", 1, 2, proxy.Add(1, 2));
            //}
            var channelFactory = new ChannelFactory<ICalculator>("WSHttpBinding_CalculatorService");
            ICalculator proxy = channelFactory.CreateChannel();
            Console.WriteLine("x + y = {2} when x = {0} and y = {1}", 1, 2, proxy.Add(1, 2));
            channelFactory.Close();
            Console.ReadKey();
        }
    }
}
