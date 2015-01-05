using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;

//using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Data;
using Fiszki.Annotations;
using Fiszki.Data;

namespace Fiszki
{
    /// <summary>
    /// Interaction logic for DeleteWordWindow.xaml
    /// </summary>
    
    public partial class DeleteWordWindow : INotifyPropertyChanged
    {

	    private ICollectionView _wordsCollectionView;

	    public ICollectionView WordsCollectionView
	    {
		    get
		    {
			    return _wordsCollectionView;
		    }
		    set
		    {
			    _wordsCollectionView = value;
			    OnPropertyChanged();
		    }
	    }
        public DeleteWordWindow()
        {
            InitializeComponent();
	        DataContext = this;
	        WordsCollectionView = CollectionViewSource.GetDefaultView(Data.Data.Words);

        }
        private void Click_GoBack(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            new MainWindow().Show();

        }
        private void Click_Delete(object sender, RoutedEventArgs e)  //funkcja usuwająca zaznaczone słówka
        {
            
        }


	    public event PropertyChangedEventHandler PropertyChanged;

	    [NotifyPropertyChangedInvocator]
	    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	    {
		    var handler = PropertyChanged;
		    if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
	    }

	    private void DeleteWord(object sender, RoutedEventArgs e)
	    {
		    var button = (Button) sender;
		    var word = (Word) button.Tag;
			
		    Data.Data.Words.Remove(word);
		    WordsCollectionView.Refresh();
		    DatabaseConnection.Execute("Delete from Word where id=" + word.Id); //.ExecuteNonQuery();  <- z tym wywalało błąd
	    }
    }
}
