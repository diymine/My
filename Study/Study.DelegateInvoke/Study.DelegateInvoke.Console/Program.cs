using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Study.DelegateInvoke
{
    class Program
    {
        private static int NewTask(int ms)
        {

            Console.WriteLine("任务开始" + DateTime.Now);

            Thread.Sleep(ms);

            Random random = new Random();

            int n = random.Next(5000);

            Console.WriteLine("任务完成" + DateTime.Now);

            return n;

        }

        private delegate int NewTaskDelegate(int ms);




        static void Main(string[] args)
        {
            NewTaskDelegate task = NewTask;

            IAsyncResult asyncResult = task.BeginInvoke(5000, null, null);

            // EndInvoke方法将被阻塞2秒
            Thread.Sleep(2000);
            Console.WriteLine("主线程时间1：" + DateTime.Now);
            //while (!asyncResult.IsCompleted)
            //{
            //    Console.Write("*");
            //}
            while (!asyncResult.AsyncWaitHandle.WaitOne(2000, false))
            {

                Console.Write("*");
            }
            Console.WriteLine("主线程时间2：" + DateTime.Now);
            int result = task.EndInvoke(asyncResult);
            Console.WriteLine(result);

            Console.ReadKey();


        }
    }
}
