using Abp.Domain.Services;

namespace NewName.NewAbpZeroTemplate
{
    public abstract class NewAbpZeroTemplateDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected NewAbpZeroTemplateDomainServiceBase()
        {
            LocalizationSourceName = NewAbpZeroTemplateConsts.LocalizationSourceName;
        }
    }
}
