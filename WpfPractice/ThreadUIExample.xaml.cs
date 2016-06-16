using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfPractice
{
    /// <summary>
    /// Interaction logic for ThreadUIExample.xaml
    /// </summary>
    public partial class ThreadUIExample : Window
    {
        SlowThing source = new SlowThing();
        public ThreadUIExample()
        {
            InitializeComponent();
            Debug.WriteLine("UI Thread: " + Thread.CurrentThread.ManagedThreadId);
        }

        private void getDataButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Click Thread: " + Thread.CurrentThread.ManagedThreadId);
            ThreadPool.QueueUserWorkItem(DoSlowWork);
        }

        private void DoSlowWork(object state)
        {
            Debug.WriteLine("Worker Thread: " + Thread.CurrentThread.ManagedThreadId);
            string data = source.Data;

            this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                new Action<string>(DoUpdateOnUIThread),
                data);
        }

        private void DoUpdateOnUIThread(string data)
        {
            Debug.WriteLine("Update Thread: " + Thread.CurrentThread.ManagedThreadId);
            outputText.Text = data;
        }
    }

    public class SlowThing
    {
        public string Data
        {
            get
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));

                return "Hello, world";
            }
        }
    }
}
