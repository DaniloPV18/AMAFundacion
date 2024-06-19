import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { beneficiarioRoutingModule } from './beneficiario-routing.module';
 
import { RippleModule } from 'primeng/ripple';
import { TagModule } from 'primeng/tag';
import { beneficiarioIndexComponent } from './pages/beneficiario-index/beneficiario-index.component';
import { beneficiarioCreateOrEditComponent } from './pages/beneficiario-create-or-edit/beneficiario-create-or-edit.component';
import { beneficiarioFilerComponent } from './pages/beneficiario-filer/beneficiario-filer.component';
import { beneficiarioDetailsComponent } from './pages/beneficiario-details/beneficiario-details.component';
import { SharedModule } from '../../shared/shared.module';
 

@NgModule({
  declarations: [
    beneficiarioIndexComponent,
    beneficiarioCreateOrEditComponent,
    beneficiarioFilerComponent,
    beneficiarioDetailsComponent
  ],
  imports: [
    CommonModule,
    RippleModule,
    TagModule,
    CommonModule,
    SharedModule,
    RippleModule,
    TagModule,
    beneficiarioRoutingModule
  ],
  exports: [
    beneficiarioRoutingModule
  ]
  
})
export class beneficiarioModule { }
