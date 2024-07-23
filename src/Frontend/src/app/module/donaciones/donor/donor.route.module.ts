import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DonorListComponent } from './donor-list/donor-list.component';
import { DonorIndexComponent } from './donor-index/donor-index.component';
import { DonorCreateComponent } from './donor-create/donor-create.component';
//import { NotFoundComponent } from './not-found/not-found.component';


const routes: Routes = [

     { path: '', component:DonorIndexComponent}
];

@NgModule({
  imports: [ RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DonorRouteModule {}
