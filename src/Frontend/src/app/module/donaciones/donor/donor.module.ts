import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import { DonorFilterComponent } from './donor-filter/donor-filter.component';
import { DialogModule } from 'primeng/dialog';
import { MessageService } from 'primeng/api';
import { ConfirmationService } from 'primeng/api';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ToastModule } from 'primeng/toast';
import { DonorRouteModule } from './donor.route.module';
import { DonorListComponent } from './donor-list/donor-list.component';
import { DonorIndexComponent } from './donor-index/donor-index.component';
import { DonorCreateComponent } from './donor-create/donor-create.component';
@NgModule({
  declarations: [DonorIndexComponent, DonorListComponent, DonorCreateComponent,DonorFilterComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    DonorRouteModule,
    MatDialogModule,
    MatIconModule,
    TableModule,
    ButtonModule,
    DropdownModule,
    FormsModule,
    DialogModule,
    ToastModule,
    ConfirmDialogModule
    
  ],
  exports: [],
  providers: [MessageService,ConfirmationService],
  bootstrap: [],
})
export class DonorModule {}
