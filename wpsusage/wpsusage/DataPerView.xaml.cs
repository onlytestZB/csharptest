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
using ExportToExcel;

namespace wpsusage
{
    /// <summary>
    /// DataPerView.xaml 的交互逻辑
    /// </summary>
    public partial class DataPerView : System.Windows.Window
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
            DataView dv = datasetbind.ItemsSource as DataView;
            for(int i=0;i<dv.Table.Columns.Count;i++)
            {
                if(dv.Table.Columns[i].ColumnName=="011")
                {
                    dv.Table.Columns[i].ColumnName = "011水田";
                }               
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataSet dataset = zdcz.AllZutoDataSet();
            string excelFilename = "Sample.xlsx";
            try
            {
                
                CreateExcelFile.CreateExcelDocument(dataset, excelFilename);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Couldn't create Excelfile.\r\nException: " + ex.Message);
                return;
            }
            MessageBox.Show(excelFilename + "生成成功");
            CreateExcelFile.CreateExcelDocument(dataset, "test.xlsx");
        }
    }
}
