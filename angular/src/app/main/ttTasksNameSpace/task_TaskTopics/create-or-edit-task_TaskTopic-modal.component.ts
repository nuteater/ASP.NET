import { Component, ViewChild, Injector, Output, EventEmitter, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { Task_TaskTopicsServiceProxy, CreateOrEditTask_TaskTopicDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';

@Component({
    selector: 'createOrEditTask_TaskTopicModal',
    templateUrl: './create-or-edit-task_TaskTopic-modal.component.html',
})
export class CreateOrEditTask_TaskTopicModalComponent extends AppComponentBase implements OnInit {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    task_TaskTopic: CreateOrEditTask_TaskTopicDto = new CreateOrEditTask_TaskTopicDto();

    constructor(
        injector: Injector,
        private _task_TaskTopicsServiceProxy: Task_TaskTopicsServiceProxy,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    show(task_TaskTopicId?: number): void {
        if (!task_TaskTopicId) {
            this.task_TaskTopic = new CreateOrEditTask_TaskTopicDto();
            this.task_TaskTopic.id = task_TaskTopicId;

            this.active = true;
            this.modal.show();
        } else {
            this._task_TaskTopicsServiceProxy.getTask_TaskTopicForEdit(task_TaskTopicId).subscribe((result) => {
                this.task_TaskTopic = result.task_TaskTopic;

                this.active = true;
                this.modal.show();
            });
        }
    }

    save(): void {
        this.saving = true;

        this._task_TaskTopicsServiceProxy
            .createOrEdit(this.task_TaskTopic)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }

    ngOnInit(): void {}
}
