using System.ComponentModel.DataAnnotations;

namespace NewName.NewAbpZeroTemplate.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}