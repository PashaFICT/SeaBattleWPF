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

namespace SeaBattleWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //for (int i = 0; i < 10; i++)
            //{
                Button button = new Button();
                GridField.Children.Add(button);
            Grid.SetRow(button, 2);
            Grid.SetColumn(button, 2);
           // }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("++++");
        }
    }
}
