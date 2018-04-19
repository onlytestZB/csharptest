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

namespace Sudoku
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {          
            for(int i=0;i<9;i++)
            {
   
                for (int j=0;j<9;j++)
                {
                    TextBox textBox = new TextBox();
                    textBox.Width = 70;
                    textBox.Height = 70;
                    textBox.Text = i+" "+j;
                    
                    Thickness thickness = new Thickness();
                    thickness.Left = j * 70;
                    thickness.Top = i*70;
                    thickness.Right =0;
                    thickness.Bottom = 0;
                    textBox.Margin = thickness;
                    Console.WriteLine("文本框{0}:{1}", i, j);
                    textBox.SetValue(Grid.RowProperty, i);
                    textBox.SetValue(Grid.ColumnProperty, j);
                    MainGrid.Children.Add(textBox);
                }               

            }
        }
    }
}
