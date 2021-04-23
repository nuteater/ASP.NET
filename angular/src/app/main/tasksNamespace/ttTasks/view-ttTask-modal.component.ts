import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GetTTTaskForViewDto, TTTaskDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'viewTTTaskModal',
    templateUrl: './view-ttTask-modal.component.html'
})
export class ViewTTTaskModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: GetTTTaskForViewDto;


    constructor(
        injector: Injector
    ) {
        super(injector);
        this.item = new GetTTTaskForViewDto();
        this.item.ttTask = new TTTaskDto();
    }

    show(item: GetTTTaskForViewDto): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
