using System;
using Abp.AutoMapper;
using NewName.NewAbpZeroTemplate.Sessions.Dto;

namespace NewName.NewAbpZeroTemplate.Models.Common
{
    [AutoMapFrom(typeof(ApplicationInfoDto)),
     AutoMapTo(typeof(ApplicationInfoDto))]
    public class ApplicationInfoPersistanceModel
    {
        public string Version { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}