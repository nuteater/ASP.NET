using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewName.NewAbpZeroTemplate.MultiTenancy.HostDashboard.Dto;

namespace NewName.NewAbpZeroTemplate.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}