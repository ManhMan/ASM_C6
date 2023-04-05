using _3.Admin.IServices;
using Microsoft.AspNetCore.Components;
using _3.Admin.Confirm;
using _1.Data.Model;

namespace _3.Admin.Pages.PageNSX
{
	public partial class NSXView
	{
		[Inject] public IAllServices _service { get; set; }
		[Inject] public NavigationManager navigation { get; set; }
        [Parameter]
        public string ID { get; set; }
        protected Confirmation confirmation { get; set; }
		public List<NSX> lstNSX;
		private Guid IdNSX { get; set; }
		private string searchInput;
		
		protected override async Task OnInitializedAsync()
		{
			lstNSX = await _service.GetAll<NSX>("https://localhost:7111/api/NSX/Get-All");
		}

		private void Search(ChangeEventArgs e)
		{
			searchInput = Convert.ToString(e.Value);
            lstNSX = lstNSX.Where(p => p.TenNSX.ToLower().Contains(searchInput.ToLower())).ToList();
			if (!string.IsNullOrEmpty(searchInput))
			{
				if (lstNSX.Count == 0)
				{
                    lstNSX = lstNSX;
				}
                lstNSX = lstNSX.Where(p => p.TenNSX.ToLower().Contains(searchInput.ToLower())).ToList();
			}
            lstNSX = lstNSX;

		}
		private async Task Reset()
		{
			lstNSX = await _service.GetAll<NSX>("https://localhost:7111/api/NSX/Get-All");

		}

		public void Delete(Guid id)
		{
			IdNSX = id;
			confirmation.Show();
		}

		private async Task OnConfirmDelete(bool confirm)
		{
			if (confirm)
			{
			await _service.Remove<NSX>("https://localhost:7111/api/NSX/GetById/",
			"https://localhost:7111/api/NSX/Delete/", IdNSX);

			lstNSX = await _service.GetAll<NSX>("https://localhost:7111/api/NSX/Get-All");
			}
		}
	}
}
