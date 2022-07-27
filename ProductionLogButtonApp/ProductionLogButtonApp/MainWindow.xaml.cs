using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;

namespace ProductionLogButtonApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string _rootFolderPath = "ProductionLogs";
        private readonly string _destinationPath = @"C:\Retalix\ProductionLogs";
        public MainWindow()
        {
            InitializeComponent();
            new Thread(() =>
            {
                bool flag = true;
                while (flag)
                {
                    Process[] pname = Process.GetProcessesByName("Retalix.Client.POS.Shell");
                    if (pname.Length == 0)
                    {
                        MoveToFile();
                        flag = false;
                    }
                }
                Process.GetProcessesByName("ProductionLogButtonApp")[0].Kill();
            }).Start();
        }

        private void ButtonAddName_Click(object sender, RoutedEventArgs e)
        {
            var labelsWindows = new LabelsWindow();
            labelsWindows.Show();
            Close();
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

        private void Window_Deactivated(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Topmost = true;
        }
    }
}
