

using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using NewName.NewAbpZeroTemplate.TasksNamespace.Dtos;
using NewName.NewAbpZeroTemplate.Dto;
using Abp.Application.Services.Dto;
using NewName.NewAbpZeroTemplate.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;

namespace NewName.NewAbpZeroTemplate.TasksNamespace
{
	[AbpAuthorize(AppPermissions.Pages_Subtaskses)]
    public class SubtasksesAppService : NewAbpZeroTemplateAppServiceBase, ISubtasksesAppService
    {
		 private readonly IRepository<Subtasks> _subtasksRepository;
		 

		  public SubtasksesAppService(IRepository<Subtasks> subtasksRepository ) 
		  {
			_subtasksRepository = subtasksRepository;
			
		  }

		 public async Task<PagedResultDto<GetSubtasksForViewDto>> GetAll(GetAllSubtasksesInput input)
         {
			
			var filteredSubtaskses = _subtasksRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.Description.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter),  e => e.Description == input.DescriptionFilter);

			var pagedAndFilteredSubtaskses = filteredSubtaskses
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

			var subtaskses = from o in pagedAndFilteredSubtaskses
                         select new GetSubtasksForViewDto() {
							Subtasks = new SubtasksDto
							{
                                Description = o.Description,
                                Id = o.Id
							}
						};

            var totalCount = await filteredSubtaskses.CountAsync();

            return new PagedResultDto<GetSubtasksForViewDto>(
                totalCount,
                await subtaskses.ToListAsync()
            );
         }
		 
		 public async Task<GetSubtasksForViewDto> GetSubtasksForView(int id)
         {
            var subtasks = await _subtasksRepository.GetAsync(id);

            var output = new GetSubtasksForViewDto { Subtasks = ObjectMapper.Map<SubtasksDto>(subtasks) };
			
            return output;
         }
		 
		 [AbpAuthorize(AppPermissions.Pages_Subtaskses_Edit)]
		 public async Task<GetSubtasksForEditOutput> GetSubtasksForEdit(EntityDto input)
         {
            var subtasks = await _subtasksRepository.FirstOrDefaultAsync(input.Id);
           
		    var output = new GetSubtasksForEditOutput {Subtasks = ObjectMapper.Map<CreateOrEditSubtasksDto>(subtasks)};
			
            return output;
         }

		 public async Task CreateOrEdit(CreateOrEditSubtasksDto input)
         {
            if(input.Id == null){
				await Create(input);
			}
			else{
				await Update(input);
			}
         }

		 [AbpAuthorize(AppPermissions.Pages_Subtaskses_Create)]
		 protected virtual async Task Create(CreateOrEditSubtasksDto input)
         {
            var subtasks = ObjectMapper.Map<Subtasks>(input);

			
			if (AbpSession.TenantId != null)
			{
				subtasks.TenantId = (int?) AbpSession.TenantId;
			}
		

            await _subtasksRepository.InsertAsync(subtasks);
         }

		 [AbpAuthorize(AppPermissions.Pages_Subtaskses_Edit)]
		 protected virtual async Task Update(CreateOrEditSubtasksDto input)
         {
            var subtasks = await _subtasksRepository.FirstOrDefaultAsync((int)input.Id);
             ObjectMapper.Map(input, subtasks);
         }

		 [AbpAuthorize(AppPermissions.Pages_Subtaskses_Delete)]
         public async Task Delete(EntityDto input)
         {
            await _subtasksRepository.DeleteAsync(input.Id);
         } 
    }
}