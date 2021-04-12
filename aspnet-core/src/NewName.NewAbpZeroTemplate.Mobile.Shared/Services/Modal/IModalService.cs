using System.Threading.Tasks;
using NewName.NewAbpZeroTemplate.Views;
using Xamarin.Forms;

namespace NewName.NewAbpZeroTemplate.Services.Modal
{
    public interface IModalService
    {
        Task ShowModalAsync(Page page);

        Task ShowModalAsync<TView>(object navigationParameter) where TView : IXamarinView;

        Task<Page> CloseModalAsync();
    }
}
