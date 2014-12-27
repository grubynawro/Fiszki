using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Media;

namespace Fiszki
{

    public partial class LearnWindow
    {
        public int BadAnswersCounter { get;  set; }
        public int GoodAnswersCounter { get; set; }
        
        public LearnWindow()
        {
            InitializeComponent();
        }
        private void Click_GoBack(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
 
        private void Window_ContentRendered(object sender, EventArgs e)  //do obsługi progressbara w oddzielnym wątku
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerAsync();
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 101; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(100);
            }
        }
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;
        }
        private void Click_Check(object sender, RoutedEventArgs e)  
        {
            
            ProgressBar.Visibility = Visibility.Hidden;
            if (WordLabel.Content.Equals(TranslateBox.Text))
            {
                AnswerLabel.Foreground = Brushes.LawnGreen;  
                AnswerLabel.Content = "Bardzo dobrze!";
                GoodAnswersCounter++;                        //tutaj możnaby dodać odpowiedzi pobierane z bazy danych 
            }                                              //zaleznie jaki wynik jest w danym słowie
            else
            {
                AnswerLabel.Foreground = Brushes.Red;
                AnswerLabel.Content = "Zjebałeś kolego...";  //tutaj to samo, albo zrobić po kilka, jesli zgadnie lub nie
                BadAnswersCounter++;                          //tu trzeba zrobić update dla wyniku na danym słowie w bazie
            }
            TranslateBox.IsEnabled = false;
        }

        private void Next_Word(object sender, RoutedEventArgs e) //
        {

            int counter = Convert.ToInt32(CounterWordLabel.Content);
            int maxCounter = Convert.ToInt32(MaxWordLabel.Content);
            ProgressBar.Value = 0;
            ProgressBar.Visibility = Visibility.Visible;
            WordLabel.Content = ++counter + "słowo";
            TranslateBox.Clear();
            AnswerLabel.Content = "";
            TranslateBox.IsEnabled = true;
            CounterWordLabel.Content = counter;
            if (counter == maxCounter)
            {
                NextButton.Visibility = Visibility.Hidden;
                NextButton.IsEnabled = false;
                ShowResultsButton.Visibility = Visibility.Visible;
            }

        }

        private void Click_ShowResults(object sender, RoutedEventArgs e)
        {
            ResultsWindow resultsWindow = new ResultsWindow();
            resultsWindow.BadAnswersProgressBar.Value = BadAnswersCounter * 100 / (BadAnswersCounter+GoodAnswersCounter);
            resultsWindow.GoodAnswersProgressBar.Value = GoodAnswersCounter * 100 / (BadAnswersCounter + GoodAnswersCounter); //Convert.ToInt32(GoodAnswersCounter/Convert.ToInt32(MaxWordLabel.Content) * 100);
            resultsWindow.GoodTextBlock.Text = resultsWindow.GoodAnswersProgressBar.Value + "%";
            resultsWindow.BadTextBlock.Text = resultsWindow.BadAnswersProgressBar.Value + "%";
            resultsWindow.Show();
            Close();
        }
    }

}
