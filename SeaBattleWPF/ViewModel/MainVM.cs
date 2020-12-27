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
using System.Windows.Input;

namespace SeaBattleWPF.ViewModel
{
   public class MainVM : INotifyPropertyChanged
    {
        int count = 0;
        public MainVM()
        {
        }

        private RelayCommand addCommand;
        public RelayCommand Start
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {

                      MessageBox.Show("Start");
                  }));
            }

        }


        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      int num = Convert.ToInt32(obj);
                      MessageBox.Show(num.ToString());
                  }
                 ));
            }
        }

        public int SelectedPhone
        {
            get { return count; }
            set
            {
                OnPropertyChanged("SelectedPhone");
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
