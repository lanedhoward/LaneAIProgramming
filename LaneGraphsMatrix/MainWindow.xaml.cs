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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaneGraphsMatrix
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<TextBox> boxes;
        public MainWindow()
        {
            InitializeComponent();
            boxes = new List<TextBox>();
        }

        public void InitGrid()
        {
            for (int x = 1; x <= 9; x++)
            {
                for (int y = 1; y <= 9; y++)
                {
                    TextBox tb = new TextBox();
                    tb.Name = $"tb_{x}_{y}";
                    Grid.SetColumn(tb, x);
                    Grid.SetRow(tb, y);
                    matrixGrid.Children.Add(tb);
                    boxes.Add(tb);

                    if (x == y)
                    {
                        tb.Text = "0";
                        tb.IsReadOnly = true;
                    }
                }
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitGrid();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            // parse text, make edge helpers, send them to new form
            List<MatrixEdgeHelper> helpers = new List<MatrixEdgeHelper>();

            foreach (TextBox tb in boxes)
            {
                if (!String.IsNullOrEmpty(tb.Text))
                {
                    int x = int.Parse(tb.Name.Substring(3, 1));
                    int y = int.Parse(tb.Name.Substring(5, 1));
                    bool connection = tb.Text == "1";
                    helpers.Add(new MatrixEdgeHelper(x, y, connection));

                }
            }

            //send to form
            DisplayGraphWindow display = new DisplayGraphWindow(helpers);
            display.Show();

        }
    }
}
