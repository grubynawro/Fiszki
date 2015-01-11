using System.Windows;
using System.Data.SQLite;
using System.Data;
using Fiszki.Data;

namespace Fiszki
{
	/// <summary>
	/// Interaction logic for ResetScoreWindow.xaml
	/// </summary>
	public partial class ResetScoreWindow
	{
	
		public ResetScoreWindow()
		{
			InitializeComponent();
		}
	
		private void Click_GoBack(object sender, RoutedEventArgs e)
		{
			Close();
		}
		private void Click_Reset(object sender, RoutedEventArgs e)
		{
			foreach (var word in Data.Data.Words)
				word.Counter = 0;

			Data.Data.UpdateWords();

			Close();
		}
	}
}