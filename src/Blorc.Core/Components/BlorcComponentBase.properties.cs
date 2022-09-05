namespace Blorc.Components
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Reflection;

    public abstract partial class BlorcComponentBase
    {
        private static readonly Dictionary<string, Type> EventCallbackTypeCache = new Dictionary<string, Type>();

        private static readonly Dictionary<string, MethodInfo> CallbackInvokeAsyncCache = new Dictionary<string, MethodInfo>();

        private readonly Queue<Action> _propertyChangedActionQueue = new Queue<Action>();

        protected BlorcComponentBase(bool injectComponentServices) :this()
        {
            InjectComponentServices = injectComponentServices;
        }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> AdditionalAttributes { get; set; }
        
        [Parameter]
        public bool DisableAutomaticRaiseEventCallback { get; set; }

        [Parameter]
        public bool InjectComponentServices { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public TValue GetPropertyValue<TValue>(string propertyName)
        {
            return _propertyBag.GetValue(propertyName, default(TValue));
        }

        public void SetPropertyValue(string propertyName, object value)
        {
            _propertyBag.SetValue(propertyName, value);
        }

        private void OnPropertyBagPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_hasRenderHandler)
            {
                RaisePropertyChanged(e);
            }
            else
            {
                _propertyChangedActionQueue.Enqueue(() => RaisePropertyChanged(e));
            }
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
        }

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            RaisePropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void RaisePropertyChanged(PropertyChangedEventArgs eventArgs)
        {
            OnPropertyChanged(eventArgs);

            PropertyChanged?.Invoke(this, eventArgs);

            RaiseEventCallback(eventArgs);
        }

        private void RaiseEventCallback(PropertyChangedEventArgs eventArgs)
        {
            if (DisableAutomaticRaiseEventCallback)
            {
                return;
            }

            var propertyName = eventArgs.PropertyName;
            var propertyInfo = PropertyHelper.GetPropertyInfo(this, propertyName);
            if (propertyInfo is null)
            {
                return;
            }

            var propertyTypeFullName = propertyInfo.PropertyType.FullName;
            if (!EventCallbackTypeCache.TryGetValue(propertyTypeFullName ?? throw new InvalidOperationException(), out var eventCallbackType))
            {
                eventCallbackType = typeof(EventCallback<>).MakeGenericType(propertyInfo.PropertyType);
                EventCallbackTypeCache.Add(propertyTypeFullName, eventCallbackType);
            }

            var propertyChangedEventCallback = PropertyHelper.GetPropertyValue(this, $"{propertyName}Changed");
            if (propertyChangedEventCallback is null || !eventCallbackType.IsInstanceOfType(propertyChangedEventCallback))
            {
                return;
            }

            if (!CallbackInvokeAsyncCache.TryGetValue(propertyTypeFullName, out var invokeAsyncMethod))
            {
                invokeAsyncMethod = eventCallbackType.GetMethod("InvokeAsync", new []{ propertyInfo.PropertyType });
                CallbackInvokeAsyncCache.Add(propertyTypeFullName, invokeAsyncMethod);
            }

            var propertyValue = propertyInfo.GetValue(this);
            if (invokeAsyncMethod is not null)
            {
                var callbackTask = invokeAsyncMethod.Invoke(propertyChangedEventCallback, new[] {propertyValue}) as Task;
                callbackTask?.GetAwaiter().GetResult();
            }
        }
    }
}
