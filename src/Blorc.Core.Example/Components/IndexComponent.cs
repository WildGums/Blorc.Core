namespace Blorc.Example.Components
{
    using System.Threading.Tasks;

    using Blorc.Components;
    using Blorc.Services;

    public class IndexComponent : BlorcComponentBase
    {
        protected IUIVisualizationService SurveyVisualizationService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            InjectComponentReferenceAsService = true;
        }

        protected async Task OnButtonClick()
        {
            if (SurveyVisualizationService != null)
            {
                await SurveyVisualizationService.ShowAsync();
            }
        }
    }
}
