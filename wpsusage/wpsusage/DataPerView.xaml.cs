using System;
using System.Data;
using System.Windows;
using System.Collections.Generic;
using System.Linq;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;

using ExportToExcel;
using Microsoft.Win32;
using DocumentFormat.OpenXml.Wordprocessing;

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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataSet dataset = zdcz.AllZutoDataSet();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "excel文件(*.xlsx)|*.xlsx|所有文件|*.*";
            sfd.ShowDialog();
            string excelFilename = sfd.FileName;
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

        private void exportword_Click(object sender, RoutedEventArgs e)
        {
            string path = @"model.docx";
            using (WordprocessingDocument doc = WordprocessingDocument.Open(path, true))
            {
                List<Text> textList = new List<Text>();
                Body body = doc.MainDocumentPart.Document.Body;
                foreach (Paragraph paragraph in body.Elements<Paragraph>())
                {
                    if (paragraph.InnerText.Contains("$zheng"))
                    {
                        foreach (Run run in paragraph.Elements<Run>())
                        {
                            textList.AddRange(run.Elements<Text>());
                        }
                        paragraph.Elements<Run>().FirstOrDefault().Append(new Text("城东街道"));
                    }
                }
                foreach (Table table in body.Elements<Table>())
                {
                    foreach (TableRow tableRow in table.Elements<TableRow>())
                    {
                        foreach (TableCell tableCell in tableRow.Elements<TableCell>())
                        {
                            if (tableCell.InnerText.Contains(("$zheng")))
                            {
                                foreach (Paragraph paragraph in tableCell.Elements<Paragraph>())
                                {
                                    foreach (Run run in paragraph.Elements<Run>())
                                    {
                                        textList.AddRange(run.Elements<Text>());
                                    }
                                }
                                tableCell.Elements<Paragraph>().FirstOrDefault().Elements<Run>().FirstOrDefault().Append(new Text("城东街道"));
                            }
                        }
                    }
                }
                foreach (var removeText in textList)
                {
                    removeText.Remove();
                }
            }
        }
    }
}
