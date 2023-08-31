using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace UtilityPanel.ViewModels
{
    internal class LinkViewModel : BaseViewModel
    {
        public ICommand OnLeftClickCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }
        public ICommand EditCommand { get; private set; }

        private Action<LinkViewModel> removeAction;
        private string path = "";

        public string Path
        {
            get { return this.path; }
            set
            {
                if (value != null)
                {
                    path = value;
                    OnPropertyChanged(nameof(Path));
                }
            }
        }

        public LinkViewModel(string path, Action<LinkViewModel> removeAction)
        {
            this.removeAction = removeAction;
            this.Path = path;
            OnLeftClickCommand = new Command(_ => OnLeftClick(), null);
            RemoveCommand = new Command(_ => OnRemoveCommand(), null);
            EditCommand = new Command(_ => OnEditCommand(), null);
        }

        private void OnEditCommand()
        {
            MessageBox.Show($"Edit: {path}");
        }

        private void OnRemoveCommand() => removeAction?.Invoke(this);

        private void OnLeftClick()
        {
            MessageBox.Show($"Left: {path}");
        }
    }
}