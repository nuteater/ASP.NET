import { Component, ViewChild, Injector, Output, EventEmitter} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { TaskPrioritiesServiceProxy, CreateOrEditTaskPriorityDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as moment from 'moment';

@Component({
    selector: 'createOrEditTaskPriorityModal',
    templateUrl: './create-or-edit-taskPriority-modal.component.html'
})
export class CreateOrEditTaskPriorityModalComponent extends AppComponentBase {
   
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    taskPriority: CreateOrEditTaskPriorityDto = new CreateOrEditTaskPriorityDto();



    constructor(
        injector: Injector,
        private _taskPrioritiesServiceProxy: TaskPrioritiesServiceProxy
    ) {
        super(injector);
    }
    
    show(taskPriorityId?: number): void {
    

        if (!taskPriorityId) {
            this.taskPriority = new CreateOrEditTaskPriorityDto();
            this.taskPriority.id = taskPriorityId;

            this.active = true;
            this.modal.show();
        } else {
            this._taskPrioritiesServiceProxy.getTaskPriorityForEdit(taskPriorityId).subscribe(result => {
                this.taskPriority = result.taskPriority;


                this.active = true;
                this.modal.show();
            });
        }
        
    }

    save(): void {
            this.saving = true;

			
			
            this._taskPrioritiesServiceProxy.createOrEdit(this.taskPriority)
             .pipe(finalize(() => { this.saving = false;}))
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
}
