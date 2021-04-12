using System.Collections.Generic;
using Abp.Application.Services.Dto;
using NewName.NewAbpZeroTemplate.Editions.Dto;

namespace NewName.NewAbpZeroTemplate.MultiTenancy.Dto
{
    public class GetTenantFeaturesEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}