using MyCompanyName.AbpZeroTemplate.TTTasksNameSpace;
using MyCompanyName.AbpZeroTemplate.TTTasksNameSpace;

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
    [AbpAuthorize(AppPermissions.Pages_Task_TaskTopics)]
    public class Task_TaskTopicsAppService : AbpZeroTemplateAppServiceBase, ITask_TaskTopicsAppService
    {
        private readonly IRepository<Task_TaskTopic> _task_TaskTopicRepository;
        private readonly ITask_TaskTopicsExcelExporter _task_TaskTopicsExcelExporter;
        private readonly IRepository<TTTask, int> _lookup_ttTaskRepository;
        private readonly IRepository<TaskTopic, int> _lookup_taskTopicRepository;

        public Task_TaskTopicsAppService(IRepository<Task_TaskTopic> task_TaskTopicRepository, ITask_TaskTopicsExcelExporter task_TaskTopicsExcelExporter, IRepository<TTTask, int> lookup_ttTaskRepository, IRepository<TaskTopic, int> lookup_taskTopicRepository)
        {
            _task_TaskTopicRepository = task_TaskTopicRepository;
            _task_TaskTopicsExcelExporter = task_TaskTopicsExcelExporter;
            _lookup_ttTaskRepository = lookup_ttTaskRepository;
            _lookup_taskTopicRepository = lookup_taskTopicRepository;

        }

        public async Task<PagedResultDto<GetTask_TaskTopicForViewDto>> GetAll(GetAllTask_TaskTopicsInput input)
        {

            var filteredTask_TaskTopics = _task_TaskTopicRepository.GetAll()
                        .Include(e => e.TTTaskFk)
                        .Include(e => e.TaskTopicFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TTTaskNameFilter), e => e.TTTaskFk != null && e.TTTaskFk.Name == input.TTTaskNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TaskTopicNameFilter), e => e.TaskTopicFk != null && e.TaskTopicFk.Name == input.TaskTopicNameFilter);

            var pagedAndFilteredTask_TaskTopics = filteredTask_TaskTopics
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var task_TaskTopics = from o in pagedAndFilteredTask_TaskTopics
                                  join o1 in _lookup_ttTaskRepository.GetAll() on o.TTTaskId equals o1.Id into j1
                                  from s1 in j1.DefaultIfEmpty()

                                  join o2 in _lookup_taskTopicRepository.GetAll() on o.TaskTopicId equals o2.Id into j2
                                  from s2 in j2.DefaultIfEmpty()

                                  select new
                                  {

                                      Id = o.Id,
                                      TTTaskName = s1 == null || s1.Name == null ? "" : s1.Name.ToString(),
                                      TaskTopicName = s2 == null || s2.Name == null ? "" : s2.Name.ToString()
                                  };

            var totalCount = await filteredTask_TaskTopics.CountAsync();

            var dbList = await task_TaskTopics.ToListAsync();
            var results = new List<GetTask_TaskTopicForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetTask_TaskTopicForViewDto()
                {
                    Task_TaskTopic = new Task_TaskTopicDto
                    {

                        Id = o.Id,
                    },
                    TTTaskName = o.TTTaskName,
                    TaskTopicName = o.TaskTopicName
                };

                results.Add(res);
            }

            return new PagedResultDto<GetTask_TaskTopicForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<GetTask_TaskTopicForViewDto> GetTask_TaskTopicForView(int id)
        {
            var task_TaskTopic = await _task_TaskTopicRepository.GetAsync(id);

            var output = new GetTask_TaskTopicForViewDto { Task_TaskTopic = ObjectMapper.Map<Task_TaskTopicDto>(task_TaskTopic) };

            if (output.Task_TaskTopic.TTTaskId != null)
            {
                var _lookupTTTask = await _lookup_ttTaskRepository.FirstOrDefaultAsync((int)output.Task_TaskTopic.TTTaskId);
                output.TTTaskName = _lookupTTTask?.Name?.ToString();
            }

            if (output.Task_TaskTopic.TaskTopicId != null)
            {
                var _lookupTaskTopic = await _lookup_taskTopicRepository.FirstOrDefaultAsync((int)output.Task_TaskTopic.TaskTopicId);
                output.TaskTopicName = _lookupTaskTopic?.Name?.ToString();
            }

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Task_TaskTopics_Edit)]
        public async Task<GetTask_TaskTopicForEditOutput> GetTask_TaskTopicForEdit(EntityDto input)
        {
            var task_TaskTopic = await _task_TaskTopicRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetTask_TaskTopicForEditOutput { Task_TaskTopic = ObjectMapper.Map<CreateOrEditTask_TaskTopicDto>(task_TaskTopic) };

            if (output.Task_TaskTopic.TTTaskId != null)
            {
                var _lookupTTTask = await _lookup_ttTaskRepository.FirstOrDefaultAsync((int)output.Task_TaskTopic.TTTaskId);
                output.TTTaskName = _lookupTTTask?.Name?.ToString();
            }

            if (output.Task_TaskTopic.TaskTopicId != null)
            {
                var _lookupTaskTopic = await _lookup_taskTopicRepository.FirstOrDefaultAsync((int)output.Task_TaskTopic.TaskTopicId);
                output.TaskTopicName = _lookupTaskTopic?.Name?.ToString();
            }

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditTask_TaskTopicDto input)
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

        [AbpAuthorize(AppPermissions.Pages_Task_TaskTopics_Create)]
        protected virtual async Task Create(CreateOrEditTask_TaskTopicDto input)
        {
            var task_TaskTopic = ObjectMapper.Map<Task_TaskTopic>(input);

            if (AbpSession.TenantId != null)
            {
                task_TaskTopic.TenantId = (int?)AbpSession.TenantId;
            }

            await _task_TaskTopicRepository.InsertAsync(task_TaskTopic);

        }

        [AbpAuthorize(AppPermissions.Pages_Task_TaskTopics_Edit)]
        protected virtual async Task Update(CreateOrEditTask_TaskTopicDto input)
        {
            var task_TaskTopic = await _task_TaskTopicRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, task_TaskTopic);

        }

        [AbpAuthorize(AppPermissions.Pages_Task_TaskTopics_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _task_TaskTopicRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetTask_TaskTopicsToExcel(GetAllTask_TaskTopicsForExcelInput input)
        {

            var filteredTask_TaskTopics = _task_TaskTopicRepository.GetAll()
                        .Include(e => e.TTTaskFk)
                        .Include(e => e.TaskTopicFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TTTaskNameFilter), e => e.TTTaskFk != null && e.TTTaskFk.Name == input.TTTaskNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TaskTopicNameFilter), e => e.TaskTopicFk != null && e.TaskTopicFk.Name == input.TaskTopicNameFilter);

            var query = (from o in filteredTask_TaskTopics
                         join o1 in _lookup_ttTaskRepository.GetAll() on o.TTTaskId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()

                         join o2 in _lookup_taskTopicRepository.GetAll() on o.TaskTopicId equals o2.Id into j2
                         from s2 in j2.DefaultIfEmpty()

                         select new GetTask_TaskTopicForViewDto()
                         {
                             Task_TaskTopic = new Task_TaskTopicDto
                             {
                                 Id = o.Id
                             },
                             TTTaskName = s1 == null || s1.Name == null ? "" : s1.Name.ToString(),
                             TaskTopicName = s2 == null || s2.Name == null ? "" : s2.Name.ToString()
                         });

            var task_TaskTopicListDtos = await query.ToListAsync();

            return _task_TaskTopicsExcelExporter.ExportToFile(task_TaskTopicListDtos);
        }

        [AbpAuthorize(AppPermissions.Pages_Task_TaskTopics)]
        public async Task<PagedResultDto<Task_TaskTopicTTTaskLookupTableDto>> GetAllTTTaskForLookupTable(GetAllForLookupTableInput input)
        {
            var query = _lookup_ttTaskRepository.GetAll().WhereIf(
                   !string.IsNullOrWhiteSpace(input.Filter),
                  e => e.Name != null && e.Name.Contains(input.Filter)
               );

            var totalCount = await query.CountAsync();

            var ttTaskList = await query
                .PageBy(input)
                .ToListAsync();

            var lookupTableDtoList = new List<Task_TaskTopicTTTaskLookupTableDto>();
            foreach (var ttTask in ttTaskList)
            {
                lookupTableDtoList.Add(new Task_TaskTopicTTTaskLookupTableDto
                {
                    Id = ttTask.Id,
                    DisplayName = ttTask.Name?.ToString()
                });
            }

            return new PagedResultDto<Task_TaskTopicTTTaskLookupTableDto>(
                totalCount,
                lookupTableDtoList
            );
        }

        [AbpAuthorize(AppPermissions.Pages_Task_TaskTopics)]
        public async Task<PagedResultDto<Task_TaskTopicTaskTopicLookupTableDto>> GetAllTaskTopicForLookupTable(GetAllForLookupTableInput input)
        {
            var query = _lookup_taskTopicRepository.GetAll().WhereIf(
                   !string.IsNullOrWhiteSpace(input.Filter),
                  e => e.Name != null && e.Name.Contains(input.Filter)
               );

            var totalCount = await query.CountAsync();

            var taskTopicList = await query
                .PageBy(input)
                .ToListAsync();

            var lookupTableDtoList = new List<Task_TaskTopicTaskTopicLookupTableDto>();
            foreach (var taskTopic in taskTopicList)
            {
                lookupTableDtoList.Add(new Task_TaskTopicTaskTopicLookupTableDto
                {
                    Id = taskTopic.Id,
                    DisplayName = taskTopic.Name?.ToString()
                });
            }

            return new PagedResultDto<Task_TaskTopicTaskTopicLookupTableDto>(
                totalCount,
                lookupTableDtoList
            );
        }

    }
}