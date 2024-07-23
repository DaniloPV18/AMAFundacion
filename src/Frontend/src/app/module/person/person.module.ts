import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PersonRoutingModule } from './person-routing.module';
 
import { RippleModule } from 'primeng/ripple';
import { TagModule } from 'primeng/tag';
import { PersonIndexComponent } from './pages/person-index/person-index.component';
import { PersonCreateOrEditComponent } from './pages/person-create-or-edit/person-create-or-edit.component';
import { PersonFilerComponent } from './pages/person-filer/person-filer.component';
import { PersonDetailsComponent } from './pages/person-details/person-details.component';
import { SharedModule } from '../../shared/shared.module';
 
 


@NgModule({
  declarations: [
    PersonIndexComponent,
    PersonCreateOrEditComponent,
    PersonFilerComponent,
    PersonDetailsComponent
  ],
  imports: [
    CommonModule,
    RippleModule,
    TagModule,
    CommonModule,
    SharedModule,
    RippleModule,
    TagModule,
    PersonRoutingModule
  ],
  exports: [
    PersonRoutingModule
  ]
  
})
export class PersonModule { }
