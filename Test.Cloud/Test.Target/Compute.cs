using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Target.Interface;

namespace Test.Target
{
    public class Compute : ICompute
    {
        public Compute()
        {
            
        }

        public Compute(int a)
        {
            
        }

        public int GetSharePrice(string name)
        {
            if (name.StartsWith("a"))
            {
                return 1234;
            }
            return 4567;
        }
        public int Value { get; set; }

        public static string GetString()
        {
            return "name";
        }
    }
}
