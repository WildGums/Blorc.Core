// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFactory.cs" company="WildGums">
//   Copyright (c) 2008 - 2020 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.Services
{
    using System;
    using System.Collections;

    public interface IFactory
    {
        IEnumerable Get(object source);

        object Get(object source, Type targetType);
    }
}
