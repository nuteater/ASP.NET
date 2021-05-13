import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Task_TaskTopicsComponent } from './task_TaskTopics.component';

const routes: Routes = [
    {
        path: '',
        component: Task_TaskTopicsComponent,
        pathMatch: 'full',
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class Task_TaskTopicRoutingModule {}
