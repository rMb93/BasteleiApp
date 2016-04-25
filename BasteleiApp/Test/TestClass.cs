using System;
using BasteleiApp.ViewModels;
using NUnit.Framework;  

namespace UnitTests {
  [TestFixture]
  public class TestClass {
    [Test]
    public void CheckGettingLocationData() {
      DataPresentationViewModel dataPresentationVM = new DataPresentationViewModel();
      Assert.That(dataPresentationVM.Locations.Count, Is.EqualTo(3));
    }
  }
}
