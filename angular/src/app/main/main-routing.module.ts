import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TaskPrioritiesComponent } from './tasksNamespace/taskPriorities/taskPriorities.component';
import { TTTasksComponent } from './tasksNamespace/ttTasks/ttTasks.component';
import { DashboardComponent } from './dashboard/dashboard.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                children: [
                    { path: 'tasksNamespace/taskPriorities', component: TaskPrioritiesComponent, data: { permission: 'Pages.TaskPriorities' }  },
                    { path: 'tasksNamespace/ttTasks', component: TTTasksComponent, data: { permission: 'Pages.TTTasks' }  },
                    { path: 'dashboard', component: DashboardComponent, data: { permission: 'Pages.Tenant.Dashboard' } },
                    { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
                    { path: '**', redirectTo: 'dashboard' }
                ]
            }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class MainRoutingModule { }
