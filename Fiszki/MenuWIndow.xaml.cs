using System;
using System.ComponentModel;
using System.Windows;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using Fiszki.Annotations;
using Fiszki.Data;

namespace Fiszki
{
    /// <summary>
    /// Interaction logic for MenuWIndow.xaml
    /// </summary>
    public partial class MenuWindow : INotifyPropertyChanged
    {
		private ICollectionView _categoryCollectionView;

        public MenuWindow()
        {
            InitializeComponent();
	        DataContext = this;

			CategoryCollectionView = CollectionViewSource.GetDefaultView(Data.Data.Categories);
	        SelectedCategory = Data.Data.Categories.FirstOrDefault();

        }

		public ICollectionView CategoryCollectionView
		{
			get { return _categoryCollectionView; }
			set
			{
				_categoryCollectionView = value;
				OnPropertyChanged();
			}
		}

		public Category SelectedCategory { get; set; }

        private void LearnStartButton_OnClick(object sender, RoutedEventArgs e)
        {
            LearnWindow newWindow = new LearnWindow();
            newWindow.MaxWordLabel.Content = NumberOfWordsBox.Text;
            newWindow.ProgressBar.Maximum = Convert.ToInt32(NumberOfWordsBox.Text);
            
	        newWindow.WordsCount = int.Parse(NumberOfWordsBox.Text);
	        newWindow.Category = SelectedCategory;
			newWindow.Show();
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
