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
    [AbpAuthorize(AppPermissions.Pages_TaskPriorities)]
    public class TaskPrioritiesAppService : AbpZeroTemplateAppServiceBase, ITaskPrioritiesAppService
    {
        private readonly IRepository<TaskPriority> _taskPriorityRepository;
        private readonly ITaskPrioritiesExcelExporter _taskPrioritiesExcelExporter;

        public TaskPrioritiesAppService(IRepository<TaskPriority> taskPriorityRepository, ITaskPrioritiesExcelExporter taskPrioritiesExcelExporter)
        {
            _taskPriorityRepository = taskPriorityRepository;
            _taskPrioritiesExcelExporter = taskPrioritiesExcelExporter;

        }

        public async Task<PagedResultDto<GetTaskPriorityForViewDto>> GetAll(GetAllTaskPrioritiesInput input)
        {

            var filteredTaskPriorities = _taskPriorityRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter);

            var pagedAndFilteredTaskPriorities = filteredTaskPriorities
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var taskPriorities = from o in pagedAndFilteredTaskPriorities
                                 select new
                                 {

                                     o.Name,
                                     Id = o.Id
                                 };

            var totalCount = await filteredTaskPriorities.CountAsync();

            var dbList = await taskPriorities.ToListAsync();
            var results = new List<GetTaskPriorityForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetTaskPriorityForViewDto()
                {
                    TaskPriority = new TaskPriorityDto
                    {

                        Name = o.Name,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetTaskPriorityForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<GetTaskPriorityForViewDto> GetTaskPriorityForView(int id)
        {
            var taskPriority = await _taskPriorityRepository.GetAsync(id);

            var output = new GetTaskPriorityForViewDto { TaskPriority = ObjectMapper.Map<TaskPriorityDto>(taskPriority) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_TaskPriorities_Edit)]
        public async Task<GetTaskPriorityForEditOutput> GetTaskPriorityForEdit(EntityDto input)
        {
            var taskPriority = await _taskPriorityRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetTaskPriorityForEditOutput { TaskPriority = ObjectMapper.Map<CreateOrEditTaskPriorityDto>(taskPriority) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditTaskPriorityDto input)
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

        [AbpAuthorize(AppPermissions.Pages_TaskPriorities_Create)]
        protected virtual async Task Create(CreateOrEditTaskPriorityDto input)
        {
            var taskPriority = ObjectMapper.Map<TaskPriority>(input);

            if (AbpSession.TenantId != null)
            {
                taskPriority.TenantId = (int?)AbpSession.TenantId;
            }

            await _taskPriorityRepository.InsertAsync(taskPriority);

        }

        [AbpAuthorize(AppPermissions.Pages_TaskPriorities_Edit)]
        protected virtual async Task Update(CreateOrEditTaskPriorityDto input)
        {
            var taskPriority = await _taskPriorityRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, taskPriority);

        }

        [AbpAuthorize(AppPermissions.Pages_TaskPriorities_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _taskPriorityRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetTaskPrioritiesToExcel(GetAllTaskPrioritiesForExcelInput input)
        {

            var filteredTaskPriorities = _taskPriorityRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter);

            var query = (from o in filteredTaskPriorities
                         select new GetTaskPriorityForViewDto()
                         {
                             TaskPriority = new TaskPriorityDto
                             {
                                 Name = o.Name,
                                 Id = o.Id
                             }
                         });

            var taskPriorityListDtos = await query.ToListAsync();

            return _taskPrioritiesExcelExporter.ExportToFile(taskPriorityListDtos);
        }

    }
}