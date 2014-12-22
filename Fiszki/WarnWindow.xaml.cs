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

namespace Fiszki
{
    /// <summary>
    /// Interaction logic for WarnWindow.xaml
    /// </summary>
    public partial class WarnWindow
    {
        public WarnWindow()
        {
            InitializeComponent();
        }

        private void Click_GoBack(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
