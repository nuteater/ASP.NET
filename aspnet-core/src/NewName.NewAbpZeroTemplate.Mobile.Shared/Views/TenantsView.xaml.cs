using NewName.NewAbpZeroTemplate.Models.Tenants;
using NewName.NewAbpZeroTemplate.ViewModels;
using Xamarin.Forms;

namespace NewName.NewAbpZeroTemplate.Views
{
    public partial class TenantsView : ContentPage, IXamarinView
    {
        public TenantsView()
        {
            InitializeComponent();
        }

        private async void ListView_OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            await ((TenantsViewModel)BindingContext).LoadMoreTenantsIfNeedsAsync(e.Item as TenantListModel);
        }
    }
}