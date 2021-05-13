import {NgModule} from '@angular/core';
import {AdminSharedModule} from '@app/admin/shared/admin-shared.module';
import {AppSharedModule} from '@app/shared/app-shared.module';
import {DynamicEntityPropertiesRoutingModule} from './dynamic-entity-properties-routing.module';
import {DynamicEntityPropertyComponent} from './dynamic-entity-property.component';
import {CreateDynamicEntityPropertyModalComponent} from './create-dynamic-entity-property-modal.component';

@NgModule({
    declarations: [DynamicEntityPropertyComponent, CreateDynamicEntityPropertyModalComponent],
    imports: [AppSharedModule, AdminSharedModule, DynamicEntityPropertiesRoutingModule]
})
export class DynamicEntityPropertiesModule {
}
