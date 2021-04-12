using System.Threading.Tasks;

namespace NewName.NewAbpZeroTemplate.Net.Sms
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}