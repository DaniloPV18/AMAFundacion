import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DonationIndexComponent } from './pages/donation-index/donation-index.component';
import { DonationCreateOrEditComponent } from './pages/donation-create-or-edit/donation-create-or-edit.component';

const routes: Routes = [
  {
    path: 'index',
    component: DonationIndexComponent,
  },
  {
    path: 'create',
    component: DonationCreateOrEditComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DonationRoutingModule {}
