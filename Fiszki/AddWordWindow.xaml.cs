
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SQLite;
using System.Data;
using Xceed.Wpf.Toolkit;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Fiszki.Annotations;
using Fiszki.Data;
using Xceed.Wpf.DataGrid;


namespace Fiszki
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class AddWordWindow : INotifyPropertyChanged
	{
		private ICollectionView _categoryCollectionView;
	
		public AddWordWindow()
		{
			SelectedCategory = Data.Data.Categories.FirstOrDefault();

			InitializeComponent();

			DataContext = this;

			CategoryCollectionView = CollectionViewSource.GetDefaultView(Data.Data.Categories);
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

		public string PlWord { get; set; }

		public string EsWord { get; set; }


		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}

		private void Window_Closing(object sender, CancelEventArgs e)
		{
			new MainWindow().Show();
		}
		private void Click_Add(object sender, RoutedEventArgs e)
		{
			var query =
				DatabaseConnection.Execute("Insert into Word(PLWORD,SPWORD,ID_CATEGORY) values('" + PlWord + "','" + EsWord + "'," +
				                           SelectedCategory.Id + ")").ExecuteNonQuery();

			long lstInsertId = (long)DatabaseConnection.Execute("SELECT last_insert_rowid()").ExecuteScalar();


			Data.Data.Words.Add(new Word(
				System.Convert.ToInt32(lstInsertId),
				PlWord,
				EsWord,
				SelectedCategory.Id,
				0,
				0
				));

		}
		private void Click_GoBack(object sender, RoutedEventArgs e)
		{
			Close();
		}

		
	}
}