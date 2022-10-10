namespace Blorc.Example
{
    using System;
    using System.Threading.Tasks;

    using Blorc.Services;

    using Microsoft.AspNetCore.Components;

    public class SurveyExecutionService : IExecutionService
    {
        public ComponentBase? Component { get; set; }

        public async Task ExecuteAsync(object? state = null)
        {
            Console.WriteLine("Hello from ExecutionService!!!");
        }
    }
}
