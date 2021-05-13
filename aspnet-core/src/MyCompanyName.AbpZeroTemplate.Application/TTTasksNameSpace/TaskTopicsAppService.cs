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
    [AbpAuthorize(AppPermissions.Pages_TaskTopics)]
    public class TaskTopicsAppService : AbpZeroTemplateAppServiceBase, ITaskTopicsAppService
    {
        private readonly IRepository<TaskTopic> _taskTopicRepository;
        private readonly ITaskTopicsExcelExporter _taskTopicsExcelExporter;

        public TaskTopicsAppService(IRepository<TaskTopic> taskTopicRepository, ITaskTopicsExcelExporter taskTopicsExcelExporter)
        {
            _taskTopicRepository = taskTopicRepository;
            _taskTopicsExcelExporter = taskTopicsExcelExporter;

        }

        public async Task<PagedResultDto<GetTaskTopicForViewDto>> GetAll(GetAllTaskTopicsInput input)
        {

            var filteredTaskTopics = _taskTopicRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter);

            var pagedAndFilteredTaskTopics = filteredTaskTopics
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var taskTopics = from o in pagedAndFilteredTaskTopics
                             select new
                             {

                                 o.Name,
                                 Id = o.Id
                             };

            var totalCount = await filteredTaskTopics.CountAsync();

            var dbList = await taskTopics.ToListAsync();
            var results = new List<GetTaskTopicForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetTaskTopicForViewDto()
                {
                    TaskTopic = new TaskTopicDto
                    {

                        Name = o.Name,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetTaskTopicForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<GetTaskTopicForViewDto> GetTaskTopicForView(int id)
        {
            var taskTopic = await _taskTopicRepository.GetAsync(id);

            var output = new GetTaskTopicForViewDto { TaskTopic = ObjectMapper.Map<TaskTopicDto>(taskTopic) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_TaskTopics_Edit)]
        public async Task<GetTaskTopicForEditOutput> GetTaskTopicForEdit(EntityDto input)
        {
            var taskTopic = await _taskTopicRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetTaskTopicForEditOutput { TaskTopic = ObjectMapper.Map<CreateOrEditTaskTopicDto>(taskTopic) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditTaskTopicDto input)
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

        [AbpAuthorize(AppPermissions.Pages_TaskTopics_Create)]
        protected virtual async Task Create(CreateOrEditTaskTopicDto input)
        {
            var taskTopic = ObjectMapper.Map<TaskTopic>(input);

            if (AbpSession.TenantId != null)
            {
                taskTopic.TenantId = (int?)AbpSession.TenantId;
            }

            await _taskTopicRepository.InsertAsync(taskTopic);

        }

        [AbpAuthorize(AppPermissions.Pages_TaskTopics_Edit)]
        protected virtual async Task Update(CreateOrEditTaskTopicDto input)
        {
            var taskTopic = await _taskTopicRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, taskTopic);

        }

        [AbpAuthorize(AppPermissions.Pages_TaskTopics_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _taskTopicRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetTaskTopicsToExcel(GetAllTaskTopicsForExcelInput input)
        {

            var filteredTaskTopics = _taskTopicRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter);

            var query = (from o in filteredTaskTopics
                         select new GetTaskTopicForViewDto()
                         {
                             TaskTopic = new TaskTopicDto
                             {
                                 Name = o.Name,
                                 Id = o.Id
                             }
                         });

            var taskTopicListDtos = await query.ToListAsync();

            return _taskTopicsExcelExporter.ExportToFile(taskTopicListDtos);
        }

    }
}