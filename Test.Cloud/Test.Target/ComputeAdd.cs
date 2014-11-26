using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Target.Interface;

namespace Test.Target
{
    public class ComputeAdd
    {
        public  ICompute Compute { get; set; }

        public ComputeAdd()
        {
            Compute = new Compute();
        }

        public int DataAdd()
        {
            return Compute.GetSharePrice("aa") + 1;
        }


        public bool IsLtCurrentYear()
        {
            var time = DateTime.Now;
            if (time.Year < 2014)
            {
                return true;
            }
            return false;
        }
        public int DataAbb()
        {
            var comp = new Compute(1);
            return Compute.GetSharePrice("aa") + 1;
        }

    }
}
