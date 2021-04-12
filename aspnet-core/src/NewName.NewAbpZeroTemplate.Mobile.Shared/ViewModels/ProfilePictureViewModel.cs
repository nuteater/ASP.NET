using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using NewName.NewAbpZeroTemplate.Core.Threading;
using NewName.NewAbpZeroTemplate.ViewModels.Base;
using Xamarin.Forms;

namespace NewName.NewAbpZeroTemplate.ViewModels
{
    public class ProfilePictureViewModel : XamarinViewModel
    {
        public ICommand CloseCommand => AsyncCommand.Create(ModalService.CloseModalAsync);

        private ImageSource _photo;

        public ImageSource Photo
        {
            get => _photo;
            set
            {
                _photo = value;
                RaisePropertyChanged(() => Photo);
            }
        }

        public override Task InitializeAsync(object navigationData)
        {
            var profilePictureBytes = (byte[])navigationData;
            Photo = ImageSource.FromStream(() => new MemoryStream(profilePictureBytes));
            return Task.CompletedTask;
        }
    }
}
