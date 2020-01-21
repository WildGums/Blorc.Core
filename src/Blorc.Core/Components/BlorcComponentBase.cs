namespace Blorc.Components
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Xml;

    using Blorc.Attributes;
    using Blorc.Bindings;
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
            if (firstRender && InjectComponentReferenceAsService)
            {
                var type = GetType();
                var fieldInfos = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                foreach (var fieldInfo in fieldInfos)
                {
                    var wrapAttribute = fieldInfo.GetCustomAttribute<InjectAsServiceAttribute>();
                    if (wrapAttribute != null)
                    {
                        var targetProperty = type.GetProperty(wrapAttribute.PropertyName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                        if (targetProperty != null)
                        {
                            targetProperty.SetValue(this, Activator.CreateInstance(wrapAttribute.ServiceType, fieldInfo.GetValue(this)));
                        }
                    }
                }

                var propertyInfos = type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                foreach (var propertyInfo in propertyInfos)
                {
                    var wrapAttribute = propertyInfo.GetCustomAttribute<InjectAsServiceAttribute>();
                    if (wrapAttribute != null)
                    {
                        var targetProperty = type.GetProperty(wrapAttribute.PropertyName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                        if (targetProperty != null)
                        {
                            targetProperty.SetValue(this, Activator.CreateInstance(wrapAttribute.ServiceType, propertyInfo.GetValue(this)));
                        }
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
