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

namespace wpsusage
{
    /// <summary>
    /// DataPerView.xaml 的交互逻辑
    /// </summary>
    public partial class DataPerView : Window
    {
        public DataPerView()
        {
            InitializeComponent();
        }
        public ZDCUNZU zdcz;
        public DataPerView(ref ZDCUNZU old_zdcz)
        {
            InitializeComponent();
            zdcz = old_zdcz;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
