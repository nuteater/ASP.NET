using System.Threading.Tasks;

namespace NewName.NewAbpZeroTemplate.Security.Recaptcha
{
    public interface IRecaptchaValidator
    {
        Task ValidateAsync(string captchaResponse);
    }
}