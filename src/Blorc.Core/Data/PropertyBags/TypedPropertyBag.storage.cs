﻿
//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by a tool. 
// 
// Changes to this file may cause incorrect behavior and will be lost if 
// the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------


namespace Catel.Data
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Catel.Reflection;

    public partial class TypedPropertyBag
    {
        private Dictionary<string, Object> _objectStorage;
        private Dictionary<string, Boolean> _booleanStorage;
        private Dictionary<string, Char> _charStorage;
        private Dictionary<string, SByte> _sbyteStorage;
        private Dictionary<string, Byte> _byteStorage;
        private Dictionary<string, Int16> _int16Storage;
        private Dictionary<string, UInt16> _uint16Storage;
        private Dictionary<string, Int32> _int32Storage;
        private Dictionary<string, UInt32> _uint32Storage;
        private Dictionary<string, Int64> _int64Storage;
        private Dictionary<string, UInt64> _uint64Storage;
        private Dictionary<string, Single> _singleStorage;
        private Dictionary<string, Double> _doubleStorage;
        private Dictionary<string, Decimal> _decimalStorage;
        private Dictionary<string, DateTime> _datetimeStorage;
        private Dictionary<string, String> _stringStorage;

        protected Dictionary<string, Object> GetObjectStorage()
        {
            if (_objectStorage is null)
            {
                _objectStorage = new Dictionary<string, Object>();
            }

            return _objectStorage;
        }

        protected Dictionary<string, Boolean> GetBooleanStorage()
        {
            if (_booleanStorage is null)
            {
                _booleanStorage = new Dictionary<string, Boolean>();
            }

            return _booleanStorage;
        }

        protected Dictionary<string, Char> GetCharStorage()
        {
            if (_charStorage is null)
            {
                _charStorage = new Dictionary<string, Char>();
            }

            return _charStorage;
        }

        protected Dictionary<string, SByte> GetSByteStorage()
        {
            if (_sbyteStorage is null)
            {
                _sbyteStorage = new Dictionary<string, SByte>();
            }

            return _sbyteStorage;
        }

        protected Dictionary<string, Byte> GetByteStorage()
        {
            if (_byteStorage is null)
            {
                _byteStorage = new Dictionary<string, Byte>();
            }

            return _byteStorage;
        }

        protected Dictionary<string, Int16> GetInt16Storage()
        {
            if (_int16Storage is null)
            {
                _int16Storage = new Dictionary<string, Int16>();
            }

            return _int16Storage;
        }

        protected Dictionary<string, UInt16> GetUInt16Storage()
        {
            if (_uint16Storage is null)
            {
                _uint16Storage = new Dictionary<string, UInt16>();
            }

            return _uint16Storage;
        }

        protected Dictionary<string, Int32> GetInt32Storage()
        {
            if (_int32Storage is null)
            {
                _int32Storage = new Dictionary<string, Int32>();
            }

            return _int32Storage;
        }

        protected Dictionary<string, UInt32> GetUInt32Storage()
        {
            if (_uint32Storage is null)
            {
                _uint32Storage = new Dictionary<string, UInt32>();
            }

            return _uint32Storage;
        }

        protected Dictionary<string, Int64> GetInt64Storage()
        {
            if (_int64Storage is null)
            {
                _int64Storage = new Dictionary<string, Int64>();
            }

            return _int64Storage;
        }

        protected Dictionary<string, UInt64> GetUInt64Storage()
        {
            if (_uint64Storage is null)
            {
                _uint64Storage = new Dictionary<string, UInt64>();
            }

            return _uint64Storage;
        }

        protected Dictionary<string, Single> GetSingleStorage()
        {
            if (_singleStorage is null)
            {
                _singleStorage = new Dictionary<string, Single>();
            }

            return _singleStorage;
        }

        protected Dictionary<string, Double> GetDoubleStorage()
        {
            if (_doubleStorage is null)
            {
                _doubleStorage = new Dictionary<string, Double>();
            }

            return _doubleStorage;
        }

        protected Dictionary<string, Decimal> GetDecimalStorage()
        {
            if (_decimalStorage is null)
            {
                _decimalStorage = new Dictionary<string, Decimal>();
            }

            return _decimalStorage;
        }

        protected Dictionary<string, DateTime> GetDateTimeStorage()
        {
            if (_datetimeStorage is null)
            {
                _datetimeStorage = new Dictionary<string, DateTime>();
            }

            return _datetimeStorage;
        }

        protected Dictionary<string, String> GetStringStorage()
        {
            if (_stringStorage is null)
            {
                _stringStorage = new Dictionary<string, String>();
            }

            return _stringStorage;
        }


        public override TValue GetValue<TValue>(string name, TValue defaultValue = default)
        {
            // Get from the right dictionary and see if we need to convert to TValue
            var propertyType = GetRegisteredPropertyType(name);
            if (propertyType is null)
            {
                // Not registered!
                return defaultValue;
            }

            var targetType = typeof(TValue);

            if (targetType == typeof(Boolean))
            {
                var storage = GetBooleanStorage();

                lock (storage)
                {
                    if (storage.TryGetValue(name, out var bagValue))
                    {
                        // Simply cast
                        var tr = __makeref(bagValue);
                        var value = __refvalue(tr, TValue);
                        return value;
                    }
                }

                return default;
            }

            if (targetType == typeof(Char))
            {
                var storage = GetCharStorage();

                lock (storage)
                {
                    if (storage.TryGetValue(name, out var bagValue))
                    {
                        // Simply cast
                        var tr = __makeref(bagValue);
                        var value = __refvalue(tr, TValue);
                        return value;
                    }
                }

                return default;
            }

            if (targetType == typeof(SByte))
            {
                var storage = GetSByteStorage();

                lock (storage)
                {
                    if (storage.TryGetValue(name, out var bagValue))
                    {
                        // Simply cast
                        var tr = __makeref(bagValue);
                        var value = __refvalue(tr, TValue);
                        return value;
                    }
                }

                return default;
            }

            if (targetType == typeof(Byte))
            {
                var storage = GetByteStorage();

                lock (storage)
                {
                    if (storage.TryGetValue(name, out var bagValue))
                    {
                        // Simply cast
                        var tr = __makeref(bagValue);
                        var value = __refvalue(tr, TValue);
                        return value;
                    }
                }

                return default;
            }

            if (targetType == typeof(Int16))
            {
                var storage = GetInt16Storage();

                lock (storage)
                {
                    if (storage.TryGetValue(name, out var bagValue))
                    {
                        // Simply cast
                        var tr = __makeref(bagValue);
                        var value = __refvalue(tr, TValue);
                        return value;
                    }
                }

                return default;
            }

            if (targetType == typeof(UInt16))
            {
                var storage = GetUInt16Storage();

                lock (storage)
                {
                    if (storage.TryGetValue(name, out var bagValue))
                    {
                        // Simply cast
                        var tr = __makeref(bagValue);
                        var value = __refvalue(tr, TValue);
                        return value;
                    }
                }

                return default;
            }

            if (targetType == typeof(Int32))
            {
                var storage = GetInt32Storage();

                lock (storage)
                {
                    if (storage.TryGetValue(name, out var bagValue))
                    {
                        // Simply cast
                        var tr = __makeref(bagValue);
                        var value = __refvalue(tr, TValue);
                        return value;
                    }
                }

                return default;
            }

            if (targetType == typeof(UInt32))
            {
                var storage = GetUInt32Storage();

                lock (storage)
                {
                    if (storage.TryGetValue(name, out var bagValue))
                    {
                        // Simply cast
                        var tr = __makeref(bagValue);
                        var value = __refvalue(tr, TValue);
                        return value;
                    }
                }

                return default;
            }

            if (targetType == typeof(Int64))
            {
                var storage = GetInt64Storage();

                lock (storage)
                {
                    if (storage.TryGetValue(name, out var bagValue))
                    {
                        // Simply cast
                        var tr = __makeref(bagValue);
                        var value = __refvalue(tr, TValue);
                        return value;
                    }
                }

                return default;
            }

            if (targetType == typeof(UInt64))
            {
                var storage = GetUInt64Storage();

                lock (storage)
                {
                    if (storage.TryGetValue(name, out var bagValue))
                    {
                        // Simply cast
                        var tr = __makeref(bagValue);
                        var value = __refvalue(tr, TValue);
                        return value;
                    }
                }

                return default;
            }

            if (targetType == typeof(Single))
            {
                var storage = GetSingleStorage();

                lock (storage)
                {
                    if (storage.TryGetValue(name, out var bagValue))
                    {
                        // Simply cast
                        var tr = __makeref(bagValue);
                        var value = __refvalue(tr, TValue);
                        return value;
                    }
                }

                return default;
            }

            if (targetType == typeof(Double))
            {
                var storage = GetDoubleStorage();

                lock (storage)
                {
                    if (storage.TryGetValue(name, out var bagValue))
                    {
                        // Simply cast
                        var tr = __makeref(bagValue);
                        var value = __refvalue(tr, TValue);
                        return value;
                    }
                }

                return default;
            }

            if (targetType == typeof(Decimal))
            {
                var storage = GetDecimalStorage();

                lock (storage)
                {
                    if (storage.TryGetValue(name, out var bagValue))
                    {
                        // Simply cast
                        var tr = __makeref(bagValue);
                        var value = __refvalue(tr, TValue);
                        return value;
                    }
                }

                return default;
            }

            if (targetType == typeof(DateTime))
            {
                var storage = GetDateTimeStorage();

                lock (storage)
                {
                    if (storage.TryGetValue(name, out var bagValue))
                    {
                        // Simply cast
                        var tr = __makeref(bagValue);
                        var value = __refvalue(tr, TValue);
                        return value;
                    }
                }

                return default;
            }

            if (targetType == typeof(String))
            {
                var storage = GetStringStorage();

                lock (storage)
                {
                    if (storage.TryGetValue(name, out var bagValue))
                    {
                        // Simply cast
                        var tr = __makeref(bagValue);
                        var value = __refvalue(tr, TValue);
                        return value;
                    }
                }

                return default;
            }


            // Fallback to object store
            {
                var storage = GetObjectStorage();

                lock (storage)
                {
                    if (storage.TryGetValue(name, out var bagValue))
                    {
                        // Simply cast
                        //var tr = __makeref(bagValue);
                        //var value = __refvalue(tr, TValue);
                        return (TValue)bagValue;
                    }
                }

                return default;
            }
        }

        public override void SetValue<TValue>(string name, TValue value)
        {
            var stored = false;
            var raisePropertyChanged = false;

            var targetType = typeof(TValue);
            if (typeof(TValue) == typeof(object)) 
            {
                // If users use SetValue<object>(), we might need to convert
                var propertyType = GetRegisteredPropertyType(name);
                if (propertyType != null)
                {
                    if (propertyType.IsValueType && value == null)
                    {
                        throw new InvalidOperationException($"Property '{name}' cannot be updated with a null value since it represents a value of '{propertyType.FullName}'");
                    }

                    // Slowest path, we need to cast and store in the right dictionary
                    if (propertyType == typeof(Boolean))
                    {
                        //if (value is Boolean typedValue)
                        //{
                        var castValue = (Boolean)(object)value;
                        SetValue<Boolean>(name, castValue);
                        return;
                        //}
                    }

                    if (propertyType == typeof(Char))
                    {
                        //if (value is Char typedValue)
                        //{
                        var castValue = (Char)(object)value;
                        SetValue<Char>(name, castValue);
                        return;
                        //}
                    }

                    if (propertyType == typeof(SByte))
                    {
                        //if (value is SByte typedValue)
                        //{
                        var castValue = (SByte)(object)value;
                        SetValue<SByte>(name, castValue);
                        return;
                        //}
                    }

                    if (propertyType == typeof(Byte))
                    {
                        //if (value is Byte typedValue)
                        //{
                        var castValue = (Byte)(object)value;
                        SetValue<Byte>(name, castValue);
                        return;
                        //}
                    }

                    if (propertyType == typeof(Int16))
                    {
                        //if (value is Int16 typedValue)
                        //{
                        var castValue = (Int16)(object)value;
                        SetValue<Int16>(name, castValue);
                        return;
                        //}
                    }

                    if (propertyType == typeof(UInt16))
                    {
                        //if (value is UInt16 typedValue)
                        //{
                        var castValue = (UInt16)(object)value;
                        SetValue<UInt16>(name, castValue);
                        return;
                        //}
                    }

                    if (propertyType == typeof(Int32))
                    {
                        //if (value is Int32 typedValue)
                        //{
                        var castValue = (Int32)(object)value;
                        SetValue<Int32>(name, castValue);
                        return;
                        //}
                    }

                    if (propertyType == typeof(UInt32))
                    {
                        //if (value is UInt32 typedValue)
                        //{
                        var castValue = (UInt32)(object)value;
                        SetValue<UInt32>(name, castValue);
                        return;
                        //}
                    }

                    if (propertyType == typeof(Int64))
                    {
                        //if (value is Int64 typedValue)
                        //{
                        var castValue = (Int64)(object)value;
                        SetValue<Int64>(name, castValue);
                        return;
                        //}
                    }

                    if (propertyType == typeof(UInt64))
                    {
                        //if (value is UInt64 typedValue)
                        //{
                        var castValue = (UInt64)(object)value;
                        SetValue<UInt64>(name, castValue);
                        return;
                        //}
                    }

                    if (propertyType == typeof(Single))
                    {
                        //if (value is Single typedValue)
                        //{
                        var castValue = (Single)(object)value;
                        SetValue<Single>(name, castValue);
                        return;
                        //}
                    }

                    if (propertyType == typeof(Double))
                    {
                        //if (value is Double typedValue)
                        //{
                        var castValue = (Double)(object)value;
                        SetValue<Double>(name, castValue);
                        return;
                        //}
                    }

                    if (propertyType == typeof(Decimal))
                    {
                        //if (value is Decimal typedValue)
                        //{
                        var castValue = (Decimal)(object)value;
                        SetValue<Decimal>(name, castValue);
                        return;
                        //}
                    }

                    if (propertyType == typeof(DateTime))
                    {
                        //if (value is DateTime typedValue)
                        //{
                        var castValue = (DateTime)(object)value;
                        SetValue<DateTime>(name, castValue);
                        return;
                        //}
                    }

                    if (propertyType == typeof(String))
                    {
                        //if (value is String typedValue)
                        //{
                        var castValue = (String)(object)value;
                        SetValue<String>(name, castValue);
                        return;
                        //}
                    }

                    // Fallback to object storage
                }
            }
            if (!stored && targetType == typeof(Boolean))
            {
                EnsureIntegrity(name, typeof(TValue));

                var tr = __makeref(value);
                var bagValue = __refvalue(tr, Boolean);
                var storage = GetBooleanStorage();

                lock (storage)
                {
                    if (!storage.TryGetValue(name, out var propertyValue) || propertyValue != bagValue)
                    {
                        storage[name] = bagValue;
                        raisePropertyChanged = true;
                    }
                }

                stored = true;
            }

            if (!stored && targetType == typeof(Char))
            {
                EnsureIntegrity(name, typeof(TValue));

                var tr = __makeref(value);
                var bagValue = __refvalue(tr, Char);
                var storage = GetCharStorage();

                lock (storage)
                {
                    if (!storage.TryGetValue(name, out var propertyValue) || propertyValue != bagValue)
                    {
                        storage[name] = bagValue;
                        raisePropertyChanged = true;
                    }
                }

                stored = true;
            }

            if (!stored && targetType == typeof(SByte))
            {
                EnsureIntegrity(name, typeof(TValue));

                var tr = __makeref(value);
                var bagValue = __refvalue(tr, SByte);
                var storage = GetSByteStorage();

                lock (storage)
                {
                    if (!storage.TryGetValue(name, out var propertyValue) || propertyValue != bagValue)
                    {
                        storage[name] = bagValue;
                        raisePropertyChanged = true;
                    }
                }

                stored = true;
            }

            if (!stored && targetType == typeof(Byte))
            {
                EnsureIntegrity(name, typeof(TValue));

                var tr = __makeref(value);
                var bagValue = __refvalue(tr, Byte);
                var storage = GetByteStorage();

                lock (storage)
                {
                    if (!storage.TryGetValue(name, out var propertyValue) || propertyValue != bagValue)
                    {
                        storage[name] = bagValue;
                        raisePropertyChanged = true;
                    }
                }

                stored = true;
            }

            if (!stored && targetType == typeof(Int16))
            {
                EnsureIntegrity(name, typeof(TValue));

                var tr = __makeref(value);
                var bagValue = __refvalue(tr, Int16);
                var storage = GetInt16Storage();

                lock (storage)
                {
                    if (!storage.TryGetValue(name, out var propertyValue) || propertyValue != bagValue)
                    {
                        storage[name] = bagValue;
                        raisePropertyChanged = true;
                    }
                }

                stored = true;
            }

            if (!stored && targetType == typeof(UInt16))
            {
                EnsureIntegrity(name, typeof(TValue));

                var tr = __makeref(value);
                var bagValue = __refvalue(tr, UInt16);
                var storage = GetUInt16Storage();

                lock (storage)
                {
                    if (!storage.TryGetValue(name, out var propertyValue) || propertyValue != bagValue)
                    {
                        storage[name] = bagValue;
                        raisePropertyChanged = true;
                    }
                }

                stored = true;
            }

            if (!stored && targetType == typeof(Int32))
            {
                EnsureIntegrity(name, typeof(TValue));

                var tr = __makeref(value);
                var bagValue = __refvalue(tr, Int32);
                var storage = GetInt32Storage();

                lock (storage)
                {
                    if (!storage.TryGetValue(name, out var propertyValue) || propertyValue != bagValue)
                    {
                        storage[name] = bagValue;
                        raisePropertyChanged = true;
                    }
                }

                stored = true;
            }

            if (!stored && targetType == typeof(UInt32))
            {
                EnsureIntegrity(name, typeof(TValue));

                var tr = __makeref(value);
                var bagValue = __refvalue(tr, UInt32);
                var storage = GetUInt32Storage();

                lock (storage)
                {
                    if (!storage.TryGetValue(name, out var propertyValue) || propertyValue != bagValue)
                    {
                        storage[name] = bagValue;
                        raisePropertyChanged = true;
                    }
                }

                stored = true;
            }

            if (!stored && targetType == typeof(Int64))
            {
                EnsureIntegrity(name, typeof(TValue));

                var tr = __makeref(value);
                var bagValue = __refvalue(tr, Int64);
                var storage = GetInt64Storage();

                lock (storage)
                {
                    if (!storage.TryGetValue(name, out var propertyValue) || propertyValue != bagValue)
                    {
                        storage[name] = bagValue;
                        raisePropertyChanged = true;
                    }
                }

                stored = true;
            }

            if (!stored && targetType == typeof(UInt64))
            {
                EnsureIntegrity(name, typeof(TValue));

                var tr = __makeref(value);
                var bagValue = __refvalue(tr, UInt64);
                var storage = GetUInt64Storage();

                lock (storage)
                {
                    if (!storage.TryGetValue(name, out var propertyValue) || propertyValue != bagValue)
                    {
                        storage[name] = bagValue;
                        raisePropertyChanged = true;
                    }
                }

                stored = true;
            }

            if (!stored && targetType == typeof(Single))
            {
                EnsureIntegrity(name, typeof(TValue));

                var tr = __makeref(value);
                var bagValue = __refvalue(tr, Single);
                var storage = GetSingleStorage();

                lock (storage)
                {
                    if (!storage.TryGetValue(name, out var propertyValue) || propertyValue != bagValue)
                    {
                        storage[name] = bagValue;
                        raisePropertyChanged = true;
                    }
                }

                stored = true;
            }

            if (!stored && targetType == typeof(Double))
            {
                EnsureIntegrity(name, typeof(TValue));

                var tr = __makeref(value);
                var bagValue = __refvalue(tr, Double);
                var storage = GetDoubleStorage();

                lock (storage)
                {
                    if (!storage.TryGetValue(name, out var propertyValue) || propertyValue != bagValue)
                    {
                        storage[name] = bagValue;
                        raisePropertyChanged = true;
                    }
                }

                stored = true;
            }

            if (!stored && targetType == typeof(Decimal))
            {
                EnsureIntegrity(name, typeof(TValue));

                var tr = __makeref(value);
                var bagValue = __refvalue(tr, Decimal);
                var storage = GetDecimalStorage();

                lock (storage)
                {
                    if (!storage.TryGetValue(name, out var propertyValue) || propertyValue != bagValue)
                    {
                        storage[name] = bagValue;
                        raisePropertyChanged = true;
                    }
                }

                stored = true;
            }

            if (!stored && targetType == typeof(DateTime))
            {
                EnsureIntegrity(name, typeof(TValue));

                var tr = __makeref(value);
                var bagValue = __refvalue(tr, DateTime);
                var storage = GetDateTimeStorage();

                lock (storage)
                {
                    if (!storage.TryGetValue(name, out var propertyValue) || propertyValue != bagValue)
                    {
                        storage[name] = bagValue;
                        raisePropertyChanged = true;
                    }
                }

                stored = true;
            }

            if (!stored && targetType == typeof(String))
            {
                EnsureIntegrity(name, typeof(TValue));

                var tr = __makeref(value);
                var bagValue = __refvalue(tr, String);
                var storage = GetStringStorage();

                lock (storage)
                {
                    if (!storage.TryGetValue(name, out var propertyValue) || propertyValue != bagValue)
                    {
                        storage[name] = bagValue;
                        raisePropertyChanged = true;
                    }
                }

                stored = true;
            }


            if (!stored)
            {
                // Just store as object (and check integrity as object)
                EnsureIntegrity(name, typeof(object));

                // No need for special casting, just store as object
                //var tr = __makeref(value);
                //var bagValue = __refvalue(tr, object);
                var storage = GetObjectStorage();

                lock (storage)
                {
                    if (!storage.TryGetValue(name, out var propertyValue) || !ObjectHelper.AreEqualReferences(propertyValue, value))
                    {
                        storage[name] = value;
                        raisePropertyChanged = true;
                    }
                }

                stored = true;
            }

            if (raisePropertyChanged)
            {
                RaisePropertyChanged(name);
            }
        }

        public override Dictionary<string, object> GetAllProperties()
        {
            var values = new Dictionary<string, object>();

            // Note: don't use methods, we don't want to lazy-instantiate the storage
            var booleanStorage = _booleanStorage;
            if (booleanStorage != null)
            {
                 // Unfortunately we have to box to object here...
                 foreach (var propertyPair in booleanStorage)
                 {
                     values[propertyPair.Key] = BoxingCache.GetBoxedValue(propertyPair.Value);
                 }
            }

            var charStorage = _charStorage;
            if (charStorage != null)
            {
                 // Unfortunately we have to box to object here...
                 foreach (var propertyPair in charStorage)
                 {
                     values[propertyPair.Key] = BoxingCache.GetBoxedValue(propertyPair.Value);
                 }
            }

            var sbyteStorage = _sbyteStorage;
            if (sbyteStorage != null)
            {
                 // Unfortunately we have to box to object here...
                 foreach (var propertyPair in sbyteStorage)
                 {
                     values[propertyPair.Key] = BoxingCache.GetBoxedValue(propertyPair.Value);
                 }
            }

            var byteStorage = _byteStorage;
            if (byteStorage != null)
            {
                 // Unfortunately we have to box to object here...
                 foreach (var propertyPair in byteStorage)
                 {
                     values[propertyPair.Key] = BoxingCache.GetBoxedValue(propertyPair.Value);
                 }
            }

            var int16Storage = _int16Storage;
            if (int16Storage != null)
            {
                 // Unfortunately we have to box to object here...
                 foreach (var propertyPair in int16Storage)
                 {
                     values[propertyPair.Key] = BoxingCache.GetBoxedValue(propertyPair.Value);
                 }
            }

            var uint16Storage = _uint16Storage;
            if (uint16Storage != null)
            {
                 // Unfortunately we have to box to object here...
                 foreach (var propertyPair in uint16Storage)
                 {
                     values[propertyPair.Key] = BoxingCache.GetBoxedValue(propertyPair.Value);
                 }
            }

            var int32Storage = _int32Storage;
            if (int32Storage != null)
            {
                 // Unfortunately we have to box to object here...
                 foreach (var propertyPair in int32Storage)
                 {
                     values[propertyPair.Key] = BoxingCache.GetBoxedValue(propertyPair.Value);
                 }
            }

            var uint32Storage = _uint32Storage;
            if (uint32Storage != null)
            {
                 // Unfortunately we have to box to object here...
                 foreach (var propertyPair in uint32Storage)
                 {
                     values[propertyPair.Key] = BoxingCache.GetBoxedValue(propertyPair.Value);
                 }
            }

            var int64Storage = _int64Storage;
            if (int64Storage != null)
            {
                 // Unfortunately we have to box to object here...
                 foreach (var propertyPair in int64Storage)
                 {
                     values[propertyPair.Key] = BoxingCache.GetBoxedValue(propertyPair.Value);
                 }
            }

            var uint64Storage = _uint64Storage;
            if (uint64Storage != null)
            {
                 // Unfortunately we have to box to object here...
                 foreach (var propertyPair in uint64Storage)
                 {
                     values[propertyPair.Key] = BoxingCache.GetBoxedValue(propertyPair.Value);
                 }
            }

            var singleStorage = _singleStorage;
            if (singleStorage != null)
            {
                 // Unfortunately we have to box to object here...
                 foreach (var propertyPair in singleStorage)
                 {
                     values[propertyPair.Key] = BoxingCache.GetBoxedValue(propertyPair.Value);
                 }
            }

            var doubleStorage = _doubleStorage;
            if (doubleStorage != null)
            {
                 // Unfortunately we have to box to object here...
                 foreach (var propertyPair in doubleStorage)
                 {
                     values[propertyPair.Key] = BoxingCache.GetBoxedValue(propertyPair.Value);
                 }
            }

            var decimalStorage = _decimalStorage;
            if (decimalStorage != null)
            {
                 // Unfortunately we have to box to object here...
                 foreach (var propertyPair in decimalStorage)
                 {
                     values[propertyPair.Key] = BoxingCache.GetBoxedValue(propertyPair.Value);
                 }
            }

            var datetimeStorage = _datetimeStorage;
            if (datetimeStorage != null)
            {
                 // Unfortunately we have to box to object here...
                 foreach (var propertyPair in datetimeStorage)
                 {
                     values[propertyPair.Key] = BoxingCache.GetBoxedValue(propertyPair.Value);
                 }
            }

            var stringStorage = _stringStorage;
            if (stringStorage != null)
            {
                 // Unfortunately we have to box to object here...
                 foreach (var propertyPair in stringStorage)
                 {
                     values[propertyPair.Key] = BoxingCache.GetBoxedValue(propertyPair.Value);
                 }
            }


            var objectStorage = _objectStorage;
            if (objectStorage != null)
            {
                foreach (var propertyPair in objectStorage)
                {
                    values[propertyPair.Key] = propertyPair.Value;
                }
            }

            return values;
        }
    }
}
