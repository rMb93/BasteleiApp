using System;
using BasteleiApp.ViewModels;
using NUnit.Framework;

namespace Tests {
  [TestFixture]
  public class TestWeatherDataQueries {
    [Test]
    public void CheckGettingLocationData() {
      DataPresentationViewModel dataPresentationVM = new DataPresentationViewModel();
      Assert.That(dataPresentationVM.Locations.Count, Is.EqualTo(3));
    }
  }
}
