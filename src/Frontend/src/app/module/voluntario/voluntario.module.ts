import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VoluntarioListComponent } from './voluntario-list/voluntario-list.component';
import { VoluntarioIndexComponent } from './voluntario-index/voluntario-index.component';
import { VoluntarioCreateComponent } from './voluntario-create/voluntario-create.component';
import { VoluntarioRouteModule } from './voluntario.route.module';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog'; import { MatIconModule } from '@angular/material/icon';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import { DialogModule } from 'primeng/dialog';

import { MessageService } from 'primeng/api';
import { ConfirmationService } from 'primeng/api';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ToastModule } from 'primeng/toast';

@NgModule({
  declarations: [VoluntarioIndexComponent,VoluntarioCreateComponent,VoluntarioListComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    VoluntarioRouteModule,
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
export class VoluntarioModule {}
