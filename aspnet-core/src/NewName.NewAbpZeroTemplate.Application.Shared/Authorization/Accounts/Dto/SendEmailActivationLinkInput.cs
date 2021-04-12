using System.ComponentModel.DataAnnotations;

namespace NewName.NewAbpZeroTemplate.Authorization.Accounts.Dto
{
    public class SendEmailActivationLinkInput
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}