// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SurveyVisualizationService.cs" company="WildGums">
//   Copyright (c) 2008 - 2020 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.Example
{
    using System;
    using System.Threading.Tasks;

    using Blorc.Example.Shared;
    using Blorc.Services;

    public class SurveyVisualizationService : IUIVisualizationService
    {
        private readonly SurveyPrompt _survey;

        public SurveyVisualizationService(SurveyPrompt survey)
        {
            _survey = survey;
        }

        public Task CloseAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task ShowAsync()
        {
            Console.WriteLine("Calling [ShowAsync] at [SurveyVisualizationService]");
            Console.WriteLine("===================================================");
            Console.WriteLine("'_survey' field is null => " + (_survey is null));
        }

        public Task UpdateAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
