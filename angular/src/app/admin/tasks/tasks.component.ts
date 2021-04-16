import { NgModule, Component, Injector, Pipe, PipeTransform, enableProdMode } from '@angular/core';
//import { Component, Injector, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { BrowserModule } from '@angular/platform-browser';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { DxDataGridModule,
    DxBulletModule,
    DxTemplateModule } from 'devextreme-angular';
import DataSource from 'devextreme/data/data_source';

interface Food {
    value: string;
    viewValue: string;
}

@Component({
    templateUrl: './tasks.component.html',
    animations: [appModuleAnimation()]
})
export class TasksComponent extends AppComponentBase {
    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    activeClassTab(){

    }

    foods: Food[] = [
        {value: 'steak-0', viewValue: 'Steak'},
        {value: 'pizza-1', viewValue: 'Pizza'},
        {value: 'tacos-2', viewValue: 'Tacos'}
    ];


}
