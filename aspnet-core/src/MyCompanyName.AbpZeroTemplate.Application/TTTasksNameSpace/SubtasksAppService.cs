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
    [AbpAuthorize(AppPermissions.Pages_Subtasks)]
    public class SubtasksAppService : AbpZeroTemplateAppServiceBase, ISubtasksAppService
    {
        private readonly IRepository<Subtask> _subtaskRepository;
        private readonly ISubtasksExcelExporter _subtasksExcelExporter;

        public SubtasksAppService(IRepository<Subtask> subtaskRepository, ISubtasksExcelExporter subtasksExcelExporter)
        {
            _subtaskRepository = subtaskRepository;
            _subtasksExcelExporter = subtasksExcelExporter;

        }

        public async Task<PagedResultDto<GetSubtaskForViewDto>> GetAll(GetAllSubtasksInput input)
        {

            var filteredSubtasks = _subtaskRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter);

            var pagedAndFilteredSubtasks = filteredSubtasks
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var subtasks = from o in pagedAndFilteredSubtasks
                           select new
                           {

                               o.Description,
                               Id = o.Id
                           };

            var totalCount = await filteredSubtasks.CountAsync();

            var dbList = await subtasks.ToListAsync();
            var results = new List<GetSubtaskForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetSubtaskForViewDto()
                {
                    Subtask = new SubtaskDto
                    {

                        Description = o.Description,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetSubtaskForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<GetSubtaskForViewDto> GetSubtaskForView(int id)
        {
            var subtask = await _subtaskRepository.GetAsync(id);

            var output = new GetSubtaskForViewDto { Subtask = ObjectMapper.Map<SubtaskDto>(subtask) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Subtasks_Edit)]
        public async Task<GetSubtaskForEditOutput> GetSubtaskForEdit(EntityDto input)
        {
            var subtask = await _subtaskRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetSubtaskForEditOutput { Subtask = ObjectMapper.Map<CreateOrEditSubtaskDto>(subtask) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditSubtaskDto input)
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

        [AbpAuthorize(AppPermissions.Pages_Subtasks_Create)]
        protected virtual async Task Create(CreateOrEditSubtaskDto input)
        {
            var subtask = ObjectMapper.Map<Subtask>(input);

            if (AbpSession.TenantId != null)
            {
                subtask.TenantId = (int?)AbpSession.TenantId;
            }

            await _subtaskRepository.InsertAsync(subtask);

        }

        [AbpAuthorize(AppPermissions.Pages_Subtasks_Edit)]
        protected virtual async Task Update(CreateOrEditSubtaskDto input)
        {
            var subtask = await _subtaskRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, subtask);

        }

        [AbpAuthorize(AppPermissions.Pages_Subtasks_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _subtaskRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetSubtasksToExcel(GetAllSubtasksForExcelInput input)
        {

            var filteredSubtasks = _subtaskRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter);

            var query = (from o in filteredSubtasks
                         select new GetSubtaskForViewDto()
                         {
                             Subtask = new SubtaskDto
                             {
                                 Description = o.Description,
                                 Id = o.Id
                             }
                         });

            var subtaskListDtos = await query.ToListAsync();

            return _subtasksExcelExporter.ExportToFile(subtaskListDtos);
        }

    }
}