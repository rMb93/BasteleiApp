using System;
using BasteleiApp.ViewModels;
using NUnit.Framework;  

namespace UnitTests {
  [TestFixture]
  public class TestClass {
    [Test]
    public void CheckGettingWeatherData() {
      DataPresentationViewModel dataPresentationVM = new DataPresentationViewModel();
      Assert.That(dataPresentationVM.ProgessRingIsActive, Is.EqualTo(false));
      dataPresentationVM.RefreshData();
      Assert.That(dataPresentationVM.Diagrams.Count, Is.EqualTo(3));
      Assert.That(dataPresentationVM.ProgessRingIsActive, Is.EqualTo(false));
    }
  }
}
