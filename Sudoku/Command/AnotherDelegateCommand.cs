using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sudoku.Command
{
    class AnotherDelegateCommand : ICommand
    {
        private readonly Action<Object> _Execute;
        private readonly Func<Object, Boolean> _CanExecute;


        public AnotherDelegateCommand(Action<Object> execute) : this(null, execute) { }


        public AnotherDelegateCommand(Func<Object, Boolean> canExecute, Action<Object> execute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            _Execute = execute;
            _CanExecute = canExecute;
        }


        public event EventHandler CanExecuteChanged;


        public Boolean CanExecute(Object parameter)
        {
            return _CanExecute == null ? true : _CanExecute(parameter);
        }


        public void Execute(Object parameter)
        {
            _Execute(parameter);
        }


        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
