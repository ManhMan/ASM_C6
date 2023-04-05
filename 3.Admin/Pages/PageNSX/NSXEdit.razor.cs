using _1.Data.Model;
using _2.API.ViewModels.GiamGia;
using _2.API.ViewModels.NSX;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using _3.Admin.IServices;

namespace _3.Admin.Pages.PageNSX
{
    public partial class NSXEdit
    {
        private UpdateNSX update = new UpdateNSX();
        [Inject] public IAllServices services { get; set; }
        [Inject] public NavigationManager navigation { get; set; }
        [Parameter]
        public string ID { get; set; }
        protected async override Task OnInitializedAsync()
        {
            var up = await services.GetById<NSX>("https://localhost:7111/api/NSX/GetById/", Guid.Parse(ID));

            update.TenNSX = up.TenNSX;

        }
        private async Task Update(EditContext editContext)
        {
            var result = await services.Update<UpdateNSX>("https://localhost:7111/api/NSX/Update/", update, Guid.Parse(ID));
            if (result != null)
            {
                navigation.NavigateTo("/NSXView");
            }

        }
    }
}
