import {NgModule} from '@angular/core';
import {AdminSharedModule} from '@app/admin/shared/admin-shared.module';
import {AppSharedModule} from '@app/shared/app-shared.module';
import {ConfirmEmailRoutingModule} from './confirm-email-routing.module';
import {ConfirmEmailComponent} from './confirm-email.component';

@NgModule({
    declarations: [ConfirmEmailComponent],
    imports: [AppSharedModule, AdminSharedModule, ConfirmEmailRoutingModule]
})
export class EmailConfirmModule {
}
