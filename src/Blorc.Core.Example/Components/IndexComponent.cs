namespace Blorc.Example.Components
{
    using System.Threading.Tasks;

    using Blorc.Components;
    using Blorc.Services;

    public class IndexComponent : BlorcComponentBase
    {
        protected IExecutionService SurveyExcutionService { get; set; }

        protected IUIVisualizationService SurveyVisualizationService { get; set; }

        public IndexComponent()
            :base(true)
        {
        }

        protected async Task OnButtonClick()
        {
            if (SurveyExcutionService != null)
            {
                await SurveyExcutionService.ExecuteAsync();
            }

            if (SurveyVisualizationService != null)
            {
                await SurveyVisualizationService.ShowAsync();
            }
        }
    }
}
