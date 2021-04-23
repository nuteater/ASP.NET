﻿import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute , Router} from '@angular/router';
import { TTTasksServiceProxy, TTTaskDto  } from '@shared/service-proxies/service-proxies';
import { NotifyService } from 'abp-ng2-module';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditTTTaskModalComponent } from './create-or-edit-ttTask-modal.component';

import { ViewTTTaskModalComponent } from './view-ttTask-modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/public_api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import * as _ from 'lodash';
import * as moment from 'moment';

@Component({
    templateUrl: './ttTasks.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()]
})
export class TTTasksComponent extends AppComponentBase {
    
    
    @ViewChild('createOrEditTTTaskModal', { static: true }) createOrEditTTTaskModal: CreateOrEditTTTaskModalComponent;
    @ViewChild('viewTTTaskModalComponent', { static: true }) viewTTTaskModal: ViewTTTaskModalComponent;   
    
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    advancedFiltersAreShown = false;
    filterText = '';
    nameFilter = '';
    descriptionFilter = '';
        taskTypeNameFilter = '';
        taskPriorityNameFilter = '';
        subtasksDescriptionFilter = '';
        taskHistoryDescriptionFilter = '';






    constructor(
        injector: Injector,
        private _ttTasksServiceProxy: TTTasksServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService
    ) {
        super(injector);
    }

    getTTTasks(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._ttTasksServiceProxy.getAll(
            this.filterText,
            this.nameFilter,
            this.descriptionFilter,
            this.taskTypeNameFilter,
            this.taskPriorityNameFilter,
            this.subtasksDescriptionFilter,
            this.taskHistoryDescriptionFilter,
            this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getSkipCount(this.paginator, event),
            this.primengTableHelper.getMaxResultCount(this.paginator, event)
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    createTTTask(): void {
        this.createOrEditTTTaskModal.show();        
    }


    deleteTTTask(ttTask: TTTaskDto): void {
        this.message.confirm(
            '',
            this.l('AreYouSure'),
            (isConfirmed) => {
                if (isConfirmed) {
                    this._ttTasksServiceProxy.delete(ttTask.id)
                        .subscribe(() => {
                            this.reloadPage();
                            this.notify.success(this.l('SuccessfullyDeleted'));
                        });
                }
            }
        );
    }

    exportToExcel(): void {
        this._ttTasksServiceProxy.getTTTasksToExcel(
        this.filterText,
            this.nameFilter,
            this.descriptionFilter,
            this.taskTypeNameFilter,
            this.taskPriorityNameFilter,
            this.subtasksDescriptionFilter,
            this.taskHistoryDescriptionFilter,
        )
        .subscribe(result => {
            this._fileDownloadService.downloadTempFile(result);
         });
    }
    
    
    
}
