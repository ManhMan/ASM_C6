using _2.API.ViewModels.NSX;
using _3.Admin.IServices;
using Microsoft.AspNetCore.Components;

namespace _3.Admin.Pages.PageNSX
{
    public partial class NSXCreate
    {
        private CreateNSX create = new CreateNSX();
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IAllServices services { get; set; }
        private async Task Create()
        {
            await services.Add<CreateNSX>("https://localhost:7111/api/NSX/Create", create);
            var url = Path.Combine("/NSXView");
            NavigationManager.NavigateTo(url);
        }

        private async Task ClearForm()
        {
            create.TenNSX = null;
           
        }
    }
}
