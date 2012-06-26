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
using NLog;

namespace TaskAsyncDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Logger _log = LogManager.GetCurrentClassLogger();

        Download _download;
        string _hyperTextResult;
        List<Uri> _binaries;

        public MainWindow()
        {
            InitializeComponent();
            _download = new Download();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _log.Info("begin awaiting hypertext");
            //get hypertext
            string text = await Task.Run(()=>_download.GetHypertext(new Uri("https://twitter.com/#!/DrivenLogic/followers")));
            textBox1.Text = text;

            _log.Info("Ended Awaiting hypertext");

            //parse content

            //download binaries 

            //process results
            
        }


        /// <summary>
        /// the continuation for hypertext downloads
        /// </summary>
        /// <param name="task"></param>
        private void CompletedDownloadHypertext(Task<string> task)
        {
            _hyperTextResult = task.Result;
        }

        /// <summary>
        /// the continuation for hypertext downloads
        /// </summary>
        /// <param name="task"></param>
        private void CompletedDownloadBinary(Task<byte[]> task)
        {


        }
    }
}
