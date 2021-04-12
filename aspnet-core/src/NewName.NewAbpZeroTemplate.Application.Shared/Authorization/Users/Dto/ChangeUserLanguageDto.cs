using System.ComponentModel.DataAnnotations;

namespace NewName.NewAbpZeroTemplate.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
