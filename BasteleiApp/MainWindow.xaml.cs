using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace BasteleiApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Beispieldaten für die Zeiträume
        public string[] threeMinutes = { "{'temperature':17.100000381469728,'humidity':40.70000076293945,'airpressure':99423.0,'altitude':159.31381225585938, 'time':'2015 - 11 - 25 18:05:16'}",
                                  "{'temperature':18.100000381469728,'humidity':32.70000076293945,'airpressure':88946.0,'altitude':159.31381225585938, 'time':'2015 - 11 - 25 18:06:16'}",
                                  "{'temperature':20.100000381469728,'humidity':28.70000076293945,'airpressure':112947.0,'altitude':159.31381225585938, 'time':'2015 - 11 - 25 18:07:16'}"};
        public string[] sevendays = { "{'temperature':17.100000381469728,'humidity':40.70000076293945,'airpressure':99423.0,'altitude':159.31381225585938, 'time':'2015 - 11 - 18 18:05:16'}",
                                  "{'temperature':18.100000381469728,'humidity':32.70000076293945,'airpressure':88946.0,'altitude':159.31381225585938, 'time':'2015 - 11 - 19 18:06:16'}",
                                  "{'temperature':20.100000381469728,'humidity':28.70000076293945,'airpressure':112947.0,'altitude':159.31381225585938, 'time':'2015 - 11 - 20 18:07:16'}",
                                  "{'temperature':17.100000381469728,'humidity':40.70000076293945,'airpressure':99423.0,'altitude':159.31381225585938, 'time':'2015 - 11 - 21 18:05:16'}",
                                  "{'temperature':17.100000381469728,'humidity':40.70000076293945,'airpressure':99423.0,'altitude':159.31381225585938, 'time':'2015 - 11 - 22 18:05:16'}",
                                  "{'temperature':17.100000381469728,'humidity':40.70000076293945,'airpressure':99423.0,'altitude':159.31381225585938, 'time':'2015 - 11 - 23 18:05:16'}",
                                  "{'temperature':17.100000381469728,'humidity':40.70000076293945,'airpressure':99423.0,'altitude':159.31381225585938, 'time':'2015 - 11 - 24 18:05:16'}",
                                  "{'temperature':17.100000381469728,'humidity':40.70000076293945,'airpressure':99423.0,'altitude':159.31381225585938, 'time':'2015 - 11 - 25 18:05:16'}"};
        public string[] oneday = { "{'temperature':19.100000381469728,'humidity':40.70000076293945,'airpressure':99423.0,'altitude':159.31381225585938, 'time':'2015 - 11 - 25 00:05:16'}",
                                  "{'temperature':12.100000381469728,'humidity':44.70000076293945,'airpressure':88946.0,'altitude':159.31381225585938, 'time':'2015 - 11 - 25 02:06:16'}",
                                  "{'temperature':22.100000381469728,'humidity':29.70000076293945,'airpressure':112947.0,'altitude':159.31381225585938, 'time':'2015 - 11 - 25 04:07:16'}",
                                  "{'temperature':18.100000381469728,'humidity':32.70000076293945,'airpressure':88946.0,'altitude':159.31381225585938, 'time':'2015 - 11 - 25 06:06:16'}",
                                  "{'temperature':20.100000381469728,'humidity':28.70000076293945,'airpressure':112947.0,'altitude':159.31381225585938, 'time':'2015 - 11 - 25 08:07:16'}",
                                  "{'temperature':17.100000381469728,'humidity':40.70000076293945,'airpressure':99423.0,'altitude':159.31381225585938, 'time':'2015 - 11 - 25 10:05:16'}",
                                  "{'temperature':17.100000381469728,'humidity':40.70000076293945,'airpressure':99423.0,'altitude':159.31381225585938, 'time':'2015 - 11 - 25 12:05:16'}",
                                  "{'temperature':17.100000381469728,'humidity':40.70000076293945,'airpressure':99423.0,'altitude':159.31381225585938, 'time':'2015 - 11 - 25 14:05:16'}",
                                  "{'temperature':17.100000381469728,'humidity':40.70000076293945,'airpressure':99423.0,'altitude':159.31381225585938, 'time':'2015 - 11 - 25 16:05:16'}",
                                  "{'temperature':17.100000381469728,'humidity':40.70000076293945,'airpressure':99423.0,'altitude':159.31381225585938, 'time':'2015 - 11 - 25 18:05:16'}",
                                  "{'temperature':18.100000381469728,'humidity':32.70000076293945,'airpressure':88946.0,'altitude':159.31381225585938, 'time':'2015 - 11 - 25 20:06:16'}",
                                  "{'temperature':20.100000381469728,'humidity':28.70000076293945,'airpressure':112947.0,'altitude':159.31381225585938, 'time':'2015 - 11 - 25 22:07:16'}"};
        LocationCollection LC1 = new LocationCollection();
        DataElementCollection DEC1 = new DataElementCollection();

        public MainWindow()
        {
            
            InitializeComponent();
            
            




        }

        private void loadloc_Click(object sender, RoutedEventArgs e)
        {
            LC1.Clear();
            LC1.GetLocations();
            loclist.ItemsSource = LC1;
        }
        

       private void loclist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            int a = comboBox.SelectedIndex;
            DEC1.Clear();
            if (a == 0)
            {
                DEC1.GetData(threeMinutes);
            }
            else if (a == 1)
            {
                DEC1.GetData(oneday);
            }
            else if (a == 2)
            {
                DEC1.GetData(sevendays);
            }

            else
            {
                MessageBox.Show("Es wurde kein Zeitraum ausgewählt");
            }
            ChartBox.DataContext = DEC1;


        }

    }
}
