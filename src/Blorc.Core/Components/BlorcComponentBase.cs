namespace Blorc.Components
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Xml;

    using Blorc.Attributes;
    using Blorc.Bindings;
    using Blorc.Services;
    using Blorc.StateConverters;

    using Catel.Data;

    using Microsoft.AspNetCore.Components;

    using Serilog;

    public abstract partial class BlorcComponentBase : ComponentBase, IBlorcComponent
    {
        private static readonly Dictionary<string, int> InstanceCounters = new Dictionary<string, int>();

        private readonly PropertyBag _propertyBag = new PropertyBag();

        private readonly List<IStateConverterContainer> _stateConverterContainers = new List<IStateConverterContainer>();

        private bool _disposedValue;

        private bool _suspendUpdates;

        [Inject]
        protected IComponentServiceFactory ComponentServiceFactory { get; set; }

        public BlorcComponentBase()
        {
            BindingContext = new BindingContext();

            _propertyBag.PropertyChanged += OnPropertyBagPropertyChanged;
        }

        protected BindingContext BindingContext { get; private set; }

        public void Dispose()
        {
            Dispose(true);
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

        protected virtual void CreateBindings()
        {
        }

        protected StateConverterContainer CreateConverter()
        {
            var container = new StateConverterContainer(this);

            _stateConverterContainers.Add(container);

            return container;
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

        protected virtual void DisposeManaged()
        {
            BindingContext.Dispose();
            BindingContext = null;

            _stateConverterContainers.ForEach(x => x.Dispose());
            _stateConverterContainers.Clear();
        }

        protected string GenerateUniqueId(string prefix)
        {
            if (InstanceCounters.TryGetValue(prefix, out var index))
            {
            }

            InstanceCounters[prefix] = ++index;

            return $"{prefix}-{index}";
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (InjectComponentServices)
            {
                var type = GetType();
                var fieldInfos = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                foreach (var fieldInfo in fieldInfos)
                {
                    var value = fieldInfo.GetValue(this);
                    if (value != null)
                    {
                        var attributes = fieldInfo.GetCustomAttributes<InjectComponentServiceAttribute>();
                        Inject(attributes, type, value);
                    }
                }

                var propertyInfos = type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                foreach (var propertyInfo in propertyInfos)
                {
                    var value = propertyInfo.GetValue(this);
                    if (value != null)
                    {
                        var attributes = propertyInfo.GetCustomAttributes<InjectComponentServiceAttribute>();
                        Inject(attributes, type, value);
                    }
                }
            }
        }

        private void Inject(IEnumerable<InjectComponentServiceAttribute> attributes, Type type, object value)
        {
            foreach (var attribute in attributes)
            {
                if (attribute != null)
                {
                    var targetProperty = type.GetProperty(
                        attribute.PropertyName,
                        BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    if (targetProperty != null)
                    {
                        var componentService = ComponentServiceFactory.Get(value, targetProperty.PropertyType);
                        targetProperty.SetValue(this, componentService);
                    }
                }
            }
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
    }
}
