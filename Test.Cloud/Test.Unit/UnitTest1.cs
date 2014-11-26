using System;
using System.Fakes;
using System.Globalization;
using System.Runtime;
using System.Runtime.Remoting.Messaging;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;
using Test.Target;
using Test.Target.Fakes;
using Test.Target.Interface;

namespace Test.Unit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var instance = new ComputeAdd();
            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2013,1,1);
                Assert.AreEqual<bool>(true,instance.IsLtCurrentYear()); 
            }
            Assert.AreEqual<bool>(false, instance.IsLtCurrentYear());
        }

        [TestMethod]
        public void TestMethod2()
        {
            var instance = new Compute();
            int result = instance.GetSharePrice("aa");
            Assert.AreEqual(1234,result);
            int result2 = instance.GetSharePrice("bb");
            Assert.AreEqual(4567, result2);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var instance = new ComputeAdd();
            var compute = new Test.Target.Interface.Fakes.StubICompute()
                               {
                                   GetSharePriceString = (name) => 5678
                               };
            instance.Compute = compute;
            int result = instance.DataAdd();
            Assert.AreEqual(5679, result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var compute = new Test.Target.Interface.Fakes.StubICompute();
            compute.GetSharePriceString = (name) => 1;
        }
        [TestMethod]
        public void TestMethod5()
        {
            int i = 3014;
            var compute = new Test.Target.Interface.Fakes.StubICompute();
            compute.ValueGet = () => i;
            ICompute iCompute = compute;
            Assert.AreEqual(13154, iCompute.Value);
            compute.ValueSetInt32 = (value) => i = value;
        }

        [TestMethod]
        public void TestMethod6()
        {
            // unit test code
            var withEvents = new Test.Target.Interface.Fakes.StubIWithEvents();
            // raising Changed
            withEvents.ChangedEvent = (sender, e) => { };
            withEvents.ChangedEvent(null, null);
        }

        [TestMethod]
        public void TestMethod7()
        {
            var stub = new Test.Target.Interface.Fakes.StubIGenericMethod();
            stub.GetValueOf1<int>(() => 5);
            IGenericMethod target = stub;
            Assert.AreEqual(5, target.GetValue<int>());
        }

        [TestMethod]
        public void TestMethod8()
        {
            var stub = new Test.Target.Fakes.StubMyClass();
            stub.DoAbstractInt32 = (x) => Assert.IsTrue(x > 0);
            stub.DoVirtualInt32 = (n) => 10;
            MyClass test = stub;
            test.DoAbstract(10);
            Assert.AreEqual(10,stub.DoVirtualInt32(-1));
        }

        [TestMethod]
        public void TestMethod9()
        {
            FakesDelegates.Func<string,int> shim = name => 5;
           // ShimDateTime.AllInstances;
        }
        [TestMethod]
        public void TestMethod10()
        {
            using (ShimsContext.Create())
            {
                var instance = new ShimCompute()
                               {
                                   ValueGet = () => 1,
                                   GetSharePriceString = (s) => 555
                               };
                //ShimCompute.Constructor = (value) => {};
                ShimCompute.AllInstances.GetSharePriceString = (compute, s) => 555;
                var c = new Compute();
                Assert.AreEqual(555, c.GetSharePrice(""));
                ShimCompute.GetString = () => "cc1";
                Assert.AreEqual("cc1",Compute.GetString());
            }
        }

        [TestMethod]
        public void TestMethod11()
        {
            //StubCompute.GetString = () => "cc1";
        }
    }
}
