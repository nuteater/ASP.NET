﻿using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NewName.NewAbpZeroTemplate.TasksNamespace.Dtos;
using NewName.NewAbpZeroTemplate.Dto;


namespace NewName.NewAbpZeroTemplate.TasksNamespace
{
    public interface ITasks_UsersAppService : IApplicationService 
    {
        Task<PagedResultDto<GetTasks_UserForViewDto>> GetAll(GetAllTasks_UsersInput input);

        Task<GetTasks_UserForViewDto> GetTasks_UserForView(int id);

		Task<GetTasks_UserForEditOutput> GetTasks_UserForEdit(EntityDto input);

		Task CreateOrEdit(CreateOrEditTasks_UserDto input);

		Task Delete(EntityDto input);

		
		Task<PagedResultDto<Tasks_UserUserLookupTableDto>> GetAllUserForLookupTable(GetAllForLookupTableInput input);
		
		Task<PagedResultDto<Tasks_UserTTTaskLookupTableDto>> GetAllTTTaskForLookupTable(GetAllForLookupTableInput input);
		
    }
}