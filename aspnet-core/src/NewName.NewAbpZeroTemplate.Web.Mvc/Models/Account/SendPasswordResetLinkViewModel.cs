using System.ComponentModel.DataAnnotations;

namespace NewName.NewAbpZeroTemplate.Web.Models.Account
{
    public class SendPasswordResetLinkViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}