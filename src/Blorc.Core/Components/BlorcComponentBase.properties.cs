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
        private static readonly Dictionary<string, MethodInfo> CallbackInvokeAsyncCache = new Dictionary<string, MethodInfo>();

        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> AdditionalAttributes { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public TValue GetPropertyValue<TValue>(string propertyName)
        {
            return _propertyBag.GetPropertyValue(propertyName, default(TValue));
        }

        public void SetPropertyValue(string propertyName, object value)
        {
            _propertyBag.SetPropertyValue(propertyName, value);
        }

        private void OnPropertyBagPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(e);
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
        }

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            RaisePropertyChanged(new PropertyChangedEventArgs(propertyName));

            Console.WriteLine("RaisePropertyChanged");
            var propertyInfo = PropertyHelper.GetPropertyInfo(this, propertyName);
            if (propertyInfo == null)
            {
                Console.WriteLine("Property is null");
                return;
            }

            string key = $"{GetType().FullName}-{propertyName}}}";
            if (!CallbackInvokeAsyncCache.TryGetValue(key, out var invokeAsyncMethod))
            {
                var propertyChangedEventCallback = PropertyHelper.GetPropertyValue(this, $"{propertyName}Changed");
                if (propertyChangedEventCallback == null)
                {
                    return;
                }
               
                var callbackType = propertyChangedEventCallback.GetType();
                invokeAsyncMethod = callbackType.GetMethod("InvokeAsync", new[] {propertyInfo.PropertyType});
                if (invokeAsyncMethod == null)
                {
                    return;
                }
            }

            Console.WriteLine("Invoking event via reflection");
            CallbackInvokeAsyncCache.Add(key, invokeAsyncMethod);
            var propertyValue = propertyInfo.GetValue(this);
            var callbackTask = invokeAsyncMethod.Invoke(this, new[] { propertyValue }) as Task;
            callbackTask?.GetAwaiter().GetResult();
        }

        protected virtual void RaisePropertyChanged(PropertyChangedEventArgs eventArgs)
        {
            OnPropertyChanged(eventArgs);

            PropertyChanged?.Invoke(this, eventArgs);
        }
    }
}
