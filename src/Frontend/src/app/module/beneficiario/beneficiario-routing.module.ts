import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { beneficiarioIndexComponent } from './pages/beneficiario-index/beneficiario-index.component';

const routes: Routes = [
  {
    path: 'index',
    component: beneficiarioIndexComponent,
  },
  {
    path: 'create',
    component: beneficiarioIndexComponent,
  },
  {
    path: 'edit/:id',
    component: beneficiarioIndexComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class beneficiarioRoutingModule {}
