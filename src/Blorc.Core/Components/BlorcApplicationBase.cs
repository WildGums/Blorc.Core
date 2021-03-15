namespace Blorc.Components
{
    using System;
    using System.Threading.Tasks;

    using Blorc.Services;

    using Microsoft.AspNetCore.Components;

    /// <summary>
    ///     The blorc application.
    /// </summary>
    [Obsolete("This class will be removed")]
    public class BlorcApplicationBase : BlorcComponentBase
    {
        /// <summary>
        /// Gets a value indicating whether initialized.
        /// </summary>
        protected bool Initialized { get; private set; }

        /// <summary>
        ///     Gets or sets the document service.
        /// </summary>
        [Inject]
        private IDocumentService DocumentService { get; set; }

        /// <summary>
        ///     The on configure document.
        /// </summary>
        /// <param name="documentService">
        ///     The document service.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        protected virtual Task OnConfiguringDocumentAsync(IDocumentService documentService)
        {
            return Task.CompletedTask;
        }

        protected override async Task OnInitializedAsync()
        {
            await DocumentService.InjectBlorcCoreJsAsync();
            await OnConfiguringDocumentAsync(DocumentService);

            await base.OnInitializedAsync();
            
            Initialized = true;
            
            StateHasChanged();
        }
    }
}
