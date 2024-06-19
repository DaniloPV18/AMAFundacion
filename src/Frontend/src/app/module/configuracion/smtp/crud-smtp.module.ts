import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SmtpRouteModule } from './crud-smtp.route.module';
import { CommonModule } from '@angular/common';
import { SmtpAddComponent } from './smtp-add/smtp-add.component';
import { SmtpConfigurationService } from '../../../services/configuracion/smtp.service';
import { share } from 'rxjs';
import { SharedModule } from 'primeng/api';
@NgModule({
  declarations: [
    SmtpAddComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    SmtpRouteModule
    // HttpClientModule
  ],
  exports: [
    // SmtpRouteModule
  ],
providers:[SmtpConfigurationService]

})
export class SmtpModule { }
