using System.Threading.Tasks;
using NewName.NewAbpZeroTemplate.Security.Recaptcha;

namespace NewName.NewAbpZeroTemplate.Test.Base.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}
