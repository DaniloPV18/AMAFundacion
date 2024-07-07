import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { VoluntarioListComponent } from './voluntario-list/voluntario-list.component';
import { VoluntarioIndexComponent } from './voluntario-index/voluntario-index.component';
import { VoluntarioCreateComponent } from './voluntario-create/voluntario-create.component';





const routes: Routes = [

     { path: '', component:VoluntarioIndexComponent}
];

@NgModule({
  imports: [ RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class VoluntarioRouteModule {}
