using System;
using BasteleiApp.ViewModels;
using NUnit.Framework;
using BasteleiApp.Repositories;
using BasteleiApp.Models;

namespace UnitTests {
  [TestFixture]
  class TestLoad {
    [Test]
    public void LoadLocations() {
      DataPresentationViewModel dataPresentationVM = new DataPresentationViewModel();
      for(int i = 0; i < 100000; i++) {
        dataPresentationVM.Locations.Add(new LocationViewModel("test"));
      }
      Assert.GreaterOrEqual(dataPresentationVM.Locations.Count, 100000);
    }
  }
}
