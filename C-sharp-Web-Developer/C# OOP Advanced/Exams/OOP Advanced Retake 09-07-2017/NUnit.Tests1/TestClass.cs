using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
    [TestFixture]
    public class TestClass
    {

        [Test]
        public void TestMethod()
        {
            var energy = new EnergyRepository();
            var provider = new ProviderController(energy);
            //Provider Pressure 40 100
            var list = new List<string>();
            list.Add("Pressure");
            list.Add("40");
            list.Add("100");

            var result = provider.Register(list);
            var t = "Successfully registered PressureProvider";
            Assert.AreEqual(result, t);
        }

        [Test]
        public void Test2()
        {
            var energy = new EnergyRepository();
            var provider = new ProviderController(energy);

            var list = new List<string>();
            list.Add("Pressure");
            list.Add("40");
            list.Add("100");

            var result = provider.Register(list);
            var t = "Successfully registered PressureProvider";
            Assert.AreEqual(provider.Entities.Count, 1);
        }

        [Test]
        public void Tes2t2()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Produced 200 energy today!");
            sb.AppendLine("Produced 400 ore today!");

            var energy = new EnergyRepository();
            var provider = new ProviderController(energy);

            var list = new List<string>();
            list.Add("Pressure");
            list.Add("40");
            list.Add("100");

            var result = provider.Register(list);
            var t = provider.Produce();
            Assert.AreEqual(t, sb.ToString());
        }
    }
}
