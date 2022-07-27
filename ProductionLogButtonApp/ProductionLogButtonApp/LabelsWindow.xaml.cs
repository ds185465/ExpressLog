using System;
using System.IO;
using System.Windows;

namespace ProductionLogButtonApp
{
    /// <summary>
    /// Interaction logic for LabelsWindow.xaml
    /// </summary>
    public partial class LabelsWindow : Window
    {
        private readonly string _rootFolderPath = "ProductionLogs";
        private readonly string _destinationPath = @"C:\Retalix\Hackathon\ProductionLogs";
        public LabelsWindow()
        {
            InitializeComponent();
        }

        private void MoveToFile()
        {
            if (Directory.Exists(_rootFolderPath))
            {
                foreach (var file in new DirectoryInfo(_rootFolderPath).GetFiles())
                {
                    file.MoveTo($@"{_destinationPath}\{file.Name}");
                }
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            MoveToFile();
            var thanksForReportingWindow = new ThanksForReporting();
            thanksForReportingWindow.Show();
            this.Close();
        }
        private void Window_Deactivated(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Topmost = true;
        }
    }
}
