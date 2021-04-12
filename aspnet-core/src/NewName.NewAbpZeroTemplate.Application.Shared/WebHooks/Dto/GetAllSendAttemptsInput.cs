using NewName.NewAbpZeroTemplate.Dto;

namespace NewName.NewAbpZeroTemplate.WebHooks.Dto
{
    public class GetAllSendAttemptsInput : PagedInputDto
    {
        public string SubscriptionId { get; set; }
    }
}
