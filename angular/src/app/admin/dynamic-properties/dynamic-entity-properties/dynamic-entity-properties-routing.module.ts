import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {DynamicEntityPropertyComponent} from './dynamic-entity-property.component';

const routes: Routes = [{
    path: '',
    component: DynamicEntityPropertyComponent,
    pathMatch: 'full'
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class DynamicEntityPropertiesRoutingModule {
}
