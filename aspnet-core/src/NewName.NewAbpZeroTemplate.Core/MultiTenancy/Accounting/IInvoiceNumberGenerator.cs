using System.Threading.Tasks;
using Abp.Dependency;

namespace NewName.NewAbpZeroTemplate.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}