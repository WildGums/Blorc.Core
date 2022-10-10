namespace Blorc.Bindings
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Binding context that takes care of binding updates.
    /// </summary>
    public class BindingContext : IDisposable
    {
        private readonly List<Binding> _bindings = new List<Binding>();
        private readonly List<CommandBinding> _commandBindings = new List<CommandBinding>();

        //private int? _lastViewModelId;
        private bool _disposedValue;
 
        /// <summary>
        /// Initializes a new instance of the <see cref="BindingContext"/> class.
        /// </summary>
        public BindingContext()
        {
            
        }

        /// <summary>
        /// Gets the get bindings.
        /// </summary>
        /// <value>The get bindings.</value>
        public IEnumerable<Binding> GetBindings
        {
            get { return _bindings.ToArray(); }
        }

        /// <summary>
        /// Gets the get command bindings.
        /// </summary>
        /// <value>The get command bindings.</value>
        public IEnumerable<CommandBinding> GetCommandBindings
        {
            get { return _commandBindings.ToArray(); }
        }

        ///// <summary>
        ///// Occurs when binding updates are required.
        ///// </summary>
        //public event EventHandler<EventArgs>? BindingUpdateRequired;

        /// <summary>
        /// Clears this binding context and all bindings.
        /// </summary>
        public void Clear()
        {
            //Log.Debug("Clearing binding context");

            _bindings.ForEach(x => x.Dispose());
            _bindings.Clear();

            _commandBindings.ForEach(x => x.Dispose());
            _commandBindings.Clear();
        }

        /// <summary>
        /// Adds a new binding.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="binding"/> is <c>null</c>.</exception>
        public void AddBinding(Binding binding)
        {
            ArgumentNullException.ThrowIfNull(binding);

            //Log.Debug($"Adding binding '{binding}'");

            _bindings.Add(binding);
        }

        /// <summary>
        /// Removes the binding.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="binding"/> is <c>null</c>.</exception>
        public void RemoveBinding(Binding binding)
        {
            ArgumentNullException.ThrowIfNull(binding);

            //Log.Debug($"Removing binding '{binding}'");

            for (var i = 0; i < _bindings.Count; i++)
            {
                if (ReferenceEquals(_bindings[i], binding))
                {
                    _bindings.RemoveAt(i);
                    return;
                }
            }
        }

        /// <summary>
        /// Adds a new command binding.
        /// </summary>
        /// <param name="commandBinding">The command binding.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="commandBinding"/> is <c>null</c>.</exception>
        public void AddCommandBinding(CommandBinding commandBinding)
        {
            ArgumentNullException.ThrowIfNull(commandBinding);

            //Log.Debug($"Adding command binding '{commandBinding}'");

            _commandBindings.Add(commandBinding);
        }

        /// <summary>
        /// Removes the command binding.
        /// </summary>
        /// <param name="commandBinding">The command binding.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="commandBinding"/> is <c>null</c>.</exception>
        public void RemoveCommandBinding(CommandBinding commandBinding)
        {
            ArgumentNullException.ThrowIfNull(commandBinding);

            //Log.Debug($"Removing command binding '{commandBinding}'");

            for (var i = 0; i < _commandBindings.Count; i++)
            {
                if (ReferenceEquals(_commandBindings[i], commandBinding))
                {
                    _commandBindings.RemoveAt(i);
                    return;
                }
            }
        }

        protected virtual void DisposeManaged()
        {
            Clear();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    DisposeManaged();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
