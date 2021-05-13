using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Exporting;
using MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos;
using MyCompanyName.AbpZeroTemplate.Dto;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using MyCompanyName.AbpZeroTemplate.Storage;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace
{
    [AbpAuthorize(AppPermissions.Pages_TaskHistories)]
    public class TaskHistoriesAppService : AbpZeroTemplateAppServiceBase, ITaskHistoriesAppService
    {
        private readonly IRepository<TaskHistory> _taskHistoryRepository;
        private readonly ITaskHistoriesExcelExporter _taskHistoriesExcelExporter;

        public TaskHistoriesAppService(IRepository<TaskHistory> taskHistoryRepository, ITaskHistoriesExcelExporter taskHistoriesExcelExporter)
        {
            _taskHistoryRepository = taskHistoryRepository;
            _taskHistoriesExcelExporter = taskHistoriesExcelExporter;

        }

        public async Task<PagedResultDto<GetTaskHistoryForViewDto>> GetAll(GetAllTaskHistoriesInput input)
        {

            var filteredTaskHistories = _taskHistoryRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter);

            var pagedAndFilteredTaskHistories = filteredTaskHistories
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var taskHistories = from o in pagedAndFilteredTaskHistories
                                select new
                                {

                                    o.Description,
                                    Id = o.Id
                                };

            var totalCount = await filteredTaskHistories.CountAsync();

            var dbList = await taskHistories.ToListAsync();
            var results = new List<GetTaskHistoryForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetTaskHistoryForViewDto()
                {
                    TaskHistory = new TaskHistoryDto
                    {

                        Description = o.Description,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetTaskHistoryForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<GetTaskHistoryForViewDto> GetTaskHistoryForView(int id)
        {
            var taskHistory = await _taskHistoryRepository.GetAsync(id);

            var output = new GetTaskHistoryForViewDto { TaskHistory = ObjectMapper.Map<TaskHistoryDto>(taskHistory) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_TaskHistories_Edit)]
        public async Task<GetTaskHistoryForEditOutput> GetTaskHistoryForEdit(EntityDto input)
        {
            var taskHistory = await _taskHistoryRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetTaskHistoryForEditOutput { TaskHistory = ObjectMapper.Map<CreateOrEditTaskHistoryDto>(taskHistory) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditTaskHistoryDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        [AbpAuthorize(AppPermissions.Pages_TaskHistories_Create)]
        protected virtual async Task Create(CreateOrEditTaskHistoryDto input)
        {
            var taskHistory = ObjectMapper.Map<TaskHistory>(input);

            if (AbpSession.TenantId != null)
            {
                taskHistory.TenantId = (int?)AbpSession.TenantId;
            }

            await _taskHistoryRepository.InsertAsync(taskHistory);

        }

        [AbpAuthorize(AppPermissions.Pages_TaskHistories_Edit)]
        protected virtual async Task Update(CreateOrEditTaskHistoryDto input)
        {
            var taskHistory = await _taskHistoryRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, taskHistory);

        }

        [AbpAuthorize(AppPermissions.Pages_TaskHistories_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _taskHistoryRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetTaskHistoriesToExcel(GetAllTaskHistoriesForExcelInput input)
        {

            var filteredTaskHistories = _taskHistoryRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter);

            var query = (from o in filteredTaskHistories
                         select new GetTaskHistoryForViewDto()
                         {
                             TaskHistory = new TaskHistoryDto
                             {
                                 Description = o.Description,
                                 Id = o.Id
                             }
                         });

            var taskHistoryListDtos = await query.ToListAsync();

            return _taskHistoriesExcelExporter.ExportToFile(taskHistoryListDtos);
        }

    }
}