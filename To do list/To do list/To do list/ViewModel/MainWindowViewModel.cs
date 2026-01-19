using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using To_do_list.Model;

namespace To_do_list.ViewModel
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public RelayCommand AddTask { get; }
        public RelayCommand RemoveTask { get; }

        public MainWindowViewModel()
        {
            Tasks = new ObservableCollection<Quest>();
            Tasks.Add(new Quest() { Content = "zalít kytky" });

            AddTask = new RelayCommand(_ => AddItem());
            RemoveTask = new RelayCommand(_ => DeleteItem(), _ => SelectedItem != null);
        }


        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Quest>   Tasks { get; set; }

        private void AddItem()
        {
            Tasks.Add(new Quest()
            {
                Content = "Nový úkol",
            });
        }
        private Quest selectedItem;
        public Quest SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }

        private void DeleteItem()
        {
            if (SelectedItem != null)
                Tasks.Remove(SelectedItem);
        }

    }
}
