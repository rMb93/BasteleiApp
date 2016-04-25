using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Calculator {
  [TestFixture]
  public class TestClass {
    [Test]
    public void CheckSummation() {
      Calculator calc = new Calculator();
      int result = calc.Add(4, 6);
      Assert.AreEqual(result, 10);
    }
  }
}
