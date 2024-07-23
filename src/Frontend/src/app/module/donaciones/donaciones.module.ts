import { NgModule } from '@angular/core';
import { DonacionesRouteModule } from './donaciones.routes.module';
 
import { DonationModule } from '../donation/donation.module';
import { SharedModule } from 'primeng/api';
import { TagModule } from 'primeng/tag';

@NgModule({

  imports: [
    DonationModule,
    TagModule,
    SharedModule,
    DonacionesRouteModule
  ],
  exports: [DonacionesRouteModule],
})
export class DonacionesModule { }
