using System;
using System.Collections.Generic;
using System.Data;
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
            DataSet ds = zdcz.AllZutoDataSet();
            datasetbind.ItemsSource = ds.Tables[0].DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}
