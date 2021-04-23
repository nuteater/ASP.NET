import { Component, ViewChild, Injector, Output, EventEmitter} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { TTTasksServiceProxy, CreateOrEditTTTaskDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as moment from 'moment';
import { TTTaskTaskTypeLookupTableModalComponent } from './ttTask-taskType-lookup-table-modal.component';
import { TTTaskTaskPriorityLookupTableModalComponent } from './ttTask-taskPriority-lookup-table-modal.component';
import { TTTaskSubtasksLookupTableModalComponent } from './ttTask-subtasks-lookup-table-modal.component';
import { TTTaskTaskHistoryLookupTableModalComponent } from './ttTask-taskHistory-lookup-table-modal.component';

@Component({
    selector: 'createOrEditTTTaskModal',
    templateUrl: './create-or-edit-ttTask-modal.component.html'
})
export class CreateOrEditTTTaskModalComponent extends AppComponentBase {
   
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @ViewChild('ttTaskTaskTypeLookupTableModal', { static: true }) ttTaskTaskTypeLookupTableModal: TTTaskTaskTypeLookupTableModalComponent;
    @ViewChild('ttTaskTaskPriorityLookupTableModal', { static: true }) ttTaskTaskPriorityLookupTableModal: TTTaskTaskPriorityLookupTableModalComponent;
    @ViewChild('ttTaskSubtasksLookupTableModal', { static: true }) ttTaskSubtasksLookupTableModal: TTTaskSubtasksLookupTableModalComponent;
    @ViewChild('ttTaskTaskHistoryLookupTableModal', { static: true }) ttTaskTaskHistoryLookupTableModal: TTTaskTaskHistoryLookupTableModalComponent;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    ttTask: CreateOrEditTTTaskDto = new CreateOrEditTTTaskDto();

    taskTypeName = '';
    taskPriorityName = '';
    subtasksDescription = '';
    taskHistoryDescription = '';


    constructor(
        injector: Injector,
        private _ttTasksServiceProxy: TTTasksServiceProxy
    ) {
        super(injector);
    }
    
    show(ttTaskId?: number): void {
    

        if (!ttTaskId) {
            this.ttTask = new CreateOrEditTTTaskDto();
            this.ttTask.id = ttTaskId;
            this.taskTypeName = '';
            this.taskPriorityName = '';
            this.subtasksDescription = '';
            this.taskHistoryDescription = '';

            this.active = true;
            this.modal.show();
        } else {
            this._ttTasksServiceProxy.getTTTaskForEdit(ttTaskId).subscribe(result => {
                this.ttTask = result.ttTask;

                this.taskTypeName = result.taskTypeName;
                this.taskPriorityName = result.taskPriorityName;
                this.subtasksDescription = result.subtasksDescription;
                this.taskHistoryDescription = result.taskHistoryDescription;

                this.active = true;
                this.modal.show();
            });
        }
        
    }

    save(): void {
            this.saving = true;

			
			
            this._ttTasksServiceProxy.createOrEdit(this.ttTask)
             .pipe(finalize(() => { this.saving = false;}))
             .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
             });
    }

    openSelectTaskTypeModal() {
        this.ttTaskTaskTypeLookupTableModal.id = this.ttTask.taskTypeId;
        this.ttTaskTaskTypeLookupTableModal.displayName = this.taskTypeName;
        this.ttTaskTaskTypeLookupTableModal.show();
    }
    openSelectTaskPriorityModal() {
        this.ttTaskTaskPriorityLookupTableModal.id = this.ttTask.taskPriorityId;
        this.ttTaskTaskPriorityLookupTableModal.displayName = this.taskPriorityName;
        this.ttTaskTaskPriorityLookupTableModal.show();
    }
    openSelectSubtasksModal() {
        this.ttTaskSubtasksLookupTableModal.id = this.ttTask.subtasksId;
        this.ttTaskSubtasksLookupTableModal.displayName = this.subtasksDescription;
        this.ttTaskSubtasksLookupTableModal.show();
    }
    openSelectTaskHistoryModal() {
        this.ttTaskTaskHistoryLookupTableModal.id = this.ttTask.taskHistoryId;
        this.ttTaskTaskHistoryLookupTableModal.displayName = this.taskHistoryDescription;
        this.ttTaskTaskHistoryLookupTableModal.show();
    }


    setTaskTypeIdNull() {
        this.ttTask.taskTypeId = null;
        this.taskTypeName = '';
    }
    setTaskPriorityIdNull() {
        this.ttTask.taskPriorityId = null;
        this.taskPriorityName = '';
    }
    setSubtasksIdNull() {
        this.ttTask.subtasksId = null;
        this.subtasksDescription = '';
    }
    setTaskHistoryIdNull() {
        this.ttTask.taskHistoryId = null;
        this.taskHistoryDescription = '';
    }


    getNewTaskTypeId() {
        this.ttTask.taskTypeId = this.ttTaskTaskTypeLookupTableModal.id;
        this.taskTypeName = this.ttTaskTaskTypeLookupTableModal.displayName;
    }
    getNewTaskPriorityId() {
        this.ttTask.taskPriorityId = this.ttTaskTaskPriorityLookupTableModal.id;
        this.taskPriorityName = this.ttTaskTaskPriorityLookupTableModal.displayName;
    }
    getNewSubtasksId() {
        this.ttTask.subtasksId = this.ttTaskSubtasksLookupTableModal.id;
        this.subtasksDescription = this.ttTaskSubtasksLookupTableModal.displayName;
    }
    getNewTaskHistoryId() {
        this.ttTask.taskHistoryId = this.ttTaskTaskHistoryLookupTableModal.id;
        this.taskHistoryDescription = this.ttTaskTaskHistoryLookupTableModal.displayName;
    }


    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
