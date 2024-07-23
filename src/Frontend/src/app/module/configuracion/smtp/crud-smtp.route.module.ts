import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SmtpAddComponent } from './smtp-add/smtp-add.component';



const routes: Routes = [
  { path: '', component: SmtpAddComponent },
];


@NgModule({
  imports: [ RouterModule.forChild(routes)],
  // exports: [RouterModule],
})
export class SmtpRouteModule {}
