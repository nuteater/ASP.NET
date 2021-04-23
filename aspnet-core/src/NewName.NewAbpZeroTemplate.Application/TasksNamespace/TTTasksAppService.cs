using NewName.NewAbpZeroTemplate.TasksNamespace;
using NewName.NewAbpZeroTemplate.TasksNamespace;
using NewName.NewAbpZeroTemplate.TasksNamespace;
using NewName.NewAbpZeroTemplate.TasksNamespace;


using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using NewName.NewAbpZeroTemplate.TasksNamespace.Exporting;
using NewName.NewAbpZeroTemplate.TasksNamespace.Dtos;
using NewName.NewAbpZeroTemplate.Dto;
using Abp.Application.Services.Dto;
using NewName.NewAbpZeroTemplate.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewName.NewAbpZeroTemplate.Authorization.Users;

namespace NewName.NewAbpZeroTemplate.TasksNamespace
{
	[AbpAuthorize(AppPermissions.Pages_TTTasks)]
	public class TTTasksAppService : NewAbpZeroTemplateAppServiceBase, ITTTasksAppService
	{
		private readonly IRepository<TTTask> _ttTaskRepository;
		private readonly ITTTasksExcelExporter _ttTasksExcelExporter;
		private readonly IRepository<TaskType, int> _lookup_taskTypeRepository;
		private readonly IRepository<TaskPriority, int> _lookup_taskPriorityRepository;
		private readonly IRepository<Subtasks, int> _lookup_subtasksRepository;
		private readonly IRepository<TaskHistory, int> _lookup_taskHistoryRepository;


		public TTTasksAppService(IRepository<TTTask> ttTaskRepository, ITTTasksExcelExporter ttTasksExcelExporter,
			IRepository<TaskType, int> lookup_taskTypeRepository,
			IRepository<TaskPriority, int> lookup_taskPriorityRepository,
			IRepository<Subtasks, int> lookup_subtasksRepository,
			IRepository<TaskHistory, int> lookup_taskHistoryRepository
		)
		{
			_ttTaskRepository = ttTaskRepository;
			_ttTasksExcelExporter = ttTasksExcelExporter;
			_lookup_taskTypeRepository = lookup_taskTypeRepository;
			_lookup_taskPriorityRepository = lookup_taskPriorityRepository;
			_lookup_subtasksRepository = lookup_subtasksRepository;
			_lookup_taskHistoryRepository = lookup_taskHistoryRepository;
		}


		public async Task<PagedResultDto<TTTaskDto>> GetAllTask()
		{
			var tasks = await _ttTaskRepository.GetAll().ToListAsync();
			var tasksDto = ObjectMapper.Map<List<TTTaskDto>>(tasks);
			return new PagedResultDto<TTTaskDto>()
			{
				TotalCount = tasksDto.Count,
				Items = tasksDto
			};
		}
		
		public async Task<PagedResultDto<GetTTTaskForViewDto>> GetAll(GetAllTTTasksInput input)
		{
			var filteredTTTasks = _ttTaskRepository.GetAll()
				.Include(e => e.TaskTypeFk)
				.Include(e => e.TaskPriorityFk)
				.Include(e => e.SubtasksFk)
				.Include(e => e.TaskHistoryFk)
				.WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
					e => false || e.Name.Contains(input.Filter) || e.Description.Contains(input.Filter))
				.WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
				.WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter),
					e => e.Description == input.DescriptionFilter)
				.WhereIf(!string.IsNullOrWhiteSpace(input.TaskTypeNameFilter),
					e => e.TaskTypeFk != null && e.TaskTypeFk.Name == input.TaskTypeNameFilter)
				.WhereIf(!string.IsNullOrWhiteSpace(input.TaskPriorityNameFilter),
					e => e.TaskPriorityFk != null && e.TaskPriorityFk.Name == input.TaskPriorityNameFilter)
				.WhereIf(!string.IsNullOrWhiteSpace(input.SubtasksDescriptionFilter),
					e => e.SubtasksFk != null && e.SubtasksFk.Description == input.SubtasksDescriptionFilter)
				.WhereIf(!string.IsNullOrWhiteSpace(input.TaskHistoryDescriptionFilter),
					e => e.TaskHistoryFk != null && e.TaskHistoryFk.Description == input.TaskHistoryDescriptionFilter);

			var pagedAndFilteredTTTasks = filteredTTTasks
				.OrderBy(input.Sorting ?? "id asc")
				.PageBy(input);

			var ttTasks = from o in pagedAndFilteredTTTasks
				join o1 in _lookup_taskTypeRepository.GetAll() on o.TaskTypeId equals o1.Id into j1
				from s1 in j1.DefaultIfEmpty()
				join o2 in _lookup_taskPriorityRepository.GetAll() on o.TaskPriorityId equals o2.Id into j2
				from s2 in j2.DefaultIfEmpty()
				join o3 in _lookup_subtasksRepository.GetAll() on o.SubtasksId equals o3.Id into j3
				from s3 in j3.DefaultIfEmpty()
				join o4 in _lookup_taskHistoryRepository.GetAll() on o.TaskHistoryId equals o4.Id into j4
				from s4 in j4.DefaultIfEmpty()
				select new GetTTTaskForViewDto
				{
					TTTask = new TTTaskDto
					{
						Name = o.Name,
						Description = o.Description,
						Id = o.Id
					},
					TaskTypeName = s1 == null || s1.Name == null ? "" : s1.Name,
					TaskPriorityName = s2 == null || s2.Name == null ? "" : s2.Name,
					SubtasksDescription = s3 == null || s3.Description == null ? "" : s3.Description,
					TaskHistoryDescription = s4 == null || s4.Description == null ? "" : s4.Description.ToString()
				};

			var totalCount = await filteredTTTasks.CountAsync();

			return new PagedResultDto<GetTTTaskForViewDto>(
				totalCount,
				await ttTasks.ToListAsync()
			);
		}

		public async Task<GetTTTaskForViewDto> GetTTTaskForView(int id)
		{
			var ttTask = await _ttTaskRepository.GetAsync(id);

			var output = new GetTTTaskForViewDto {TTTask = ObjectMapper.Map<TTTaskDto>(ttTask)};

			if (output.TTTask.TaskTypeId != null)
			{
				var _lookupTaskType =
					await _lookup_taskTypeRepository.FirstOrDefaultAsync((int) output.TTTask.TaskTypeId);
				output.TaskTypeName = _lookupTaskType?.Name;
			}

			if (output.TTTask.TaskPriorityId != null)
			{
				var _lookupTaskPriority =
					await _lookup_taskPriorityRepository.FirstOrDefaultAsync((int) output.TTTask.TaskPriorityId);
				output.TaskPriorityName = _lookupTaskPriority?.Name;
			}

			if (output.TTTask.SubtasksId != null)
			{
				var _lookupSubtasks =
					await _lookup_subtasksRepository.FirstOrDefaultAsync((int) output.TTTask.SubtasksId);
				output.SubtasksDescription = _lookupSubtasks?.Description;
			}

			if (output.TTTask.TaskHistoryId != null)
			{
				var _lookupTaskHistory =
					await _lookup_taskHistoryRepository.FirstOrDefaultAsync((int) output.TTTask.TaskHistoryId);
				output.TaskHistoryDescription = _lookupTaskHistory?.Description;
			}

			return output;
		}

		[AbpAuthorize(AppPermissions.Pages_TTTasks_Edit)]
		public async Task<GetTTTaskForEditOutput> GetTTTaskForEdit(EntityDto input)
		{
			var ttTask = await _ttTaskRepository.FirstOrDefaultAsync(input.Id);

			var output = new GetTTTaskForEditOutput {TTTask = ObjectMapper.Map<CreateOrEditTTTaskDto>(ttTask)};

			if (output.TTTask.TaskTypeId != null)
			{
				var _lookupTaskType =
					await _lookup_taskTypeRepository.FirstOrDefaultAsync((int) output.TTTask.TaskTypeId);
				output.TaskTypeName = _lookupTaskType?.Name;
			}

			if (output.TTTask.TaskPriorityId != null)
			{
				var _lookupTaskPriority =
					await _lookup_taskPriorityRepository.FirstOrDefaultAsync((int) output.TTTask.TaskPriorityId);
				output.TaskPriorityName = _lookupTaskPriority?.Name;
			}

			if (output.TTTask.SubtasksId != null)
			{
				var _lookupSubtasks =
					await _lookup_subtasksRepository.FirstOrDefaultAsync((int) output.TTTask.SubtasksId);
				output.SubtasksDescription = _lookupSubtasks?.Description;
			}

			if (output.TTTask.TaskHistoryId != null)
			{
				var _lookupTaskHistory =
					await _lookup_taskHistoryRepository.FirstOrDefaultAsync((int) output.TTTask.TaskHistoryId);
				output.TaskHistoryDescription = _lookupTaskHistory?.Description;
			}

			return output;
		}

		public async Task CreateOrEdit(CreateOrEditTTTaskDto input)
		{
			if (input.Id == null)
				await Create(input);
			else
				await Update(input);
		}

		[AbpAuthorize(AppPermissions.Pages_TTTasks_Create)]
		protected virtual async Task Create(CreateOrEditTTTaskDto input)
		{
			var ttTask = ObjectMapper.Map<TTTask>(input);


			if (AbpSession.TenantId != null) ttTask.TenantId = AbpSession.TenantId;


			await _ttTaskRepository.InsertAsync(ttTask);
		}

		[AbpAuthorize(AppPermissions.Pages_TTTasks_Edit)]
		protected virtual async Task Update(CreateOrEditTTTaskDto input)
		{
			var ttTask = await _ttTaskRepository.FirstOrDefaultAsync((int) input.Id);
			ObjectMapper.Map(input, ttTask);
		}

		[AbpAuthorize(AppPermissions.Pages_TTTasks_Delete)]
		public async Task Delete(EntityDto input)
		{
			await _ttTaskRepository.DeleteAsync(input.Id);
		}

		public async Task<FileDto> GetTTTasksToExcel(GetAllTTTasksForExcelInput input)
		{
			var filteredTTTasks = _ttTaskRepository.GetAll()
				.Include(e => e.TaskTypeFk)
				.Include(e => e.TaskPriorityFk)
				.Include(e => e.SubtasksFk)
				.Include(e => e.TaskHistoryFk)
				.WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
					e => false || e.Name.Contains(input.Filter) || e.Description.Contains(input.Filter))
				.WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
				.WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter),
					e => e.Description == input.DescriptionFilter)
				.WhereIf(!string.IsNullOrWhiteSpace(input.TaskTypeNameFilter),
					e => e.TaskTypeFk != null && e.TaskTypeFk.Name == input.TaskTypeNameFilter)
				.WhereIf(!string.IsNullOrWhiteSpace(input.TaskPriorityNameFilter),
					e => e.TaskPriorityFk != null && e.TaskPriorityFk.Name == input.TaskPriorityNameFilter)
				.WhereIf(!string.IsNullOrWhiteSpace(input.SubtasksDescriptionFilter),
					e => e.SubtasksFk != null && e.SubtasksFk.Description == input.SubtasksDescriptionFilter)
				.WhereIf(!string.IsNullOrWhiteSpace(input.TaskHistoryDescriptionFilter),
					e => e.TaskHistoryFk != null && e.TaskHistoryFk.Description == input.TaskHistoryDescriptionFilter);

			var query = from o in filteredTTTasks
				join o1 in _lookup_taskTypeRepository.GetAll() on o.TaskTypeId equals o1.Id into j1
				from s1 in j1.DefaultIfEmpty()
				join o2 in _lookup_taskPriorityRepository.GetAll() on o.TaskPriorityId equals o2.Id into j2
				from s2 in j2.DefaultIfEmpty()
				join o3 in _lookup_subtasksRepository.GetAll() on o.SubtasksId equals o3.Id into j3
				from s3 in j3.DefaultIfEmpty()
				join o4 in _lookup_taskHistoryRepository.GetAll() on o.TaskHistoryId equals o4.Id into j4
				from s4 in j4.DefaultIfEmpty()
				select new GetTTTaskForViewDto
				{
					TTTask = new TTTaskDto
					{
						Name = o.Name,
						Description = o.Description,
						Id = o.Id
					},
					TaskTypeName = s1 == null || s1.Name == null ? "" : s1.Name,
					TaskPriorityName = s2 == null || s2.Name == null ? "" : s2.Name,
					SubtasksDescription = s3 == null || s3.Description == null ? "" : s3.Description,
					TaskHistoryDescription = s4 == null || s4.Description == null ? "" : s4.Description.ToString()
				};


			var ttTaskListDtos = await query.ToListAsync();

			return _ttTasksExcelExporter.ExportToFile(ttTaskListDtos);
		}


		[AbpAuthorize(AppPermissions.Pages_TTTasks)]
		public async Task<PagedResultDto<TTTaskTaskTypeLookupTableDto>> GetAllTaskTypeForLookupTable(
			GetAllForLookupTableInput input)
		{
			var query = _lookup_taskTypeRepository.GetAll().WhereIf(
				!string.IsNullOrWhiteSpace(input.Filter),
				e => e.Name != null && e.Name.Contains(input.Filter)
			);

			var totalCount = await query.CountAsync();

			var taskTypeList = await query
				.PageBy(input)
				.ToListAsync();

			var lookupTableDtoList = new List<TTTaskTaskTypeLookupTableDto>();
			foreach (var taskType in taskTypeList)
				lookupTableDtoList.Add(new TTTaskTaskTypeLookupTableDto
				{
					Id = taskType.Id,
					DisplayName = taskType.Name
				});

			return new PagedResultDto<TTTaskTaskTypeLookupTableDto>(
				totalCount,
				lookupTableDtoList
			);
		}

		[AbpAuthorize(AppPermissions.Pages_TTTasks)]
		public async Task<PagedResultDto<TTTaskTaskPriorityLookupTableDto>> GetAllTaskPriorityForLookupTable(
			GetAllForLookupTableInput input)
		{
			var query = _lookup_taskPriorityRepository.GetAll().WhereIf(
				!string.IsNullOrWhiteSpace(input.Filter),
				e => e.Name != null && e.Name.Contains(input.Filter)
			);

			var totalCount = await query.CountAsync();

			var taskPriorityList = await query
				.PageBy(input)
				.ToListAsync();

			var lookupTableDtoList = new List<TTTaskTaskPriorityLookupTableDto>();
			foreach (var taskPriority in taskPriorityList)
				lookupTableDtoList.Add(new TTTaskTaskPriorityLookupTableDto
				{
					Id = taskPriority.Id,
					DisplayName = taskPriority.Name
				});

			return new PagedResultDto<TTTaskTaskPriorityLookupTableDto>(
				totalCount,
				lookupTableDtoList
			);
		}

		[AbpAuthorize(AppPermissions.Pages_TTTasks)]
		public async Task<PagedResultDto<TTTaskSubtasksLookupTableDto>> GetAllSubtasksForLookupTable(
			GetAllForLookupTableInput input)
		{
			var query = _lookup_subtasksRepository.GetAll().WhereIf(
				!string.IsNullOrWhiteSpace(input.Filter),
				e => e.Description != null && e.Description.Contains(input.Filter)
			);

			var totalCount = await query.CountAsync();

			var subtasksList = await query
				.PageBy(input)
				.ToListAsync();

			var lookupTableDtoList = new List<TTTaskSubtasksLookupTableDto>();
			foreach (var subtasks in subtasksList)
				lookupTableDtoList.Add(new TTTaskSubtasksLookupTableDto
				{
					Id = subtasks.Id,
					DisplayName = subtasks.Description
				});

			return new PagedResultDto<TTTaskSubtasksLookupTableDto>(
				totalCount,
				lookupTableDtoList
			);
		}

		[AbpAuthorize(AppPermissions.Pages_TTTasks)]
		public async Task<PagedResultDto<TTTaskTaskHistoryLookupTableDto>> GetAllTaskHistoryForLookupTable(
			GetAllForLookupTableInput input)
		{
			var query = _lookup_taskHistoryRepository.GetAll().WhereIf(
				!string.IsNullOrWhiteSpace(input.Filter),
				e => e.Description != null && e.Description.Contains(input.Filter)
			);

			var totalCount = await query.CountAsync();

			var taskHistoryList = await query
				.PageBy(input)
				.ToListAsync();

			var lookupTableDtoList = new List<TTTaskTaskHistoryLookupTableDto>();
			foreach (var taskHistory in taskHistoryList)
				lookupTableDtoList.Add(new TTTaskTaskHistoryLookupTableDto
				{
					Id = taskHistory.Id,
					DisplayName = taskHistory.Description
				});

			return new PagedResultDto<TTTaskTaskHistoryLookupTableDto>(
				totalCount,
				lookupTableDtoList
			);
		}
    }
}