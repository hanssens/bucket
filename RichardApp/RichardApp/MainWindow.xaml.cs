using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Diagnostics;

namespace RichardApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Load configuration
            this.FirstButton.Content = ConfigurationManager.AppSettings["FirstButtonLabel"] ?? "Missing XML";
            this.SecondButton.Content = ConfigurationManager.AppSettings["SecondButtonLabel"] ?? "Missing XML";
            this.ThirdButton.Content = ConfigurationManager.AppSettings["ThirdButtonLabel"] ?? "Missing XML";

            // Hook up events
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = ((Button)sender);
            
            var fileName = ConfigurationManager.AppSettings[button.Name.ToString()];
            var filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Files\", fileName);

            // Start the process
            var tool = new Process();
            tool.StartInfo.FileName = filePath;

            // Ensure no console window appears
            tool.StartInfo.CreateNoWindow = true;
            tool.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            // Execute, and wait for results
            tool.Start();
            
        }


    }
}
