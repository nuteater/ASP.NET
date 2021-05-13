import { AppConsts } from '@shared/AppConsts';
import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GetTask_TaskTopicForViewDto, Task_TaskTopicDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'viewTask_TaskTopicModal',
    templateUrl: './view-task_TaskTopic-modal.component.html',
})
export class ViewTask_TaskTopicModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: GetTask_TaskTopicForViewDto;

    constructor(injector: Injector) {
        super(injector);
        this.item = new GetTask_TaskTopicForViewDto();
        this.item.task_TaskTopic = new Task_TaskTopicDto();
    }

    show(item: GetTask_TaskTopicForViewDto): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
