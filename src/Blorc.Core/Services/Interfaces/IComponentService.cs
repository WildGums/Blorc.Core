// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IComponentServiceBase.cs" company="WildGums">
//   Copyright (c) 2008 - 2020 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.Services
{
    using Microsoft.AspNetCore.Components;

    public interface IComponentService
    {
        ComponentBase Component { get; set; }
    }
}
