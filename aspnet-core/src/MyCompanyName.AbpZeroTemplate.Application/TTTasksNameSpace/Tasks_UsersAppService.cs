using MyCompanyName.AbpZeroTemplate.TTTasksNameSpace;
using MyCompanyName.AbpZeroTemplate.Authorization.Users;

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
    [AbpAuthorize(AppPermissions.Pages_Tasks_Users)]
    public class Tasks_UsersAppService : AbpZeroTemplateAppServiceBase, ITasks_UsersAppService
    {
        private readonly IRepository<Tasks_User> _tasks_UserRepository;
        private readonly ITasks_UsersExcelExporter _tasks_UsersExcelExporter;
        private readonly IRepository<TTTask, int> _lookup_ttTaskRepository;
        private readonly IRepository<User, long> _lookup_userRepository;

        public Tasks_UsersAppService(IRepository<Tasks_User> tasks_UserRepository, ITasks_UsersExcelExporter tasks_UsersExcelExporter, IRepository<TTTask, int> lookup_ttTaskRepository, IRepository<User, long> lookup_userRepository)
        {
            _tasks_UserRepository = tasks_UserRepository;
            _tasks_UsersExcelExporter = tasks_UsersExcelExporter;
            _lookup_ttTaskRepository = lookup_ttTaskRepository;
            _lookup_userRepository = lookup_userRepository;

        }

        public async Task<PagedResultDto<GetTasks_UserForViewDto>> GetAll(GetAllTasks_UsersInput input)
        {

            var filteredTasks_Users = _tasks_UserRepository.GetAll()
                        .Include(e => e.TTTaskFk)
                        .Include(e => e.UserFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TTTaskNameFilter), e => e.TTTaskFk != null && e.TTTaskFk.Name == input.TTTaskNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.UserNameFilter), e => e.UserFk != null && e.UserFk.Name == input.UserNameFilter);

            var pagedAndFilteredTasks_Users = filteredTasks_Users
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var tasks_Users = from o in pagedAndFilteredTasks_Users
                              join o1 in _lookup_ttTaskRepository.GetAll() on o.TTTaskId equals o1.Id into j1
                              from s1 in j1.DefaultIfEmpty()

                              join o2 in _lookup_userRepository.GetAll() on o.UserId equals o2.Id into j2
                              from s2 in j2.DefaultIfEmpty()

                              select new
                              {

                                  Id = o.Id,
                                  TTTaskName = s1 == null || s1.Name == null ? "" : s1.Name.ToString(),
                                  UserName = s2 == null || s2.Name == null ? "" : s2.Name.ToString()
                              };

            var totalCount = await filteredTasks_Users.CountAsync();

            var dbList = await tasks_Users.ToListAsync();
            var results = new List<GetTasks_UserForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetTasks_UserForViewDto()
                {
                    Tasks_User = new Tasks_UserDto
                    {

                        Id = o.Id,
                    },
                    TTTaskName = o.TTTaskName,
                    UserName = o.UserName
                };

                results.Add(res);
            }

            return new PagedResultDto<GetTasks_UserForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<GetTasks_UserForViewDto> GetTasks_UserForView(int id)
        {
            var tasks_User = await _tasks_UserRepository.GetAsync(id);

            var output = new GetTasks_UserForViewDto { Tasks_User = ObjectMapper.Map<Tasks_UserDto>(tasks_User) };

            if (output.Tasks_User.TTTaskId != null)
            {
                var _lookupTTTask = await _lookup_ttTaskRepository.FirstOrDefaultAsync((int)output.Tasks_User.TTTaskId);
                output.TTTaskName = _lookupTTTask?.Name?.ToString();
            }

            if (output.Tasks_User.UserId != null)
            {
                var _lookupUser = await _lookup_userRepository.FirstOrDefaultAsync((long)output.Tasks_User.UserId);
                output.UserName = _lookupUser?.Name?.ToString();
            }

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Tasks_Users_Edit)]
        public async Task<GetTasks_UserForEditOutput> GetTasks_UserForEdit(EntityDto input)
        {
            var tasks_User = await _tasks_UserRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetTasks_UserForEditOutput { Tasks_User = ObjectMapper.Map<CreateOrEditTasks_UserDto>(tasks_User) };

            if (output.Tasks_User.TTTaskId != null)
            {
                var _lookupTTTask = await _lookup_ttTaskRepository.FirstOrDefaultAsync((int)output.Tasks_User.TTTaskId);
                output.TTTaskName = _lookupTTTask?.Name?.ToString();
            }

            if (output.Tasks_User.UserId != null)
            {
                var _lookupUser = await _lookup_userRepository.FirstOrDefaultAsync((long)output.Tasks_User.UserId);
                output.UserName = _lookupUser?.Name?.ToString();
            }

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditTasks_UserDto input)
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

        [AbpAuthorize(AppPermissions.Pages_Tasks_Users_Create)]
        protected virtual async Task Create(CreateOrEditTasks_UserDto input)
        {
            var tasks_User = ObjectMapper.Map<Tasks_User>(input);

            if (AbpSession.TenantId != null)
            {
                tasks_User.TenantId = (int?)AbpSession.TenantId;
            }

            await _tasks_UserRepository.InsertAsync(tasks_User);

        }

        [AbpAuthorize(AppPermissions.Pages_Tasks_Users_Edit)]
        protected virtual async Task Update(CreateOrEditTasks_UserDto input)
        {
            var tasks_User = await _tasks_UserRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, tasks_User);

        }

        [AbpAuthorize(AppPermissions.Pages_Tasks_Users_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _tasks_UserRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetTasks_UsersToExcel(GetAllTasks_UsersForExcelInput input)
        {

            var filteredTasks_Users = _tasks_UserRepository.GetAll()
                        .Include(e => e.TTTaskFk)
                        .Include(e => e.UserFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TTTaskNameFilter), e => e.TTTaskFk != null && e.TTTaskFk.Name == input.TTTaskNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.UserNameFilter), e => e.UserFk != null && e.UserFk.Name == input.UserNameFilter);

            var query = (from o in filteredTasks_Users
                         join o1 in _lookup_ttTaskRepository.GetAll() on o.TTTaskId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()

                         join o2 in _lookup_userRepository.GetAll() on o.UserId equals o2.Id into j2
                         from s2 in j2.DefaultIfEmpty()

                         select new GetTasks_UserForViewDto()
                         {
                             Tasks_User = new Tasks_UserDto
                             {
                                 Id = o.Id
                             },
                             TTTaskName = s1 == null || s1.Name == null ? "" : s1.Name.ToString(),
                             UserName = s2 == null || s2.Name == null ? "" : s2.Name.ToString()
                         });

            var tasks_UserListDtos = await query.ToListAsync();

            return _tasks_UsersExcelExporter.ExportToFile(tasks_UserListDtos);
        }

        [AbpAuthorize(AppPermissions.Pages_Tasks_Users)]
        public async Task<PagedResultDto<Tasks_UserTTTaskLookupTableDto>> GetAllTTTaskForLookupTable(GetAllForLookupTableInput input)
        {
            var query = _lookup_ttTaskRepository.GetAll().WhereIf(
                   !string.IsNullOrWhiteSpace(input.Filter),
                  e => e.Name != null && e.Name.Contains(input.Filter)
               );

            var totalCount = await query.CountAsync();

            var ttTaskList = await query
                .PageBy(input)
                .ToListAsync();

            var lookupTableDtoList = new List<Tasks_UserTTTaskLookupTableDto>();
            foreach (var ttTask in ttTaskList)
            {
                lookupTableDtoList.Add(new Tasks_UserTTTaskLookupTableDto
                {
                    Id = ttTask.Id,
                    DisplayName = ttTask.Name?.ToString()
                });
            }

            return new PagedResultDto<Tasks_UserTTTaskLookupTableDto>(
                totalCount,
                lookupTableDtoList
            );
        }

        [AbpAuthorize(AppPermissions.Pages_Tasks_Users)]
        public async Task<PagedResultDto<Tasks_UserUserLookupTableDto>> GetAllUserForLookupTable(GetAllForLookupTableInput input)
        {
            var query = _lookup_userRepository.GetAll().WhereIf(
                   !string.IsNullOrWhiteSpace(input.Filter),
                  e => e.Name != null && e.Name.Contains(input.Filter)
               );

            var totalCount = await query.CountAsync();

            var userList = await query
                .PageBy(input)
                .ToListAsync();

            var lookupTableDtoList = new List<Tasks_UserUserLookupTableDto>();
            foreach (var user in userList)
            {
                lookupTableDtoList.Add(new Tasks_UserUserLookupTableDto
                {
                    Id = user.Id,
                    DisplayName = user.Name?.ToString()
                });
            }

            return new PagedResultDto<Tasks_UserUserLookupTableDto>(
                totalCount,
                lookupTableDtoList
            );
        }

    }
}