
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SQLite;
using System.Data;
using Xceed.Wpf.Toolkit;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Fiszki.Annotations;
using Xceed.Wpf.DataGrid;


namespace Fiszki
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddWordWindow : INotifyPropertyChanged
    {
        private ICollectionView _comboItemsView;

        public AddWordWindow()
        {
            InitializeComponent();

            ComboItems = CollectionViewSource.GetDefaultView(new List<string>());

        }

        public ICollectionView ComboItems
        {
            get { return _comboItemsView; }
            set
            {
                _comboItemsView = value;
                OnPropertyChanged();
            }
        }



        private void Click_GoBack(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
          

            new MainWindow().Show();

        }
        private void Click_Add(object sender, RoutedEventArgs e)
        {
            BindingExpression plword = PlWord.GetBindingExpression(TextBox.TextProperty);
            plword.UpdateSource();
            BindingExpression spword = SpWord.GetBindingExpression(TextBox.TextProperty);
            spword.UpdateSource();
            SQLiteConnection oSqLiteConnection = new SQLiteConnection("Data Source=Fisz.s3db");
            oSqLiteConnection.Open();

            // SQLiteCommand command = new SQLiteCommand(add, oSQLiteConnection);
            using (var add = new SQLiteCommand(oSqLiteConnection))
            {
                using (var transaction = oSqLiteConnection.BeginTransaction())
                {
                    add.CommandText = "INSERT INTO WORD(PLWORD,SPWORD) VALUES('" + PlWord.Text + "','" + SpWord.Text + "')";

                    add.ExecuteNonQuery();
                    transaction.Commit();
                    oSqLiteConnection.Close();


                }
            }

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


        