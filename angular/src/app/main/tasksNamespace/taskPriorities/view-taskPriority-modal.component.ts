import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GetTaskPriorityForViewDto, TaskPriorityDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'viewTaskPriorityModal',
    templateUrl: './view-taskPriority-modal.component.html'
})
export class ViewTaskPriorityModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: GetTaskPriorityForViewDto;


    constructor(
        injector: Injector
    ) {
        super(injector);
        this.item = new GetTaskPriorityForViewDto();
        this.item.taskPriority = new TaskPriorityDto();
    }

    show(item: GetTaskPriorityForViewDto): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
