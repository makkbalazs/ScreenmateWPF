using System;
using System.Threading.Tasks;

namespace Screenmate.MVVM
{
    /// <summary>
    /// A command that relays it's functionality to other objects
    /// </summary>
    public class RelayCommand : IRelayCommand
    {
        /// <summary>
        /// Function to determine if command can be executed
        /// </summary>
        private Func<bool> _canExecute;
        /// <summary>
        /// Command to be executed
        /// </summary>
        private Action _execute;
        /// <summary>
        /// Async command to be executed
        /// </summary>
        private Func<Task> _executeAsync;

        /// <summary>
        /// The can execute changed event handler
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="execute">Command to be executed</param>
        /// <param name="canExecute">Function to determine if command can be executed</param>
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _canExecute = canExecute ?? (() => true);
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _executeAsync = null;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="executeAsync"></param>
        /// <param name="canExecute"></param>
        public RelayCommand(Func<Task> executeAsync, Func<bool> canExecute = null)
        {
            _canExecute = canExecute ?? (() => true);
            _execute = null;
            _executeAsync = executeAsync ?? throw new ArgumentNullException(nameof(executeAsync));
        }

        /// <summary>
        /// Determines if the command can be executed.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute();
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter"></param>
        public async void Execute(object parameter)
        {
            if(_execute != null)
            {
                _execute();
            }
            else if(_executeAsync != null)
            {
                await _executeAsync();
            }
        }
    }
}
