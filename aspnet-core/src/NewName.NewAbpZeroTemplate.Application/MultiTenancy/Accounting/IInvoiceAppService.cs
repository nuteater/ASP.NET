using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using NewName.NewAbpZeroTemplate.MultiTenancy.Accounting.Dto;

namespace NewName.NewAbpZeroTemplate.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
