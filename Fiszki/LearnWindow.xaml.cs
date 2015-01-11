using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using Fiszki.Annotations;
using Fiszki.Data;

namespace Fiszki
{

	public partial class LearnWindow : INotifyPropertyChanged
	{
		public static int Clamp(int value, int min, int max)
		{
			return value < min ? min : value > max ? max : value;
		}

		public int BadAnswersCounter { get; set; }
		public int GoodAnswersCounter { get; set; }
		private List<Word> Words;
		public int WordsCount;
		public Category Category;

		public LearnWindow()
		{
			InitializeComponent();

			DataContext = this;
			if (Words == null)
			{
				Words = new List<Word>();
				Words.Add(Data.Data.Words.FirstOrDefault());
			}
		}
		private void Click_GoBack(object sender, RoutedEventArgs e)
		{
			new MainWindow().Show();
			Close();
		}

		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated(e);
			if (Words == null || Words.Count != WordsCount)
			{
				Random rnd = new Random(DateTime.Now.Second);
				Words = Data.Data.Words.Where(t => t.CategoryId == Category.Id).OrderBy(k => rnd.Next()).Take(WordsCount).ToList();
				CurrentWordIdx = 0;
				OnPropertyChanged("CurrentPlWord");
				OnPropertyChanged("CurrentEsWord");
			}
		}

		private int CurrentWordIdx { get; set; }

		public string CurrentPlWord
		{
			get { return Words[Clamp(CurrentWordIdx, 0, Words.Count - 1)].PlWord; }
		}

		public string CurrentEsWord
		{
			get { return Words[Clamp(CurrentWordIdx, 0, Words.Count - 1)].SpWord; }
		}

		private void Click_Check(object sender, RoutedEventArgs e)
		{

			if (CurrentPlWord.ToLower().Equals(TranslateBox.Text.ToLower()))
			{
				AnswerLabel.Foreground = Brushes.LawnGreen;
				AnswerLabel.Content = "Bardzo dobrze!";
				GoodAnswersCounter++;                        //tutaj możnaby dodać odpowiedzi pobierane z bazy danych 

				Words[CurrentWordIdx].Counter = Clamp(Words[CurrentWordIdx].Counter + 1, 0, 5);
			}                                              //zaleznie jaki wynik jest w danym słowie
			else
			{
				AnswerLabel.Foreground = Brushes.Red;
				AnswerLabel.Content = CurrentPlWord;  //tutaj to samo, albo zrobić po kilka, jesli zgadnie lub nie
				BadAnswersCounter++;                          //tu trzeba zrobić update dla wyniku na danym słowie w bazie
				Words[CurrentWordIdx].Counter = Clamp(Words[CurrentWordIdx].Counter - 1,0,5);
			}
			TranslateBox.IsEnabled = false;
		}

		private void Next_Word(object sender, RoutedEventArgs e) //
		{
			CurrentWordIdx ++;
			OnPropertyChanged("CurrentPlWord");
			OnPropertyChanged("CurrentEsWord");

			ProgressBar.Value += 1;

			TranslateBox.Clear();
			AnswerLabel.Content = "";
			TranslateBox.IsEnabled = true;
			CounterWordLabel.Content = (CurrentWordIdx + 1).ToString("0");
			if (CurrentWordIdx == Words.Count - 1)
			{
				NextButton.Visibility = Visibility.Hidden;
				NextButton.IsEnabled = false;
				ShowResultsButton.Visibility = Visibility.Visible;
			}
		}

		private void Click_ShowResults(object sender, RoutedEventArgs e)
		{
			ResultsWindow resultsWindow = new ResultsWindow();
			resultsWindow.BadAnswersProgressBar.Value = BadAnswersCounter * 100 / (BadAnswersCounter + GoodAnswersCounter);
			resultsWindow.GoodAnswersProgressBar.Value = GoodAnswersCounter * 100 / (BadAnswersCounter + GoodAnswersCounter); //Convert.ToInt32(GoodAnswersCounter/Convert.ToInt32(MaxWordLabel.Content) * 100);
			resultsWindow.GoodTextBlock.Text = resultsWindow.GoodAnswersProgressBar.Value + "%";
			resultsWindow.BadTextBlock.Text = resultsWindow.BadAnswersProgressBar.Value + "%";
			resultsWindow.Show();
			Data.Data.UpdateWords();
			Close();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}

}
