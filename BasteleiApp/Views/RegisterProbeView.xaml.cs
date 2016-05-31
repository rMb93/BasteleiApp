using System;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Maps.MapControl.WPF;
using Microsoft.Maps.MapControl.WPF.Design;
using BasteleiApp.ViewModels;


namespace BasteleiApp.Views {
  /// <summary>
  /// Interaction logic for RegisterProbeView.xaml
  /// </summary>
  public partial class RegisterProbeView : UserControl {
        
    public RegisterProbeView() {
            InitializeComponent();
        }

        /*
        public void PlacePushpin(object sender, MouseButtonEventArgs e) {

      if(ProbeMap.Children.Count != 0) {
        ProbeMap.Children.Clear();
      }
      // Disables the default mouse double-click action.
      e.Handled = true;

      // Determin the location to place the pushpin at on the map.

      //Get the mouse click coordinates
      Point mousePosition = e.GetPosition(ProbeMap);
      //Convert the mouse coordinates to a locatoin on the map
      Location pinLocation = ProbeMap.ViewportPointToLocation(mousePosition);
      Pushpin.Location = pinLocation;
      ProbeMap.SetValue(MapLayer.PositionProperty, Pushpin.Location);
      //Pushpin.Location.Longitude = pinLocation.Longitude;
      
    }*/
    }
}
