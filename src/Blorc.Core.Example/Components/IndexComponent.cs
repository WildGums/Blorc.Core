namespace Blorc.Example.Components
{
    using System.Threading.Tasks;

    using Blorc.Components;
    using Blorc.Services;

    public class IndexComponent : BlorcComponentBase
    {
        public IExecutionService SurveyExecutionService { get; set; }

        public IUIVisualizationService SurveyVisualizationService { get; set; }

        public IndexComponent()
            :base(true)
        {
        }

        protected async Task OnButtonClick()
        {
            if (SurveyExecutionService != null)
            {
                await SurveyExecutionService.ExecuteAsync();
            }

            if (SurveyVisualizationService != null)
            {
                await SurveyVisualizationService.ShowAsync();
            }
        }
    }
}
