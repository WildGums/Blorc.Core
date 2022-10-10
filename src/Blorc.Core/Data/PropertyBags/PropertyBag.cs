﻿namespace Blorc.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Blorc;

    /// <summary>
    /// Class that is able to manage all properties of a specific object in a thread-safe manner.
    /// </summary>
    public partial class PropertyBag : PropertyBagBase
    {
        private readonly object _lockObject = new object();

        private readonly IDictionary<string, object?> _properties;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyBag"/> class.
        /// </summary>
        public PropertyBag()
            : this(new Dictionary<string, object?>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyBag"/> class.
        /// </summary>
        /// <param name="propertyDictionary">The property dictionary.</param>
        public PropertyBag(IDictionary<string, object?> propertyDictionary)
        {
            _properties = propertyDictionary;
        }

        /// <summary>
        /// Gets or sets the property using the indexer.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The value of the property.</returns>
        public object this[string name]
        {
            get { return GetValue<object>(name); }
            set { SetValue(name, value); }
        }

        /// <summary>
        /// Imports the properties in the existing dictionary.
        /// <para />
        /// This method will overwrite all existing property values in the property bag.
        /// </summary>
        /// <param name="propertiesToImport">The properties to import.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="propertiesToImport"/> is <c>null</c>.</exception>
        public void Import(Dictionary<string, object?> propertiesToImport)
        {
            ArgumentNullException.ThrowIfNull(propertiesToImport);

            foreach (var property in propertiesToImport)
            {
                SetValue(property.Key, property.Value);
            }
        }

        public override bool IsAvailable(string name)
        {
            ArgumentNullException.ThrowIfNull(name);

            lock (_lockObject)
            {
                return _properties.ContainsKey(name);
            }
        }

        /// <summary>
        /// Gets all the currently available properties in the property bag.
        /// </summary>
        /// <returns>A list of all property names and values.</returns>
        public override Dictionary<string, object?> GetAllProperties()
        {
            lock (_lockObject)
            {
                return _properties.ToDictionary(x => x.Key, x => x.Value);
            }
        }

        public override string[] GetAllNames()
        {
            lock (_lockObject)
            {
                return _properties.Keys.ToArray();
            }
        }

        public override TValue GetValue<TValue>(string name, TValue defaultValue = default!)
        {
            ArgumentNullException.ThrowIfNull(name);

            lock (_lockObject)
            {
                if (_properties.TryGetValue(name, out var propertyValue))
                {
                    return (TValue)propertyValue!;

                    //// Safe-guard null values for value types
                    //if (!(propertyValue is null) || typeof(TValue).IsNullableType())
                    //{
                    //    return (TValue)propertyValue;
                    //}
                }

                return defaultValue;
            }
        }

        public override void SetValue<TValue>(string name, TValue value)
        {
            ArgumentNullException.ThrowIfNull(name);

            var raisePropertyChanged = false;

            lock (_lockObject)
            {
                if (!_properties.TryGetValue(name, out var propertyValue) || 
                    !ObjectHelper.AreEqual(propertyValue, value))
                {
                    _properties[name] = value;
                    raisePropertyChanged = true;
                }
            }

            if (raisePropertyChanged)
            {
                RaisePropertyChanged(name);
            }
        }

        /// <summary>
        /// Updates the property value by retrieving it from the property bag. After invoking the update action,
        /// the value will be written back to the property bag.
        /// </summary>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="update">The update.</param>
        public void UpdatePropertyValue<TValue>(string propertyName, Func<TValue, TValue> update)
        {
            ArgumentNullException.ThrowIfNull(propertyName);
            ArgumentNullException.ThrowIfNull(update);

            lock (_lockObject)
            {
                if (!_properties.TryGetValue(propertyName, out var propertyValue))
                {
                    return;
                }

                var value = (TValue)propertyValue!;
                var updatedValue = update(value);

                SetValue(propertyName, updatedValue);
            }
        }
    }
}
