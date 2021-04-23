import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppCommonModule } from '@app/shared/common/app-common.module';
import { TTTaskTaskPriorityLookupTableModalComponent } from './tasksNamespace/ttTasks/ttTask-taskPriority-lookup-table-modal.component';
import { TTTaskSubtasksLookupTableModalComponent } from './tasksNamespace/ttTasks/ttTask-subtasks-lookup-table-modal.component';
import { TTTaskTaskHistoryLookupTableModalComponent } from './tasksNamespace/ttTasks/ttTask-taskHistory-lookup-table-modal.component';

import { TTTaskTaskTypeLookupTableModalComponent } from './tasksNamespace/ttTasks/ttTask-taskType-lookup-table-modal.component';

import { TaskPrioritiesComponent } from './tasksNamespace/taskPriorities/taskPriorities.component';
import { ViewTaskPriorityModalComponent } from './tasksNamespace/taskPriorities/view-taskPriority-modal.component';
import { CreateOrEditTaskPriorityModalComponent } from './tasksNamespace/taskPriorities/create-or-edit-taskPriority-modal.component';

import { TTTasksComponent } from './tasksNamespace/ttTasks/ttTasks.component';
import { ViewTTTaskModalComponent } from './tasksNamespace/ttTasks/view-ttTask-modal.component';
import { CreateOrEditTTTaskModalComponent } from './tasksNamespace/ttTasks/create-or-edit-ttTask-modal.component';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { PaginatorModule } from 'primeng/paginator';
import { EditorModule } from 'primeng/editor';
import { InputMaskModule } from 'primeng/inputmask';import { FileUploadModule } from 'primeng/fileupload';
import { TableModule } from 'primeng/table';

import { UtilsModule } from '@shared/utils/utils.module';
import { CountoModule } from 'angular2-counto';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { PopoverModule } from 'ngx-bootstrap/popover';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MainRoutingModule } from './main-routing.module';

import { BsDatepickerConfig, BsDaterangepickerConfig, BsLocaleService } from 'ngx-bootstrap/datepicker';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { NgxBootstrapDatePickerConfigService } from 'assets/ngx-bootstrap/ngx-bootstrap-datepicker-config.service';

NgxBootstrapDatePickerConfigService.registerNgxBootstrapDatePickerLocales();

@NgModule({
    imports: [
		FileUploadModule,
		AutoCompleteModule,
		PaginatorModule,
		EditorModule,
		InputMaskModule,		TableModule,

        CommonModule,
        FormsModule,
        ModalModule,
        TabsModule,
        TooltipModule,
        AppCommonModule,
        UtilsModule,
        MainRoutingModule,
        CountoModule,
        BsDatepickerModule.forRoot(),
        BsDropdownModule.forRoot(),
        PopoverModule.forRoot()
    ],
    declarations: [
    TTTaskTaskPriorityLookupTableModalComponent,
    TTTaskSubtasksLookupTableModalComponent,
    TTTaskTaskHistoryLookupTableModalComponent,
    TTTaskTaskTypeLookupTableModalComponent,
		TaskPrioritiesComponent,

		ViewTaskPriorityModalComponent,
		CreateOrEditTaskPriorityModalComponent,
		TTTasksComponent,

		ViewTTTaskModalComponent,
		CreateOrEditTTTaskModalComponent,
        DashboardComponent
    ],
    providers: [
        { provide: BsDatepickerConfig, useFactory: NgxBootstrapDatePickerConfigService.getDatepickerConfig },
        { provide: BsDaterangepickerConfig, useFactory: NgxBootstrapDatePickerConfigService.getDaterangepickerConfig },
        { provide: BsLocaleService, useFactory: NgxBootstrapDatePickerConfigService.getDatepickerLocale }
    ]
})
export class MainModule { }
