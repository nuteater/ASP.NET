import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { Task_TaskTopicRoutingModule } from './task_TaskTopic-routing.module';
import { Task_TaskTopicsComponent } from './task_TaskTopics.component';
import { CreateOrEditTask_TaskTopicModalComponent } from './create-or-edit-task_TaskTopic-modal.component';
import { ViewTask_TaskTopicModalComponent } from './view-task_TaskTopic-modal.component';

@NgModule({
    declarations: [
        Task_TaskTopicsComponent,
        CreateOrEditTask_TaskTopicModalComponent,
        ViewTask_TaskTopicModalComponent,
    ],
    imports: [AppSharedModule, Task_TaskTopicRoutingModule, AdminSharedModule],
})
export class Task_TaskTopicModule {}
