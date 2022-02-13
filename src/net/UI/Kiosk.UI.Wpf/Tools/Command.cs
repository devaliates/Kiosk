using System;
using System.Windows.Input;

namespace Kiosk.UI.Wpf.Tools;

public class Command
    : ICommand
{
    public event EventHandler CanExecuteChanged;

    private Action<object> execute;
    private Func<object, bool> canExecute;
    public Command(Action<object> execute, Func<object, bool> canExecute = null)
    {
        this.execute = execute;
        this.canExecute = canExecute;
    }

    public bool CanExecute(object parameter)
    {
        return this.canExecute == null || this.canExecute(parameter);
    }

    public void Execute(object parameter)
    {
        this.execute(parameter);
    }
}
