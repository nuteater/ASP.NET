import { AppConsts } from '@shared/AppConsts';
import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Task_TaskTopicsServiceProxy, Task_TaskTopicDto } from '@shared/service-proxies/service-proxies';
import { NotifyService } from 'abp-ng2-module';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditTask_TaskTopicModalComponent } from './create-or-edit-task_TaskTopic-modal.component';

import { ViewTask_TaskTopicModalComponent } from './view-task_TaskTopic-modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import { filter as _filter } from 'lodash-es';
import { DateTime } from 'luxon';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';

@Component({
    templateUrl: './task_TaskTopics.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
})
export class Task_TaskTopicsComponent extends AppComponentBase {
    @ViewChild('createOrEditTask_TaskTopicModal', { static: true })
    createOrEditTask_TaskTopicModal: CreateOrEditTask_TaskTopicModalComponent;
    @ViewChild('viewTask_TaskTopicModalComponent', { static: true })
    viewTask_TaskTopicModal: ViewTask_TaskTopicModalComponent;

    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    advancedFiltersAreShown = false;
    filterText = '';
    maxTaskIdFilter: number;
    maxTaskIdFilterEmpty: number;
    minTaskIdFilter: number;
    minTaskIdFilterEmpty: number;
    topikIdFilter = '';

    constructor(
        injector: Injector,
        private _task_TaskTopicsServiceProxy: Task_TaskTopicsServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    getTask_TaskTopics(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._task_TaskTopicsServiceProxy
            .getAll(
                this.filterText,
                this.maxTaskIdFilter == null ? this.maxTaskIdFilterEmpty : this.maxTaskIdFilter,
                this.minTaskIdFilter == null ? this.minTaskIdFilterEmpty : this.minTaskIdFilter,
                this.topikIdFilter,
                this.primengTableHelper.getSorting(this.dataTable),
                this.primengTableHelper.getSkipCount(this.paginator, event),
                this.primengTableHelper.getMaxResultCount(this.paginator, event)
            )
            .subscribe((result) => {
                this.primengTableHelper.totalRecordsCount = result.totalCount;
                this.primengTableHelper.records = result.items;
                this.primengTableHelper.hideLoadingIndicator();
            });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    createTask_TaskTopic(): void {
        this.createOrEditTask_TaskTopicModal.show();
    }

    deleteTask_TaskTopic(task_TaskTopic: Task_TaskTopicDto): void {
        this.message.confirm('', this.l('AreYouSure'), (isConfirmed) => {
            if (isConfirmed) {
                this._task_TaskTopicsServiceProxy.delete(task_TaskTopic.id).subscribe(() => {
                    this.reloadPage();
                    this.notify.success(this.l('SuccessfullyDeleted'));
                });
            }
        });
    }

    exportToExcel(): void {
        this._task_TaskTopicsServiceProxy
            .getTask_TaskTopicsToExcel(
                this.filterText,
                this.maxTaskIdFilter == null ? this.maxTaskIdFilterEmpty : this.maxTaskIdFilter,
                this.minTaskIdFilter == null ? this.minTaskIdFilterEmpty : this.minTaskIdFilter,
                this.topikIdFilter
            )
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);
            });
    }
}
