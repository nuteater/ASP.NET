using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using MyCompanyName.AbpZeroTemplate.TTTasksNameSace.Exporting;
using MyCompanyName.AbpZeroTemplate.TTTasksNameSace.Dtos;
using MyCompanyName.AbpZeroTemplate.Dto;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using MyCompanyName.AbpZeroTemplate.Storage;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSace
{
    [AbpAuthorize(AppPermissions.Pages_TaskTypes)]
    public class TaskTypesAppService : AbpZeroTemplateAppServiceBase, ITaskTypesAppService
    {
        private readonly IRepository<TaskType> _taskTypeRepository;
        private readonly ITaskTypesExcelExporter _taskTypesExcelExporter;

        public TaskTypesAppService(IRepository<TaskType> taskTypeRepository, ITaskTypesExcelExporter taskTypesExcelExporter)
        {
            _taskTypeRepository = taskTypeRepository;
            _taskTypesExcelExporter = taskTypesExcelExporter;

        }

        public async Task<PagedResultDto<GetTaskTypeForViewDto>> GetAll(GetAllTaskTypesInput input)
        {

            var filteredTaskTypes = _taskTypeRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter);

            var pagedAndFilteredTaskTypes = filteredTaskTypes
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var taskTypes = from o in pagedAndFilteredTaskTypes
                            select new
                            {

                                o.Name,
                                Id = o.Id
                            };

            var totalCount = await filteredTaskTypes.CountAsync();

            var dbList = await taskTypes.ToListAsync();
            var results = new List<GetTaskTypeForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetTaskTypeForViewDto()
                {
                    TaskType = new TaskTypeDto
                    {

                        Name = o.Name,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetTaskTypeForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<GetTaskTypeForViewDto> GetTaskTypeForView(int id)
        {
            var taskType = await _taskTypeRepository.GetAsync(id);

            var output = new GetTaskTypeForViewDto { TaskType = ObjectMapper.Map<TaskTypeDto>(taskType) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_TaskTypes_Edit)]
        public async Task<GetTaskTypeForEditOutput> GetTaskTypeForEdit(EntityDto input)
        {
            var taskType = await _taskTypeRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetTaskTypeForEditOutput { TaskType = ObjectMapper.Map<CreateOrEditTaskTypeDto>(taskType) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditTaskTypeDto input)
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

        [AbpAuthorize(AppPermissions.Pages_TaskTypes_Create)]
        protected virtual async Task Create(CreateOrEditTaskTypeDto input)
        {
            var taskType = ObjectMapper.Map<TaskType>(input);

            if (AbpSession.TenantId != null)
            {
                taskType.TenantId = (int?)AbpSession.TenantId;
            }

            await _taskTypeRepository.InsertAsync(taskType);

        }

        [AbpAuthorize(AppPermissions.Pages_TaskTypes_Edit)]
        protected virtual async Task Update(CreateOrEditTaskTypeDto input)
        {
            var taskType = await _taskTypeRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, taskType);

        }

        [AbpAuthorize(AppPermissions.Pages_TaskTypes_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _taskTypeRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetTaskTypesToExcel(GetAllTaskTypesForExcelInput input)
        {

            var filteredTaskTypes = _taskTypeRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter);

            var query = (from o in filteredTaskTypes
                         select new GetTaskTypeForViewDto()
                         {
                             TaskType = new TaskTypeDto
                             {
                                 Name = o.Name,
                                 Id = o.Id
                             }
                         });

            var taskTypeListDtos = await query.ToListAsync();

            return _taskTypesExcelExporter.ExportToFile(taskTypeListDtos);
        }

    }
}