using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace SeaBattleWPF.ViewModel
{
   public class MainVM : INotifyPropertyChanged
    {
        public MainVM()
        {
        }
        //public void Go(object sender, ExecutedRoutedEventArgs e)
        //{
        //    MessageBox.Show("+");
        //}
        public RelayCommand Start
        {
            get
            {
                return new RelayCommand(() =>
                {
                    try
                    {
                        MessageBox.Show("+");
                       // MessageBox.Show(Button.TagProperty.Name);
                    }
                    catch { }
                });
            }

        }
        private int selectedButton;
        public int SelectedButton
        {
            get { return selectedButton; }
            set
            {
                selectedButton = value;
                OnPropertyChanged("SelectedButton");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
