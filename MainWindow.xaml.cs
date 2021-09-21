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

namespace RoomEditor {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        int rows = 4;
        int cols = 4;

        public MainWindow() {
            InitializeComponent();

            CreateGrid();

            FillGrid();

            GridPrintOut();
        }

        private void FillGrid() {
            for (int x = 0; x < gridRoom.RowDefinitions.Count; x++) {
                for (int y = 0; y < gridRoom.ColumnDefinitions.Count; y++) {
                    Button btn = new Button();

                    btn.SetValue(Grid.RowProperty, x);
                    btn.SetValue(Grid.ColumnProperty, y);

                    btn.Tag = $"{x},{y}";
                    btn.Click += Button_OnClick;
                    gridRoom.Children.Add(btn);
                }
            }
        }

        private void GridPrintOut() {
            List<string> output = new List<string>();
            
            foreach (Control item in gridRoom.Children) {
                output.Add(item.Tag as string);
            }
        }

        public void CreateGrid() {
            for (int row = 0; row < rows; row++) {
                RowDefinition _row = new RowDefinition();
                _row.Height = new GridLength(1, GridUnitType.Star);
                gridRoom.RowDefinitions.Add(_row);
            }

            for (int col = 0; col < cols; col++) {
                ColumnDefinition _col = new ColumnDefinition();
                _col.Width = new GridLength(1, GridUnitType.Star);
                gridRoom.ColumnDefinitions.Add(_col);
            }
        }


        private void Button_OnClick(Object sender, EventArgs e) {
            Button obj = sender as Button;
            string row = obj.GetValue(Grid.RowProperty).ToString();
            string column = obj.GetValue(Grid.ColumnProperty).ToString();
        }
    }
}
