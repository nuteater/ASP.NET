import {NgModule, Component, Injector, Pipe, PipeTransform, enableProdMode, OnInit} from '@angular/core';
import { NgModel } from "@angular/forms";
import {TasksServiceProxy, UserServiceProxy} from "@shared/service-proxies/service-proxies";
//import { Component, Injector, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';


@Component({
    templateUrl: './tasks.component.html',
    providers: [
        TasksServiceProxy
    ]
})
export class TasksComponent extends AppComponentBase implements OnInit{


    _taskService: TasksServiceProxy;

    tasks: any;

    constructor(
        injector: Injector,
        taskService: TasksServiceProxy
    ) {
        super(injector);
        this._taskService = taskService;
    }

    ngOnInit(): void {
        this._taskService.getTasks().subscribe((data) => this.tasks = data.items);
    }

    addTaskIdName(): void{

    }

    tabsInit(taskId){

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





