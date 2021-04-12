using Abp.Configuration;
using Abp.Net.Mail;
using Abp.Net.Mail.Smtp;
using Abp.Runtime.Security;

namespace NewName.NewAbpZeroTemplate.Net.Emailing
{
    public class NewAbpZeroTemplateSmtpEmailSenderConfiguration : SmtpEmailSenderConfiguration
    {
        public NewAbpZeroTemplateSmtpEmailSenderConfiguration(ISettingManager settingManager) : base(settingManager)
        {

        }

        public override string Password => SimpleStringCipher.Instance.Decrypt(GetNotEmptySettingValue(EmailSettingNames.Smtp.Password));
    }
}