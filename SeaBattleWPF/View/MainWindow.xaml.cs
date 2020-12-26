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
            int count = 1;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button button = new Button() {Tag=count };
                    // Создание привязки
                    CommandBinding bind = new CommandBinding(ApplicationCommands.New);

                    // Присоединение обработчика событий
                    bind.Executed += Go;

                    // Регистрация привязки
                    this.CommandBindings.Add(bind);
                    // button.Command = 
                    //button.SetBinding(Button.CommandProperty, new Binding("Start"));
                    GridField.Children.Add(button);
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    count++;
                }
            }

        }
        private void Go(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Go");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("++++");
        }
    }
}
