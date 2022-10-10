namespace Blorc.Reflection
{
    // Note: this code comes from Catel:
    // https://raw.githubusercontent.com/Catel/Catel/58d964c15281728972d9f1326048fdf665045663/src/Catel.Core/Reflection/Helpers/PropertyHelper.cs

    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    public static partial class PropertyHelper
    {
        public static object? GetPropertyValue(object obj, string property, bool ignoreCase = false)
        {
            ArgumentNullException.ThrowIfNull(obj);
            ArgumentNullException.ThrowIfNull(property);

            return GetPropertyValue<object?>(obj, property, ignoreCase);
        }

        public static TValue? GetPropertyValue<TValue>(object obj, string property, bool ignoreCase = false)
        {
            ArgumentNullException.ThrowIfNull(obj);
            ArgumentNullException.ThrowIfNull(property);

            TryGetPropertyValue<TValue>(obj, property, ignoreCase, out var returnValue);

            return returnValue;
        }

        private static bool TryGetPropertyValue<TValue>(object obj, string property, bool ignoreCase, [NotNullWhen(true)]out TValue? value)
        {
            ArgumentNullException.ThrowIfNull(obj);
            ArgumentNullException.ThrowIfNull(property);

            value = default;

            var propertyInfo = GetPropertyInfo(obj, property, ignoreCase);
            if (propertyInfo is null)
            {
                return false;
            }

            // Return property value if available
            if (!propertyInfo.CanRead)
            {
                return false;
            }

            try
            {
                value = (TValue)propertyInfo.GetValue(obj, null)!;
                return true;
            }
            catch (MethodAccessException)
            {
                return false;
            }
        }

        public static void SetPropertyValue(object obj, string property, object? value, bool ignoreCase = false)
        {
            ArgumentNullException.ThrowIfNull(obj);
            ArgumentNullException.ThrowIfNull(property);

            TrySetPropertyValue(obj, property, value, ignoreCase);
        }

        private static bool TrySetPropertyValue(object obj, string property, object? value, bool ignoreCase)
        {
            ArgumentNullException.ThrowIfNull(obj);
            ArgumentNullException.ThrowIfNull(property);

            var propertyInfo = GetPropertyInfo(obj, property, ignoreCase);
            if (propertyInfo is null)
            {
                return false;
            }

            if (!propertyInfo.CanWrite)
            {
                return false;
            }

            var setMethod = propertyInfo.GetSetMethod(true);
            if (setMethod is null)
            {
                return false;
            }

            setMethod.Invoke(obj, new[] { value });

            return true;
        }

        public static PropertyInfo? GetPropertyInfo(object obj, string property, bool ignoreCase = false)
        {
            ArgumentNullException.ThrowIfNull(obj);
            ArgumentNullException.ThrowIfNull(property);

            var objectType = obj.GetType();

            if (!ignoreCase)
            {
                // Use old mechanism to ensure no breaking changes / performance hite
                return objectType.GetProperty(property);
            }

            var allProperties = objectType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var propertyInfo in allProperties)
            {
                if (string.Equals(propertyInfo.Name, property, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal))
                {
                    return propertyInfo;
                }
            }

            return null;
        }
    }
}
