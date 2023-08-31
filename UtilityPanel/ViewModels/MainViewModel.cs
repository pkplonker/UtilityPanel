using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace UtilityPanel.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        public ICommand AddCommand { get; private set; }

        private ObservableCollection<LinkViewModel> links;

        public ObservableCollection<LinkViewModel> Links
        {
            get => this.links;
            set
            {
                if (value != links)
                {
                    links = value;
                    OnPropertyChanged(nameof(Links));
                }
            }
        }

        public MainViewModel()
        {
            AddCommand = new Command(_ => AddElement(), null);
            links = new ObservableCollection<LinkViewModel>();
            for (int i = 0; i < 10; i++)
            {
                AddElement();
            }
        }

        private void AddElement()
        {
            links.Add(new LinkViewModel(links.Count.ToString(), (element) => links.Remove(element)));
        }
    }
}