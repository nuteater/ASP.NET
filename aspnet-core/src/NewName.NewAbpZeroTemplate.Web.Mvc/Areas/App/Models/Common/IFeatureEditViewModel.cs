using System.Collections.Generic;
using Abp.Application.Services.Dto;
using NewName.NewAbpZeroTemplate.Editions.Dto;

namespace NewName.NewAbpZeroTemplate.Web.Areas.App.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}