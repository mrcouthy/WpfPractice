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

namespace trymahap
{
    using System.Collections;
    using System.ComponentModel;
    using System.Threading;

    /// <summary>
    /// Interaction logic for BackGroundWorkingDialog.xaml
    /// </summary>
    public partial class BackGroundWorkingDialog : Window
    {
        private BackgroundWorker backgroundWorker;

        public BackGroundWorkingDialog()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
        }


        private void InitializeBackgroundWorker()
        {
            backgroundWorker = new BackgroundWorker();

            // Background Process
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;

            // Progress Reporting
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;

            // Cancellation
            backgroundWorker.WorkerSupportsCancellation = true;

        }

        // Runs on UI Thread
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            int iterations = 0;

            if (int.TryParse(InputTextBox.Text, out iterations))
            {
                if (!backgroundWorker.IsBusy)
                    backgroundWorker.RunWorkerAsync(iterations);

                StartButton.IsEnabled = !backgroundWorker.IsBusy;
                CancelButton.IsEnabled = backgroundWorker.IsBusy;
                OutputTextBox.Text = string.Empty;
            }
        }

        // Runs on UI Thread
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            backgroundWorker.CancelAsync();
        }

        // Runs on Background Thread
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //throw new Exception("Something Bad Happened");

            BackgroundWorker worker = (BackgroundWorker)sender;

            int result = 0;
            int iterations = (int)e.Argument;

            SlowProcessor processor = new SlowProcessor(iterations);
            foreach (var current in processor)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                if (worker.WorkerReportsProgress)
                {
                    int percentageComplete =
                        (int)((float)current / (float)iterations * 100);
                    string progressMessage =
                        string.Format("Iteration {0} of {1}", current, iterations);
                    worker.ReportProgress(percentageComplete, progressMessage);
                }
                result = current;
            }

            e.Result = result;
        }

        // Runs on UI Thread
        private void backgroundWorker_RunWorkerCompleted(object sender,
            RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                OutputTextBox.Text = e.Error.Message;
                MessageBox.Show(e.Error.StackTrace);
            }
            else if (e.Cancelled)
            {
                OutputTextBox.Text = "Cancelled";
            }
            else
            {
                OutputTextBox.Text = e.Result.ToString();
                MainProgressBar.Value = 0;
            }
            StartButton.IsEnabled = !backgroundWorker.IsBusy;
            CancelButton.IsEnabled = backgroundWorker.IsBusy;
        }

        // Runs on UI Thread
        void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MainProgressBar.Value = e.ProgressPercentage;
            OutputTextBox.Text = e.UserState.ToString();
        }
    }

    public class SlowProcessor : IEnumerable<int>
    {
        private int currentPosition;
        private int totalIterations;

        public SlowProcessor(int iterations)
        {
            totalIterations = iterations;
        }

        public IEnumerator<int> GetEnumerator()
        {
            currentPosition = 0;
            while (currentPosition < totalIterations)
            {
                Thread.Sleep(100);
                currentPosition++;
                yield return currentPosition;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
