using SeaBattleWPF.ViewModel;
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
            DataContext = new MainVM();
            int count = 1;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button button = new Button() {};
                    button.SetBinding(Button.CommandProperty, new Binding("RemoveCommand"));
                    button.CommandParameter = count.ToString();
                    //button.Content = "+";
                    GridField.Children.Add(button);
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);

                    Button button_bot = new Button() { };
                    button_bot.SetBinding(Button.CommandProperty, new Binding("Shot"));
                    button_bot.CommandParameter = count.ToString();
                    //button.Content = "+";
                    GridField_Bot.Children.Add(button_bot);
                    Grid.SetRow(button_bot, i);
                    Grid.SetColumn(button_bot, j);
                    count++;
                }
            }
           // GridField.SetBinding(Grid.ColumnProperty, new Binding("GridField"));
            MainVM.GridField = GridField;
            MainVM.GridField_Bot = GridField_Bot;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show("++++");
        }
    }
}
