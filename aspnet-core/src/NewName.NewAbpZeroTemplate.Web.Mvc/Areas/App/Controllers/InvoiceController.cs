using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using NewName.NewAbpZeroTemplate.MultiTenancy.Accounting;
using NewName.NewAbpZeroTemplate.Web.Areas.App.Models.Accounting;
using NewName.NewAbpZeroTemplate.Web.Controllers;

namespace NewName.NewAbpZeroTemplate.Web.Areas.App.Controllers
{
    [Area("App")]
    public class InvoiceController : NewAbpZeroTemplateControllerBase
    {
        private readonly IInvoiceAppService _invoiceAppService;

        public InvoiceController(IInvoiceAppService invoiceAppService)
        {
            _invoiceAppService = invoiceAppService;
        }


        [HttpGet]
        public async Task<ActionResult> Index(long paymentId)
        {
            var invoice = await _invoiceAppService.GetInvoiceInfo(new EntityDto<long>(paymentId));
            var model = new InvoiceViewModel
            {
                Invoice = invoice
            };

            return View(model);
        }
    }
}