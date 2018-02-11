using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace wpsusage
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter= "xml文件(*.xml)|*.xml|所有文件|*.*";
            ofd.ShowDialog();
            srcfile.Text = ofd.FileName;
            /*
            Excel.Application application = new Excel.Application();
                if(application!=null)
            {
                application.Visible = true;

                MessageBox.Show("成功");
            }*/
            
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (srcfile.Text == "")
            {
                MessageBox.Show("请选择文件");
            }
            else
            {
                ZDCUNZU zdcz = new ZDCUNZU(srcfile.Text);
                if(zdcz.AllZu.Count==0)
                {
                    MessageBox.Show("请选择正确文件");
                    return;
                }
                zdcz.display();
                DataPerView dataPerView = new DataPerView(ref zdcz);
                dataPerView.Show();
            }
        }
    }
}
