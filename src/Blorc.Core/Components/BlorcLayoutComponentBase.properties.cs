namespace Blorc.Components
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;
    using System.Threading.Tasks;

    using Blorc.Attributes;
    using Blorc.Reflection;

    using Microsoft.AspNetCore.Components;

    public abstract partial class BlorcLayoutComponentBase
    {
        private static readonly Dictionary<string, MethodInfo> CallbackInvokeAsyncCache = new Dictionary<string, MethodInfo>();

        private static readonly Dictionary<string, Type> EventCallbackTypeCache = new Dictionary<string, Type>();

        public event PropertyChangedEventHandler PropertyChanged;

        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> AdditionalAttributes { get; set; }

        [Parameter]
        public bool InjectComponentReferenceAsService { get; set; }

        [Parameter]
        public bool DisableAutomaticRaiseEventCallback { get; set; }

        public TValue GetPropertyValue<TValue>(string propertyName)
        {
            return _propertyBag.GetValue(propertyName, default(TValue));
        }

        public void SetPropertyValue(string propertyName, object value)
        {
            _propertyBag.SetValue(propertyName, value);
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

        private void OnPropertyBagPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(e);
        }

        private void RaiseEventCallback(PropertyChangedEventArgs eventArgs)
        {
            if (DisableAutomaticRaiseEventCallback)
            {
                return;
            }

            var propertyName = eventArgs.PropertyName;
            var propertyInfo = PropertyHelper.GetPropertyInfo(this, propertyName);
            if (propertyInfo == null)
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
            if (propertyChangedEventCallback == null || !eventCallbackType.IsInstanceOfType(propertyChangedEventCallback))
            {
                return;
            }

            if (!CallbackInvokeAsyncCache.TryGetValue(propertyTypeFullName, out var invokeAsyncMethod))
            {
                invokeAsyncMethod = eventCallbackType.GetMethod("InvokeAsync", new[] { propertyInfo.PropertyType });
                CallbackInvokeAsyncCache.Add(propertyTypeFullName, invokeAsyncMethod);
            }

            var propertyValue = propertyInfo.GetValue(this);
            if (invokeAsyncMethod != null)
            {
                var callbackTask = invokeAsyncMethod.Invoke(propertyChangedEventCallback, new[] { propertyValue }) as Task;
                callbackTask?.GetAwaiter().GetResult();
            }
        }
    }
}
