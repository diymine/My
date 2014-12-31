using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new ApiTest {Request = {Method = HttpMethod.Get}};
            api.Get();
        }
    }
}
