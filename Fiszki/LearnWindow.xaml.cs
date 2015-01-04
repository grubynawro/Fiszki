using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Media;

namespace Fiszki
{

    public partial class LearnWindow
    {
   
        public LearnWindow()
        {
            InitializeComponent();
        }
        private void Click_GoBack(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
 

        private void Click_Check(object sender, RoutedEventArgs e)  
        {
            
            if (WordLabel.Content.Equals(TranslateBox.Text)) 
            {
                AnswerLabel.Foreground = Brushes.LawnGreen;  
                AnswerLabel.Content = "Bardzo dobrze!";   //tutaj możnaby dodać odpowiedzi pobierane z bazy danych 
            }                                              //zaleznie jaki wynik jest w danym słowie
            else
            {
                AnswerLabel.Foreground = Brushes.Red;
                AnswerLabel.Content = "Zjebałeś kolego...";   //tutaj to samo, albo zrobić po kilka, jesli zgadnie lub nie
            }
            //tu trzeba zrobić update dla wyniku na danym słowie
        }

        private void Next_Word(object sender, RoutedEventArgs e) //
        {
            int counter = Convert.ToInt32(CounterWordLabel.Content);
            int maxCounter = Convert.ToInt32(MaxWordLabel.Content);
            ProgressBar.Value += 1;
            WordLabel.Content = ++counter + "słowo";
            CounterWordLabel.Content = counter;
            if (counter == maxCounter)
            {
                NextButton.Content = "Wyniki";
                NextButton.Click += Click_GoBack;
            }
            
        }
    }

}
