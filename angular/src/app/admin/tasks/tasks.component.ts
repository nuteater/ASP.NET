import { NgModule, Component, Injector, Pipe, PipeTransform, enableProdMode } from '@angular/core';
import { NgModel } from "@angular/forms";
import {TasksServiceProxy, UserServiceProxy} from "@shared/service-proxies/service-proxies";
//import { Component, Injector, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';


@Component({
    templateUrl: './tasks.component.html',
    providers: [
        UserServiceProxy
    ]
})
export class TasksComponent extends AppComponentBase {
    constructor(
        injector: Injector,
        providers:[
            TasksServiceProxy
        ]
    ) {
        super(injector);
    }

    addTaskIdName(): void{

    }














    activeClassTab(){

    }
    // Add new task in list.
    /*
    idTask=0;
    colTas=0;
    Tasks: string[] = [];
    addTask(){
        this.Tasks[this.colTas++]='Task #'+this.idTask++;
    }
    // Delete task from list.
    dellTask(){

    }
    */
}





