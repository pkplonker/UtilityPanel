using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UtilityPanel
{
    internal class Command : ICommand
    {
        private readonly Action<object?> execute = (_) => { };
        private readonly Func<object?, bool> canExecute = (_) => { return true; };

        public Command(Action<object?> execute, Func<object?, bool>? canExecute)
        {
            if (execute != null) this.execute = execute;
            if (canExecute != null) this.canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) => canExecute.Invoke(parameter);

        public void Execute(object? parameter) => execute.Invoke(parameter);

        public event EventHandler? CanExecuteChanged;
    }
}