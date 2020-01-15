namespace Blorc.Components
{
    using Blorc.Bindings;
    using Blorc.Services;
    using Blorc.StateConverters;

    using Microsoft.AspNetCore.Components;

    using Serilog;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Catel.Data;

    public abstract partial class BlorcLayoutComponentBase : LayoutComponentBase, IBlorcComponent, IDisposable, INotifyPropertyChanged
    {
        private static readonly Dictionary<string, int> InstanceCounters = new Dictionary<string, int>();

        private readonly List<IStateConverterContainer> _stateConverterContainers = new List<IStateConverterContainer>();

        private readonly PropertyBag _propertyBag = new PropertyBag();

        private bool _suspendUpdates;
        
        private bool _disposedValue;

        [Inject]
        public IDocumentService DocumentService { get; set; } 

        public BlorcLayoutComponentBase()
        {
            BindingContext = new BindingContext();

            _propertyBag.PropertyChanged += OnPropertyBagPropertyChanged;
        }

        protected BindingContext BindingContext { get; private set; }

        protected StateConverterContainer CreateConverter()
        {
            var container = new StateConverterContainer(this);

            _stateConverterContainers.Add(container);

            return container;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            await DocumentService.InjectBlorcCoreJS();
        }

        protected virtual void CreateBindings()
        {
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (_stateConverterContainers.Count > 0)
            {
                _suspendUpdates = true;

                CreateBindings();

                _stateConverterContainers.ForEach(x => x.MarkDirty());

                _suspendUpdates = false;

                StateHasChanged();
            }
        }

        public void ForceUpdate()
        {
            if (_suspendUpdates)
            {
                return;
            }

            Log.Debug("Forcing update for {TypeName}", GetType().Name);

            StateHasChanged();
        }

        protected string GenerateUniqueId(string prefix)
        {
            if (InstanceCounters.TryGetValue(prefix, out var index))
            {
            }

            InstanceCounters[prefix] = ++index;

            return $"{prefix}-{index}";
        }

        protected virtual void DisposeManaged()
        {
            BindingContext.Dispose();
            BindingContext = null;

            _stateConverterContainers.ForEach(x => x.Dispose());
            _stateConverterContainers.Clear();
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
        }
    }
}
