using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sudoku.Command
{
    public class DelegateCommand : ICommand

    {
        private Action functionToExecute;

        public DelegateCommand(Action toDo)
        {
            functionToExecute = toDo;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            functionToExecute();
        }
    }
}
