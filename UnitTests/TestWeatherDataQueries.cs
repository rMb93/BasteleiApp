using System;
using BasteleiApp.ViewModels;
using NUnit.Framework;

namespace Tests {
  [TestFixture]
  public class TestWeatherDataQueries {
    [Test]
    public void CheckGettingLocationData() {
      DataPresentationViewModel dataPresentationVM = new DataPresentationViewModel();
      Assert.That(dataPresentationVM.Locations.Count, Is.AtLeast(1));
    }

    [Test]
    public void CheckGettingWeatherData() {
      DataPresentationViewModel dataPresentationVM = new DataPresentationViewModel();
      dataPresentationVM.SelectedTimeSpan = "Year";
      dataPresentationVM.SelectedLocation = new LocationViewModel("Stefans Zimmer");
      dataPresentationVM.RefreshData();
      while (!dataPresentationVM.GetDataTask.IsCompleted) {}
      Assert.That(dataPresentationVM.Diagrams.Count, Is.AtLeast(1));
    }
  }
}
