import { NgModule } from '@angular/core';
 
import { RouterModule, Routes } from '@angular/router';
import { authGuard } from '../../services/auth/auth.guard';


const routes: Routes = [
  {
    path: 'donacion',
    loadChildren: () => import('./../donation/donation.module').then((m) => m.DonationModule),
  },
  {
    path: 'crud-donante',
    loadChildren: () => import('./donor/donor.module').then((m) => m.DonorModule),
  },
  {
    path: 'crud-voluntario',
    loadChildren: () => import('./../voluntario/voluntario.module').then((m) => m.VoluntarioModule),
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
  ],
  exports: [RouterModule]
})
export class DonacionesRouteModule { }
