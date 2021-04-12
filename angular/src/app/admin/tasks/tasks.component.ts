import { Component, Injector, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TasksServiceProxy } from '@shared/service-proxies/service-proxies';


@Component({
    templateUrl: './tasks.component.html',
    animations: [appModuleAnimation()]
})
export class TasksComponent extends AppComponentBase {
    constructor(
        injector: Injector,
        private _tasksService: TasksServiceProxy
    ) {
        super(injector);
    }
}
