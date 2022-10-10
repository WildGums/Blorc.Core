﻿[assembly: System.Runtime.Versioning.TargetFramework(".NETCoreApp,Version=v6.0", FrameworkDisplayName="")]
namespace Blorc.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Property | System.AttributeTargets.Field, AllowMultiple=true)]
    public class InjectComponentServiceAttribute : System.Attribute
    {
        public InjectComponentServiceAttribute(string propertyName) { }
        public string PropertyName { get; }
    }
}
namespace Blorc.Bindings
{
    public class Binding : Blorc.Bindings.BindingBase
    {
        public Binding(Blorc.Bindings.BindingParty source, Blorc.Bindings.BindingParty target, Blorc.Bindings.BindingMode mode = 3, Blorc.Converters.IValueConverter? converter = null) { }
        public Binding(object source, string sourcePropertyName, object target, string targetPropertyName, Blorc.Bindings.BindingMode mode = 3, Blorc.Converters.IValueConverter? converter = null) { }
        public Blorc.Converters.IValueConverter? Converter { get; set; }
        public object? ConverterParameter { get; set; }
        public Blorc.Bindings.BindingMode Mode { get; }
        public Blorc.Bindings.BindingParty Source { get; }
        public Blorc.Bindings.BindingParty Target { get; }
        public object? Value { get; }
        public event System.EventHandler<System.EventArgs>? ValueChanged;
        protected override string DetermineToString() { }
        protected override void Dispose(bool disposing) { }
        public void TransferValueFromSourceToTarget() { }
        public void TransferValueFromTargetToSource() { }
        protected override void Uninitialize() { }
    }
    public abstract class BindingBase : System.IDisposable
    {
        protected BindingBase() { }
        public void ClearBinding() { }
        protected abstract string DetermineToString();
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        protected virtual void DisposeManaged() { }
        public override string ToString() { }
        protected abstract void Uninitialize();
    }
    public class BindingBuilder
    {
        public void Apply() { }
        public Blorc.Bindings.BindingBuilder AsMode(Blorc.Bindings.BindingMode mode) { }
        public Blorc.Bindings.BindingBuilder From<TProperty>(System.Linq.Expressions.Expression<System.Func<TProperty>> propertyExpression) { }
        public Blorc.Bindings.BindingBuilder To<TProperty>(System.Linq.Expressions.Expression<System.Func<TProperty>> propertyExpression) { }
        public Blorc.Bindings.BindingBuilder UsingConverter(Blorc.Converters.IValueConverter valueConverter) { }
        public static Blorc.Bindings.Binding op_Implicit(Blorc.Bindings.BindingBuilder builder) { }
    }
    public class BindingContext : System.IDisposable
    {
        public BindingContext() { }
        public System.Collections.Generic.IEnumerable<Blorc.Bindings.Binding> GetBindings { get; }
        public System.Collections.Generic.IEnumerable<Blorc.Bindings.CommandBinding> GetCommandBindings { get; }
        public void AddBinding(Blorc.Bindings.Binding binding) { }
        public void AddCommandBinding(Blorc.Bindings.CommandBinding commandBinding) { }
        public void Clear() { }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        protected virtual void DisposeManaged() { }
        public void RemoveBinding(Blorc.Bindings.Binding binding) { }
        public void RemoveCommandBinding(Blorc.Bindings.CommandBinding commandBinding) { }
    }
    public static class BindingContextExtensions
    {
        public static Blorc.Bindings.Binding AddBinding(this Blorc.Bindings.BindingContext bindingContext, System.Linq.Expressions.Expression<System.Func<object>> sourcePropertyExpression, System.Linq.Expressions.Expression<System.Func<object>> targetPropertyExpression, Blorc.Bindings.BindingMode mode = 3, Blorc.Converters.IValueConverter? converter = null) { }
        public static Blorc.Bindings.Binding AddBinding(this Blorc.Bindings.BindingContext bindingContext, object source, string sourcePropertyName, object target, string targetPropertyName, Blorc.Bindings.BindingMode mode = 3, Blorc.Converters.IValueConverter? converter = null) { }
        public static Blorc.Bindings.Binding AddBindingWithConverter<TConverter>(this Blorc.Bindings.BindingContext bindingContext, System.Linq.Expressions.Expression<System.Func<object>> sourcePropertyExpression, System.Linq.Expressions.Expression<System.Func<object>> targetPropertyExpression, Blorc.Bindings.BindingMode mode = 3)
            where TConverter : Blorc.Converters.IValueConverter, new () { }
        public static Blorc.Bindings.Binding AddBindingWithConverter<TConverter>(this Blorc.Bindings.BindingContext bindingContext, object source, string sourcePropertyName, object target, string targetPropertyName, Blorc.Bindings.BindingMode mode = 3)
            where TConverter : Blorc.Converters.IValueConverter, new () { }
        public static Blorc.Bindings.CommandBinding AddCommandBinding(this Blorc.Bindings.BindingContext bindingContext, object element, string eventName, Blorc.Bindings.ICommand command, Blorc.Bindings.Binding? commandParameterBinding = null) { }
        public static Blorc.Bindings.BindingBuilder CreateBinding(this Blorc.Bindings.BindingContext bindingContext) { }
    }
    public static class BindingExtensions
    {
        public static Blorc.Bindings.Binding AddSourceEvent(this Blorc.Bindings.Binding binding, string eventName) { }
        public static Blorc.Bindings.Binding AddSourceEvent<TEventArgs>(this Blorc.Bindings.Binding binding, string eventName)
            where TEventArgs : System.EventArgs { }
        public static Blorc.Bindings.Binding AddTargetEvent(this Blorc.Bindings.Binding binding, string eventName) { }
        public static Blorc.Bindings.Binding AddTargetEvent<TEventArgs>(this Blorc.Bindings.Binding binding, string eventName)
            where TEventArgs : System.EventArgs { }
        public static object? GetBindingValue(this Blorc.Bindings.Binding binding) { }
    }
    public enum BindingMode
    {
        OneTime = 0,
        OneWay = 1,
        OneWayToSource = 2,
        TwoWay = 3,
    }
    public class BindingParty : System.IDisposable
    {
        public BindingParty(object instance, string propertyName) { }
        public object? Instance { get; }
        public string PropertyName { get; }
        public event System.EventHandler<System.EventArgs>? ValueChanged;
        public void AddEvent<TEventArgs>(string eventName)
            where TEventArgs : System.EventArgs { }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public object? GetPropertyValue() { }
        public void SetPropertyValue(object? newValue) { }
        public override string ToString() { }
    }
    public static class BindingPartyExtensions
    {
        public static void AddEvent(this Blorc.Bindings.BindingParty bindingParty, string eventName) { }
    }
    public class CommandBinding : Blorc.Bindings.BindingBase
    {
        public CommandBinding(object element, string eventName, Blorc.Bindings.ICommand command, Blorc.Bindings.Binding? commandParameterBinding = null) { }
        protected override string DetermineToString() { }
        protected override void Uninitialize() { }
    }
    public interface ICommand
    {
        object? Tag { get; set; }
        event System.EventHandler<System.EventArgs>? CanExecuteChanged;
        event System.EventHandler<System.EventArgs>? Executed;
        System.Threading.Tasks.Task<bool> CanExecuteAsync(object? parameter);
        System.Threading.Tasks.Task ExecuteAsync(object? parameter);
    }
}
namespace Blorc.Components
{
    public abstract class BlorcComponentBase : Microsoft.AspNetCore.Components.ComponentBase, Blorc.Components.IBlorcComponent, System.ComponentModel.INotifyPropertyChanged, System.IDisposable
    {
        public BlorcComponentBase() { }
        protected BlorcComponentBase(bool injectComponentServices) { }
        [Microsoft.AspNetCore.Components.Parameter(CaptureUnmatchedValues=true)]
        public System.Collections.Generic.Dictionary<string, object?>? AdditionalAttributes { get; set; }
        protected Blorc.Bindings.BindingContext BindingContext { get; }
        [Microsoft.AspNetCore.Components.Inject]
        protected Blorc.Services.IComponentServiceFactory? ComponentServiceFactory { get; set; }
        [Microsoft.AspNetCore.Components.Parameter]
        public bool DisableAutomaticRaiseEventCallback { get; set; }
        [Microsoft.AspNetCore.Components.Parameter]
        public bool InjectComponentServices { get; set; }
        public event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
        protected virtual void CreateBindings() { }
        protected Blorc.StateConverters.StateConverterContainer CreateConverter() { }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        protected virtual void DisposeManaged() { }
        public void ForceUpdate() { }
        protected string GenerateUniqueId(string prefix) { }
        public TValue? GetPropertyValue<TValue>(string propertyName) { }
        protected override System.Threading.Tasks.Task OnAfterRenderAsync(bool firstRender) { }
        protected override void OnParametersSet() { }
        protected virtual void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e) { }
        protected virtual void RaisePropertyChanged(System.ComponentModel.PropertyChangedEventArgs eventArgs) { }
        protected virtual void RaisePropertyChanged(string propertyName) { }
        public void SetPropertyValue(string propertyName, object? value) { }
    }
    public abstract class BlorcLayoutComponentBase : Microsoft.AspNetCore.Components.LayoutComponentBase, Blorc.Components.IBlorcComponent, System.ComponentModel.INotifyPropertyChanged, System.IDisposable
    {
        public BlorcLayoutComponentBase() { }
        [Microsoft.AspNetCore.Components.Parameter(CaptureUnmatchedValues=true)]
        public System.Collections.Generic.IDictionary<string, object?>? AdditionalAttributes { get; set; }
        protected Blorc.Bindings.BindingContext BindingContext { get; }
        [Microsoft.AspNetCore.Components.Inject]
        protected Blorc.Services.IComponentServiceFactory? ComponentServiceFactory { get; set; }
        [Microsoft.AspNetCore.Components.Parameter]
        public bool DisableAutomaticRaiseEventCallback { get; set; }
        [Microsoft.AspNetCore.Components.Parameter]
        public bool InjectComponentServices { get; set; }
        public event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
        protected virtual void CreateBindings() { }
        protected Blorc.StateConverters.StateConverterContainer CreateConverter() { }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        protected virtual void DisposeManaged() { }
        public void ForceUpdate() { }
        protected string GenerateUniqueId(string prefix) { }
        public TValue? GetPropertyValue<TValue>(string propertyName) { }
        protected override System.Threading.Tasks.Task OnAfterRenderAsync(bool firstRender) { }
        protected override System.Threading.Tasks.Task OnInitializedAsync() { }
        protected override void OnParametersSet() { }
        protected virtual void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e) { }
        protected virtual void RaisePropertyChanged(System.ComponentModel.PropertyChangedEventArgs eventArgs) { }
        protected virtual void RaisePropertyChanged(string propertyName) { }
        public void SetPropertyValue(string propertyName, object? value) { }
    }
    public interface IBlorcComponent : System.ComponentModel.INotifyPropertyChanged, System.IDisposable
    {
        void ForceUpdate();
    }
    public abstract class UniqueComponentBase : Blorc.Components.BlorcComponentBase
    {
        public UniqueComponentBase() { }
        public abstract string ComponentName { get; }
        public string InstanceId { get; }
    }
}
namespace Blorc.Converters
{
    public static class ConverterHelper
    {
        public static object UnsetValue { get; }
    }
    public interface IValueConverter
    {
        object? Convert(object? value, System.Type targetType, object? parameter, System.Globalization.CultureInfo? culture);
        object? ConvertBack(object? value, System.Type targetType, object? parameter, System.Globalization.CultureInfo? culture);
    }
}
namespace Blorc.Data
{
    public static class BoxingCache
    {
        public static object? GetBoxedValue(bool value) { }
        public static object? GetBoxedValue(byte value) { }
        public static object? GetBoxedValue(char value) { }
        public static object? GetBoxedValue(System.Char? value) { }
        public static object? GetBoxedValue(System.DateTime value) { }
        public static object? GetBoxedValue(System.DateTime? value) { }
        public static object? GetBoxedValue(decimal value) { }
        public static object? GetBoxedValue(double value) { }
        public static object? GetBoxedValue(short value) { }
        public static object? GetBoxedValue(int value) { }
        public static object? GetBoxedValue(long value) { }
        public static object? GetBoxedValue(sbyte value) { }
        public static object? GetBoxedValue(float value) { }
        public static object? GetBoxedValue(string value) { }
        public static object? GetBoxedValue(ushort value) { }
        public static object? GetBoxedValue(uint value) { }
        public static object? GetBoxedValue(ulong value) { }
        public static object? GetBoxedValue(bool? value) { }
        public static object? GetBoxedValue(byte? value) { }
        public static object? GetBoxedValue(decimal? value) { }
        public static object? GetBoxedValue(double? value) { }
        public static object? GetBoxedValue(float? value) { }
        public static object? GetBoxedValue(int? value) { }
        public static object? GetBoxedValue(long? value) { }
        public static object? GetBoxedValue(object? value) { }
        public static object? GetBoxedValue(sbyte? value) { }
        public static object? GetBoxedValue(short? value) { }
        public static object? GetBoxedValue(uint? value) { }
        public static object? GetBoxedValue(ulong? value) { }
        public static object? GetBoxedValue(ushort? value) { }
        public static object? GetBoxedValue<TValue>(TValue value)
            where TValue :  notnull { }
    }
    public class BoxingCache<T>
        where T :  notnull
    {
        public BoxingCache() { }
        public static Blorc.Data.BoxingCache<T> Default { get; }
        protected T AddBoxedValue(object boxedValue) { }
        protected object? AddUnboxedValue(T value) { }
        public object? GetBoxedValue(T value) { }
        public T GetUnboxedValue(object boxedValue) { }
    }
    public interface IPropertyBag : System.ComponentModel.INotifyPropertyChanged
    {
        string[] GetAllNames();
        System.Collections.Generic.Dictionary<string, object?> GetAllProperties();
        TValue GetValue<TValue>(string name, TValue defaultValue = default);
        bool IsAvailable(string name);
        void SetValue<TValue>(string name, TValue value);
    }
    public class PropertyBag : Blorc.Data.PropertyBagBase
    {
        public PropertyBag() { }
        public PropertyBag(System.Collections.Generic.IDictionary<string, object?> propertyDictionary) { }
        public object this[string name] { get; set; }
        public override string[] GetAllNames() { }
        public override System.Collections.Generic.Dictionary<string, object?> GetAllProperties() { }
        public override TValue GetValue<TValue>(string name, TValue defaultValue = default) { }
        public void Import(System.Collections.Generic.Dictionary<string, object?> propertiesToImport) { }
        public override bool IsAvailable(string name) { }
        public void SetValue(string propertyName, bool value) { }
        public void SetValue(string propertyName, byte value) { }
        public void SetValue(string propertyName, char value) { }
        public void SetValue(string propertyName, System.DateTime value) { }
        public void SetValue(string propertyName, decimal value) { }
        public void SetValue(string propertyName, double value) { }
        public void SetValue(string propertyName, short value) { }
        public void SetValue(string propertyName, int value) { }
        public void SetValue(string propertyName, long value) { }
        public void SetValue(string propertyName, sbyte value) { }
        public void SetValue(string propertyName, float value) { }
        public void SetValue(string propertyName, string value) { }
        public void SetValue(string propertyName, ushort value) { }
        public void SetValue(string propertyName, uint value) { }
        public void SetValue(string propertyName, ulong value) { }
        public override void SetValue<TValue>(string name, TValue value) { }
        public void UpdatePropertyValue<TValue>(string propertyName, System.Func<TValue, TValue> update) { }
    }
    public abstract class PropertyBagBase : Blorc.Data.IPropertyBag, System.ComponentModel.INotifyPropertyChanged
    {
        protected PropertyBagBase() { }
        public event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
        public abstract string[] GetAllNames();
        public abstract System.Collections.Generic.Dictionary<string, object?> GetAllProperties();
        public abstract TValue GetValue<TValue>(string name, TValue defaultValue = default);
        public abstract bool IsAvailable(string name);
        protected void RaisePropertyChanged(string propertyName) { }
        public abstract void SetValue<TValue>(string name, TValue value);
    }
    public class TypedPropertyBag : Blorc.Data.PropertyBagBase
    {
        public TypedPropertyBag() { }
        public override string[] GetAllNames() { }
        public override System.Collections.Generic.Dictionary<string, object> GetAllProperties() { }
        protected System.Collections.Generic.Dictionary<string, bool> GetBooleanStorage() { }
        protected System.Collections.Generic.Dictionary<string, byte> GetByteStorage() { }
        protected System.Collections.Generic.Dictionary<string, char> GetCharStorage() { }
        protected System.Collections.Generic.Dictionary<string, System.DateTime> GetDateTimeStorage() { }
        protected System.Collections.Generic.Dictionary<string, decimal> GetDecimalStorage() { }
        protected System.Collections.Generic.Dictionary<string, double> GetDoubleStorage() { }
        protected System.Collections.Generic.Dictionary<string, short> GetInt16Storage() { }
        protected System.Collections.Generic.Dictionary<string, int> GetInt32Storage() { }
        protected System.Collections.Generic.Dictionary<string, long> GetInt64Storage() { }
        protected System.Collections.Generic.Dictionary<string, object> GetObjectStorage() { }
        protected System.Collections.Generic.Dictionary<string, sbyte> GetSByteStorage() { }
        protected System.Collections.Generic.Dictionary<string, float> GetSingleStorage() { }
        protected System.Collections.Generic.Dictionary<string, string> GetStringStorage() { }
        protected System.Collections.Generic.Dictionary<string, ushort> GetUInt16Storage() { }
        protected System.Collections.Generic.Dictionary<string, uint> GetUInt32Storage() { }
        protected System.Collections.Generic.Dictionary<string, ulong> GetUInt64Storage() { }
        public override TValue GetValue<TValue>(string name, TValue defaultValue = default) { }
        public override bool IsAvailable(string name) { }
        public override void SetValue<TValue>(string name, TValue value) { }
    }
}
namespace Blorc.Dom.Injectors
{
    public class Base : Blorc.Dom.Injectors.InjectorBase
    {
        public Base() { }
        protected override string ElementName { get; }
        public string Href { get; set; }
        public string Target { get; set; }
        protected override System.Collections.Generic.Dictionary<string, string> GetAttributes() { }
    }
    public class Css : Blorc.Dom.Injectors.Link
    {
        public Css(string href) { }
    }
    public interface IInjectorValueProvider
    {
        string GetValue();
    }
    public abstract class InjectorBase : Blorc.Dom.Injectors.IInjectorValueProvider
    {
        protected InjectorBase() { }
        protected abstract string ElementName { get; }
        protected abstract System.Collections.Generic.Dictionary<string, string> GetAttributes();
        public string GetValue() { }
    }
    public class Link : Blorc.Dom.Injectors.InjectorBase
    {
        public Link() { }
        public string Charset { get; set; }
        public string CrossOrigin { get; set; }
        protected override string ElementName { get; }
        public string Href { get; set; }
        public string HrefLang { get; set; }
        public string Media { get; set; }
        public string Rel { get; set; }
        public string Sizes { get; set; }
        public string Type { get; set; }
        protected override System.Collections.Generic.Dictionary<string, string> GetAttributes() { }
    }
    public class Meta : Blorc.Dom.Injectors.InjectorBase
    {
        public Meta() { }
        public string Charset { get; set; }
        public string Content { get; set; }
        protected override string ElementName { get; }
        public string HttpEquiv { get; set; }
        public string Name { get; set; }
        protected override System.Collections.Generic.Dictionary<string, string> GetAttributes() { }
    }
    public class Script : Blorc.Dom.Injectors.InjectorBase
    {
        public Script(string src, string type = "text/javascript") { }
        protected override string ElementName { get; }
        protected override System.Collections.Generic.Dictionary<string, string> GetAttributes() { }
    }
}
namespace Blorc.Linq.Expressions
{
    public static class ExpressionBuilder
    {
        public static System.Linq.Expressions.Expression<System.Func<T, object>>? CreateFieldGetter<T>(System.Reflection.FieldInfo fieldInfo) { }
        public static System.Linq.Expressions.Expression<System.Func<T, object>>? CreateFieldGetter<T>(string fieldName) { }
        public static System.Linq.Expressions.Expression<System.Func<object, TField>>? CreateFieldGetter<TField>(System.Type modelType, string fieldName) { }
        public static System.Linq.Expressions.Expression<System.Func<T, TField>>? CreateFieldGetter<T, TField>(System.Reflection.FieldInfo fieldInfo) { }
        public static System.Linq.Expressions.Expression<System.Func<T, TField>>? CreateFieldGetter<T, TField>(string fieldName) { }
        public static System.Collections.Generic.IReadOnlyDictionary<string, System.Linq.Expressions.Expression<System.Func<T, object>>> CreateFieldGetters<T>() { }
        public static System.Collections.Generic.IReadOnlyDictionary<string, System.Linq.Expressions.Expression<System.Func<T, TField>>> CreateFieldGetters<T, TField>() { }
        public static System.Linq.Expressions.Expression<System.Action<T, object>>? CreateFieldSetter<T>(System.Reflection.FieldInfo fieldInfo) { }
        public static System.Linq.Expressions.Expression<System.Action<T, object>>? CreateFieldSetter<T>(string fieldName) { }
        public static System.Linq.Expressions.Expression<System.Action<object, TField>>? CreateFieldSetter<TField>(System.Type modelType, string fieldName) { }
        public static System.Linq.Expressions.Expression<System.Action<T, TField>>? CreateFieldSetter<T, TField>(System.Reflection.FieldInfo fieldInfo) { }
        public static System.Linq.Expressions.Expression<System.Action<T, TField>>? CreateFieldSetter<T, TField>(string fieldName) { }
        public static System.Collections.Generic.IReadOnlyDictionary<string, System.Linq.Expressions.Expression<System.Action<T, object>>> CreateFieldSetters<T>() { }
        public static System.Collections.Generic.IReadOnlyDictionary<string, System.Linq.Expressions.Expression<System.Action<T, TField>>> CreateFieldSetters<T, TField>() { }
        public static System.Linq.Expressions.Expression<System.Func<T, object>>? CreatePropertyGetter<T>(System.Reflection.PropertyInfo propertyInfo) { }
        public static System.Linq.Expressions.Expression<System.Func<T, object>>? CreatePropertyGetter<T>(string propertyName) { }
        public static System.Linq.Expressions.Expression<System.Func<object, TProperty>>? CreatePropertyGetter<TProperty>(System.Type modelType, string propertyName) { }
        public static System.Linq.Expressions.Expression<System.Func<T, TProperty>>? CreatePropertyGetter<T, TProperty>(System.Reflection.PropertyInfo propertyInfo) { }
        public static System.Linq.Expressions.Expression<System.Func<T, TProperty>>? CreatePropertyGetter<T, TProperty>(string propertyName) { }
        public static System.Collections.Generic.IReadOnlyDictionary<string, System.Linq.Expressions.Expression<System.Func<T, object>>> CreatePropertyGetters<T>() { }
        public static System.Collections.Generic.IReadOnlyDictionary<string, System.Linq.Expressions.Expression<System.Func<T, TProperty>>> CreatePropertyGetters<T, TProperty>() { }
        public static System.Linq.Expressions.Expression<System.Action<T, object>>? CreatePropertySetter<T>(System.Reflection.PropertyInfo propertyInfo) { }
        public static System.Linq.Expressions.Expression<System.Action<T, object>>? CreatePropertySetter<T>(string propertyName) { }
        public static System.Linq.Expressions.Expression<System.Action<object, TProperty>>? CreatePropertySetter<TProperty>(System.Type modelType, string propertyName) { }
        public static System.Linq.Expressions.Expression<System.Action<T, TProperty>>? CreatePropertySetter<T, TProperty>(System.Reflection.PropertyInfo propertyInfo) { }
        public static System.Linq.Expressions.Expression<System.Action<T, TProperty>>? CreatePropertySetter<T, TProperty>(string propertyName) { }
        public static System.Collections.Generic.IReadOnlyDictionary<string, System.Linq.Expressions.Expression<System.Action<T, object>>> CreatePropertySetters<T>() { }
        public static System.Collections.Generic.IReadOnlyDictionary<string, System.Linq.Expressions.Expression<System.Action<T, TProperty>>> CreatePropertySetters<T, TProperty>() { }
    }
    public static class ExpressionHelper
    {
        public static object? GetOwner<TProperty>(System.Linq.Expressions.Expression<System.Func<TProperty>> propertyExpression) { }
        public static string GetPropertyName<TProperty>(System.Linq.Expressions.Expression<System.Func<TProperty>> propertyExpression) { }
        public static string GetPropertyName<TSource, TProperty>(System.Linq.Expressions.Expression<System.Func<TSource, TProperty>> propertyExpression) { }
    }
}
namespace Blorc.MVVM
{
    public interface IViewModel : System.ComponentModel.INotifyPropertyChanged { }
}
namespace Blorc
{
    public static class ObjectHelper
    {
        public static bool AreEqual(object? object1, object? object2) { }
        public static bool AreEqualReferences(object? object1, object? object2) { }
        public static bool IsNull(object? obj) { }
    }
    public class _Imports : Microsoft.AspNetCore.Components.ComponentBase
    {
        public _Imports() { }
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder @__builder) { }
    }
}
namespace Blorc.Reflection
{
    public class FastMemberInvoker<TEntity> : Blorc.Reflection.IFastMemberInvoker
        where TEntity :  class
    {
        public FastMemberInvoker() { }
        protected virtual System.Action<TEntity, TMemberType> Compile<TMemberType>(System.Linq.Expressions.Expression<System.Action<TEntity, TMemberType>> expression) { }
        protected virtual System.Func<TEntity, TMemberType> Compile<TMemberType>(System.Linq.Expressions.Expression<System.Func<TEntity, TMemberType>> expression) { }
        public bool SetFieldValue(TEntity entity, string fieldName, bool value) { }
        public bool SetFieldValue(TEntity entity, string fieldName, byte value) { }
        public bool SetFieldValue(TEntity entity, string fieldName, char value) { }
        public bool SetFieldValue(TEntity entity, string fieldName, System.DateTime value) { }
        public bool SetFieldValue(TEntity entity, string fieldName, decimal value) { }
        public bool SetFieldValue(TEntity entity, string fieldName, double value) { }
        public bool SetFieldValue(TEntity entity, string fieldName, short value) { }
        public bool SetFieldValue(TEntity entity, string fieldName, int value) { }
        public bool SetFieldValue(TEntity entity, string fieldName, long value) { }
        public bool SetFieldValue(TEntity entity, string fieldName, object value) { }
        public bool SetFieldValue(TEntity entity, string fieldName, sbyte value) { }
        public bool SetFieldValue(TEntity entity, string fieldName, float value) { }
        public bool SetFieldValue(TEntity entity, string fieldName, string value) { }
        public bool SetFieldValue(TEntity entity, string fieldName, ushort value) { }
        public bool SetFieldValue(TEntity entity, string fieldName, uint value) { }
        public bool SetFieldValue(TEntity entity, string fieldName, ulong value) { }
        public bool SetFieldValue<TValue>(object entity, string fieldName, TValue value) { }
        public bool SetPropertyValue(TEntity entity, string propertyName, bool value) { }
        public bool SetPropertyValue(TEntity entity, string propertyName, byte value) { }
        public bool SetPropertyValue(TEntity entity, string propertyName, char value) { }
        public bool SetPropertyValue(TEntity entity, string propertyName, System.DateTime value) { }
        public bool SetPropertyValue(TEntity entity, string propertyName, decimal value) { }
        public bool SetPropertyValue(TEntity entity, string propertyName, double value) { }
        public bool SetPropertyValue(TEntity entity, string propertyName, short value) { }
        public bool SetPropertyValue(TEntity entity, string propertyName, int value) { }
        public bool SetPropertyValue(TEntity entity, string propertyName, long value) { }
        public bool SetPropertyValue(TEntity entity, string propertyName, object value) { }
        public bool SetPropertyValue(TEntity entity, string propertyName, sbyte value) { }
        public bool SetPropertyValue(TEntity entity, string propertyName, float value) { }
        public bool SetPropertyValue(TEntity entity, string propertyName, string value) { }
        public bool SetPropertyValue(TEntity entity, string propertyName, ushort value) { }
        public bool SetPropertyValue(TEntity entity, string propertyName, uint value) { }
        public bool SetPropertyValue(TEntity entity, string propertyName, ulong value) { }
        public bool SetPropertyValue<TValue>(object entity, string propertyName, TValue value) { }
        public bool TryGetFieldValue(TEntity entity, string fieldName, out bool item) { }
        public bool TryGetFieldValue(TEntity entity, string fieldName, out byte item) { }
        public bool TryGetFieldValue(TEntity entity, string fieldName, out char item) { }
        public bool TryGetFieldValue(TEntity entity, string fieldName, out System.DateTime item) { }
        public bool TryGetFieldValue(TEntity entity, string fieldName, out decimal item) { }
        public bool TryGetFieldValue(TEntity entity, string fieldName, out double item) { }
        public bool TryGetFieldValue(TEntity entity, string fieldName, out short item) { }
        public bool TryGetFieldValue(TEntity entity, string fieldName, out int item) { }
        public bool TryGetFieldValue(TEntity entity, string fieldName, out long item) { }
        public bool TryGetFieldValue(TEntity entity, string fieldName, out object item) { }
        public bool TryGetFieldValue(TEntity entity, string fieldName, out sbyte item) { }
        public bool TryGetFieldValue(TEntity entity, string fieldName, out float item) { }
        public bool TryGetFieldValue(TEntity entity, string fieldName, out string item) { }
        public bool TryGetFieldValue(TEntity entity, string fieldName, out ushort item) { }
        public bool TryGetFieldValue(TEntity entity, string fieldName, out uint item) { }
        public bool TryGetFieldValue(TEntity entity, string fieldName, out ulong item) { }
        public bool TryGetFieldValue<TValue>(object entity, string fieldName, out TValue value) { }
        public bool TryGetPropertyValue(TEntity entity, string propertyName, out bool item) { }
        public bool TryGetPropertyValue(TEntity entity, string propertyName, out byte item) { }
        public bool TryGetPropertyValue(TEntity entity, string propertyName, out char item) { }
        public bool TryGetPropertyValue(TEntity entity, string propertyName, out System.DateTime item) { }
        public bool TryGetPropertyValue(TEntity entity, string propertyName, out decimal item) { }
        public bool TryGetPropertyValue(TEntity entity, string propertyName, out double item) { }
        public bool TryGetPropertyValue(TEntity entity, string propertyName, out short item) { }
        public bool TryGetPropertyValue(TEntity entity, string propertyName, out int item) { }
        public bool TryGetPropertyValue(TEntity entity, string propertyName, out long item) { }
        public bool TryGetPropertyValue(TEntity entity, string propertyName, out object item) { }
        public bool TryGetPropertyValue(TEntity entity, string propertyName, out sbyte item) { }
        public bool TryGetPropertyValue(TEntity entity, string propertyName, out float item) { }
        public bool TryGetPropertyValue(TEntity entity, string propertyName, out string item) { }
        public bool TryGetPropertyValue(TEntity entity, string propertyName, out ushort item) { }
        public bool TryGetPropertyValue(TEntity entity, string propertyName, out uint item) { }
        public bool TryGetPropertyValue(TEntity entity, string propertyName, out ulong item) { }
        public bool TryGetPropertyValue<TValue>(object entity, string propertyName, out TValue value) { }
    }
    public interface IFastMemberInvoker
    {
        bool SetFieldValue<TValue>(object entity, string fieldName, TValue value);
        bool SetPropertyValue<TValue>(object entity, string propertyName, TValue value);
        bool TryGetFieldValue<TValue>(object entity, string fieldName, out TValue value);
        bool TryGetPropertyValue<TValue>(object entity, string propertyName, out TValue value);
    }
    public static class PropertyHelper
    {
        public static System.Reflection.PropertyInfo? GetPropertyInfo(object obj, string property, bool ignoreCase = false) { }
        public static string GetPropertyName(System.Linq.Expressions.Expression propertyExpression, bool allowNested = false) { }
        public static string GetPropertyName<TValue>(System.Linq.Expressions.Expression<System.Func<TValue>> propertyExpression, bool allowNested = false) { }
        public static string GetPropertyName<TModel, TValue>(System.Linq.Expressions.Expression<System.Func<TModel, TValue>> propertyExpression, bool allowNested = false) { }
        public static object? GetPropertyValue(object obj, string property, bool ignoreCase = false) { }
        public static TValue? GetPropertyValue<TValue>(object obj, string property, bool ignoreCase = false) { }
        public static void SetPropertyValue(object obj, string property, object? value, bool ignoreCase = false) { }
    }
    public static class TypeExtensions
    {
        public static System.Type? GetCollectionElementType(this System.Type type) { }
        public static bool IsBasicType(this System.Type type) { }
        public static bool IsClassType(this System.Type type) { }
        public static bool IsCollection(this System.Type type) { }
        public static bool IsDictionary(this System.Type type) { }
        public static bool IsNullableType(this System.Type type) { }
    }
}
namespace Blorc.Services
{
    public class ComponentServiceFactory : Blorc.Services.FactoryBase, Blorc.Services.IComponentServiceFactory, Blorc.Services.IFactory
    {
        public ComponentServiceFactory(System.IServiceProvider provider) { }
        public override System.Collections.IEnumerable Get(object source) { }
        public override object? Get(object source, System.Type targetType) { }
        public System.Collections.Generic.IEnumerable<TComponentService> Get<TComponentService>(Microsoft.AspNetCore.Components.ComponentBase componentBase)
            where TComponentService : Blorc.Services.IComponentService { }
        public TComponentService Get<TComponentService>(Microsoft.AspNetCore.Components.ComponentBase componentBase, System.Type targetType)
            where TComponentService : Blorc.Services.IComponentService { }
        public void Map<TComponent, TComponentService>()
            where TComponent : Microsoft.AspNetCore.Components.ComponentBase
            where TComponentService : Blorc.Services.IComponentService { }
    }
    public class ConfigurationService : Blorc.Services.IConfigurationService
    {
        public ConfigurationService(Microsoft.AspNetCore.Components.NavigationManager navigationManager) { }
        public System.Threading.Tasks.Task<T?> GetSectionAsync<T>(string sectionName) { }
    }
    public class DocumentService : Blorc.Services.IDocumentService
    {
        public DocumentService(Microsoft.JSInterop.IJSRuntime jsRuntime) { }
        public System.Threading.Tasks.Task<Blorc.Services.Interop.Rect> GetBoundingClientRectAsync(double x, double y) { }
        public System.Threading.Tasks.Task<Blorc.Services.Interop.Rect> GetBoundingClientRectByIdAsync(string id) { }
        public System.Threading.Tasks.Task<Blorc.Services.Interop.Rect> GetOffsetBoundingClientRectAsync(double x, double y) { }
        public System.Threading.Tasks.Task InjectHeadAsync(Blorc.Dom.Injectors.IInjectorValueProvider injectorValueProvider) { }
        public System.Threading.Tasks.Task InjectLinkAsync(string href, string rel = "stylesheet", string type = "text/css") { }
        public System.Threading.Tasks.Task InjectScriptAsync(string source, string type = "text/javascript") { }
    }
    public class FactoryBase : Blorc.Services.IFactory
    {
        public FactoryBase(System.IServiceProvider provider) { }
        public virtual System.Collections.IEnumerable Get(object source) { }
        public virtual object? Get(object source, System.Type targetType) { }
        public void Register(System.Type sourceType, System.Type targetType) { }
    }
    public class FileService : Blorc.Services.IFileService
    {
        public FileService(Microsoft.JSInterop.IJSRuntime jsRuntime) { }
        public System.Threading.Tasks.Task SaveAsync(string fileName, byte[] data) { }
    }
    public interface IComponentService
    {
        Microsoft.AspNetCore.Components.ComponentBase? Component { get; set; }
    }
    public interface IComponentServiceFactory : Blorc.Services.IFactory
    {
        System.Collections.Generic.IEnumerable<TComponentService> Get<TComponentService>(Microsoft.AspNetCore.Components.ComponentBase componentBase)
            where TComponentService : Blorc.Services.IComponentService;
        TComponentService Get<TComponentService>(Microsoft.AspNetCore.Components.ComponentBase componentBase, System.Type targetType)
            where TComponentService : Blorc.Services.IComponentService;
        void Map<TComponent, TService>()
            where TComponent : Microsoft.AspNetCore.Components.ComponentBase
            where TService : Blorc.Services.IComponentService;
    }
    public interface IConfigurationService
    {
        System.Threading.Tasks.Task<T?> GetSectionAsync<T>(string sectionName);
    }
    public static class IConfigurationServiceExtensions
    {
        public static System.Threading.Tasks.Task<T?> GetRequiredSectionAsync<T>(this Blorc.Services.IConfigurationService configurationService, string sectionName) { }
    }
    public interface IDocumentService
    {
        System.Threading.Tasks.Task<Blorc.Services.Interop.Rect> GetBoundingClientRectAsync(double x, double y);
        System.Threading.Tasks.Task<Blorc.Services.Interop.Rect> GetBoundingClientRectByIdAsync(string id);
        System.Threading.Tasks.Task<Blorc.Services.Interop.Rect> GetOffsetBoundingClientRectAsync(double x, double y);
        System.Threading.Tasks.Task InjectHeadAsync(Blorc.Dom.Injectors.IInjectorValueProvider injectorValueProvider);
        System.Threading.Tasks.Task InjectLinkAsync(string href, string rel = "stylesheet", string type = "text/css");
        System.Threading.Tasks.Task InjectScriptAsync(string source, string type = "text/javascript");
    }
    public static class IDocumentServiceExtension
    {
        public static System.Threading.Tasks.Task InjectAssemblyCssFileAsync(this Blorc.Services.IDocumentService @this, System.Reflection.Assembly assembly, string path) { }
        public static System.Threading.Tasks.Task InjectAssemblyScriptFileAsync(this Blorc.Services.IDocumentService @this, System.Reflection.Assembly assembly, string path) { }
        public static System.Threading.Tasks.Task InjectBlorcCoreJsAsync(this Blorc.Services.IDocumentService @this) { }
    }
    public interface IExecutionService : Blorc.Services.IComponentService
    {
        System.Threading.Tasks.Task ExecuteAsync(object? state = null);
    }
    public interface IFactory
    {
        System.Collections.IEnumerable Get(object source);
        object? Get(object source, System.Type targetType);
    }
    public interface IFileService
    {
        System.Threading.Tasks.Task SaveAsync(string fileName, byte[] data);
    }
    public interface IProgressService<T>
    {
        System.Threading.Tasks.Task ReportAsync(T value);
    }
    public static class IServiceCollectionExtension
    {
        public static void AddBlorcCore(this Microsoft.Extensions.DependencyInjection.IServiceCollection @this) { }
    }
    public interface IServiceDiscovery
    {
        System.Threading.Tasks.Task<string> GetServiceEndPointAsync(string serviceName, int bindingIndex = 0);
        System.Threading.Tasks.Task<string> GetServiceEndPointAsync(string serviceName, string bindingName);
    }
    public interface IUIVisualizationService : Blorc.Services.IComponentService
    {
        System.Threading.Tasks.Task CloseAsync();
        System.Threading.Tasks.Task ShowAsync();
        System.Threading.Tasks.Task UpdateAsync();
    }
    public static class WebAssemblyHostExtensions
    {
        public static System.Threading.Tasks.Task ConfigureAsync(this Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHost @this, System.Func<System.IServiceProvider, System.Threading.Tasks.Task> options) { }
        public static System.Threading.Tasks.Task ConfigureDocumentAsync(this Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHost @this, System.Func<Blorc.Services.IDocumentService, System.Threading.Tasks.Task> options) { }
        public static Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHost MapComponentServices(this Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHost @this, System.Action<Blorc.Services.IComponentServiceFactory> options) { }
    }
}
namespace Blorc.Services.Interop
{
    public class Rect
    {
        public Rect() { }
        public double Bottom { get; set; }
        public double Height { get; set; }
        public double Top { get; set; }
        public double Width { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }
}
namespace Blorc.StateConverters
{
    public sealed class FixedValueConverter : Blorc.StateConverters.IStateConverter, System.IDisposable
    {
        public FixedValueConverter(string fixedValue) { }
        public void Dispose() { }
        public string GetValue() { }
    }
    public interface IStateConverter : System.IDisposable
    {
        string GetValue();
    }
    public interface IStateConverterContainer : System.IDisposable
    {
        void MarkDirty();
    }
    public interface IStateUpdater : System.IDisposable
    {
        void Update(string value);
    }
    public interface IStateWatcher : System.IDisposable
    {
        event System.EventHandler<System.EventArgs>? StateChanged;
    }
    public class PredicateValueConverter : Blorc.StateConverters.StateConverterBase
    {
        public PredicateValueConverter(System.Func<string> valueFunc, System.Func<bool>? predicate) { }
        public PredicateValueConverter(string value, System.Func<bool>? predicate) { }
    }
    public class PropertyStateUpdater : Blorc.StateConverters.StateUpdaterBase
    {
        public PropertyStateUpdater(object instance, string propertyName) { }
    }
    public class PropertyStateWatcher : Blorc.StateConverters.StateWatcherBase
    {
        public PropertyStateWatcher(object source, string propertyName) { }
        protected override void DisposeManaged() { }
    }
    public abstract class StateConverterBase : Blorc.StateConverters.IStateConverter, System.IDisposable
    {
        protected readonly System.Func<bool>? Predicate;
        protected readonly System.Func<string> ValueFunc;
        public StateConverterBase(System.Func<string> valueFunc, System.Func<bool>? predicate) { }
        public void Dispose() { }
        protected virtual void DisposeManaged() { }
        public virtual string GetValue() { }
    }
    public class StateConverterContainer : Blorc.StateConverters.IStateConverterContainer, System.IDisposable
    {
        public Blorc.StateConverters.StateConverterContainer Add(Blorc.StateConverters.IStateConverter converter) { }
        public Blorc.StateConverters.StateConverterContainer Add(Blorc.StateConverters.IStateUpdater updater) { }
        public Blorc.StateConverters.StateConverterContainer Add(Blorc.StateConverters.IStateWatcher watcher) { }
        public void Dispose() { }
        protected virtual void DisposeManaged() { }
        public Blorc.StateConverters.StateConverterContainer DoNotForceComponentUpdate() { }
        public string GetValue() { }
        public void MarkDirty() { }
    }
    public static class StateConverterContainerExtensions
    {
        public static Blorc.StateConverters.StateConverterContainer Fixed(this Blorc.StateConverters.StateConverterContainer container, string value) { }
        public static Blorc.StateConverters.StateConverterContainer If(this Blorc.StateConverters.StateConverterContainer container, System.Func<bool>? predicate, System.Func<string> valueFunc) { }
        public static Blorc.StateConverters.StateConverterContainer If(this Blorc.StateConverters.StateConverterContainer container, System.Func<bool>? predicate, string value) { }
        public static Blorc.StateConverters.StateConverterContainer Update<TProperty>(this Blorc.StateConverters.StateConverterContainer container, System.Linq.Expressions.Expression<System.Func<TProperty>> propertyExpression) { }
        public static Blorc.StateConverters.StateConverterContainer Watch<TProperty>(this Blorc.StateConverters.StateConverterContainer container, System.Linq.Expressions.Expression<System.Func<TProperty>> propertyExpression) { }
    }
    public abstract class StateUpdaterBase : Blorc.StateConverters.IStateUpdater, System.IDisposable
    {
        public StateUpdaterBase(System.Action<string> updater) { }
        public void Dispose() { }
        protected virtual void DisposeManaged() { }
        public virtual void Update(string value) { }
    }
    public abstract class StateWatcherBase : Blorc.StateConverters.IStateWatcher, System.IDisposable
    {
        protected StateWatcherBase() { }
        public event System.EventHandler<System.EventArgs>? StateChanged;
        public void Dispose() { }
        protected virtual void DisposeManaged() { }
        protected virtual void RaiseStateChanged() { }
    }
}