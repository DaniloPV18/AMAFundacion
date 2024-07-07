import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { UserRouteModule } from './user.route.module';
import { UserListComponent } from './user-list/user-list.component';
import { SharedModule } from '../../../shared/shared.module';
import { UserListDetailComponent } from './user-list-detail/user-list-detail.component';
import { ConfirmationService } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
import { ConfirmDialog } from 'primeng/confirmdialog';
import { UserFormComponent } from './user-form/user-form.component';
@NgModule({
  declarations:[
     UserListComponent,
     UserListDetailComponent,
     UserFormComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    SharedModule
  ],
  exports: [
    UserRouteModule
  ],
  providers:[ConfirmationService],
})
export class UserModule {}
