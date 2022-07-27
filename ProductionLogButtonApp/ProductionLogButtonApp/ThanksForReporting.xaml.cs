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
using System.Windows.Shapes;

namespace ProductionLogButtonApp
{
    /// <summary>
    /// Interaction logic for ThanksForReporting.xaml
    /// </summary>
    public partial class ThanksForReporting : Window
    {
        public ThanksForReporting()
        {
            InitializeComponent();
        }

        private void ButtonAddName_Click2(object sender, RoutedEventArgs e)
        {
            var labelsWindow = new LabelsWindow();
            labelsWindow.Show();
            Close();
        }
    }
}
