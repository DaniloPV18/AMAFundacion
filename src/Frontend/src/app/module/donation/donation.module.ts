import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DonationRoutingModule } from './donation-routing.module';
import { DonationIndexComponent } from './pages/donation-index/donation-index.component';
import { DonationCreateOrEditComponent } from './pages/donation-create-or-edit/donation-create-or-edit.component';
import { DonationDetailsComponent } from './pages/donation-details/donation-details.component';
import { SharedModule } from '../../shared/shared.module';
import { DonationFilterComponent } from './pages/donation-filter/donation-filter.component';
import { DonationService } from './services/donation.service';


@NgModule({
  declarations: [DonationIndexComponent,
    DonationCreateOrEditComponent,
    DonationDetailsComponent,
    DonationFilterComponent

  ],
  imports: [
    CommonModule,
    DonationRoutingModule,
    SharedModule,
  ],
  providers: [DonationService]
})
export class DonationModule { }
