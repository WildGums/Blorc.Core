// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SurveyVisualizationService.cs" company="WildGums">
//   Copyright (c) 2008 - 2020 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.Example
{
    using System;
    using System.Threading.Tasks;

    using Blorc.Services;

    using Microsoft.AspNetCore.Components;

    public class SurveyVisualizationService : IUIVisualizationService
    {
        public ComponentBase Component { get; set; }

        public Task CloseAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task ShowAsync()
        {
            Console.WriteLine("Hello from Visualization!!!");
        }

        public Task UpdateAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
