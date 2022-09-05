﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeExtensions.cs" company="Catel development team">
//   Copyright (c) 2008 - 2015 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Blorc.Reflection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extensions for the type class.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Determines whether the specified type is a class type, meaning it is not a value type but also not a string
        /// or any of the primitive types in .NET.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if this type is a class type; otherwise, <c>false</c>.</returns>
        public static bool IsClassType(this Type type)
        {
            if (type is null)
            {
                return false;
            }

            if (type.IsValueType)
            {
                return false;
            }

            if (type == typeof(string))
            {
                return false;
            }

            return type.IsClass;
        }

        /// <summary>
        /// Determines whether the specified type is a collection.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if the specified type is a collection; otherwise, <c>false</c>.</returns>
        public static bool IsCollection(this Type type)
        {
            if (type is null)
            {
                return false;
            }

            if (type == typeof(string))
            {
                return false;
            }

            return typeof(IEnumerable).IsAssignableFrom(type);
        }

        /// <summary>
        /// Determines whether the specified type is a dictionary.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if the specified type is a dictionary; otherwise, <c>false</c>.</returns>
        public static bool IsDictionary(this Type type)
        {
            if (type is null)
            {
                return false;
            }

            if (type == typeof(string))
            {
                return false;
            }

            if (!type.IsGenericType)
            {
                return false;
            }

            var genericDefinition = type.GetGenericTypeDefinition();
            return genericDefinition == typeof(Dictionary<,>);
        }

        /// <summary>
        /// Returns whether a type is nullable or not.
        /// </summary>
        /// <param name="type">Type to check.</param>
        /// <returns>True if the type is nullable, otherwise false.</returns>
        public static bool IsNullableType(this Type type)
        {
            if (type is null)
            {
                return false;
            }

            if (!type.IsValueType)
            {
                return true;
            }

            if (Nullable.GetUnderlyingType(type) is not null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether the specified type is a basic type. A basic type is one that can be wholly expressed
        /// as an XML attribute. All primitive data types and <see cref="String"/> and <see cref="DateTime"/> are basic types.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns><c>true</c> if the specified type is a basic type; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="type"/> is <c>null</c>.</exception>
        public static bool IsBasicType(this Type type)
        {
            if (type == typeof(string) || type.IsPrimitive || type.IsEnum || type == typeof(DateTime) || type == typeof(decimal) || type == typeof(Guid))
            {
                return true;
            }

            if (IsNullableType(type))
            {
                var underlyingNullableType = Nullable.GetUnderlyingType(type);
                if (underlyingNullableType is not null)
                {
                    return IsBasicType(underlyingNullableType);
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the element type of the collection.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>Type.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="type"/> is <c>null</c>.</exception>
        public static Type GetCollectionElementType(this Type type)
        {
            if (type.IsArray)
            {
                return type.GetElementType();
            }

            Type genericEnumerableInterface;
            if (typeof(IEnumerable).IsAssignableFrom(type) && type.IsGenericType)
            {
                genericEnumerableInterface = type;
            }
            else
            {
                genericEnumerableInterface = type.GetInterfaces().FirstOrDefault(i => i.Name.StartsWith("IEnumerable") && i.IsGenericType);
            }

            return genericEnumerableInterface?.GetGenericArguments().FirstOrDefault();
        }
    }
}
