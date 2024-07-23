
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginContainerComponent } from './module/layout/login-container/login-container.component';
import { MainComponent } from './module/layout/main/main.component';
import { NotFoundComponent } from './module/home/not-found/not-found.component';
import {authGuard} from './services/auth/auth.guard';
import { PersonDialogComponet } from './shared/component/person-dialog-componet/person-dialog-componet.component';

const routes: Routes = [
  {
    path: '',
    component: MainComponent,
    loadChildren: () => import('./module/home/home.module').then((m) => m.HomeModule),
    canActivate: [authGuard]
  },
  {
    path: 'create',
    component:PersonDialogComponet,
  },
  {
    path: 'home',
    redirectTo: '',
    canActivate: [authGuard]
  },
  {
    path: 'donaciones',
    component: MainComponent,
    loadChildren: () => import('./module/donaciones/donaciones.module').then((m) => m.DonacionesModule),
    canActivate: [authGuard]
  },
  {
    path: 'configuracion',
    component: MainComponent,
    loadChildren: () => import('./module/configuracion/configuracion.module').then((m) => m.ConfiguracionModule),
    canActivate: [authGuard]
  },
   {
    path: 'brigate',
    component: MainComponent,
    loadChildren: () => import('./module/brigada/brigada.module').then((m) => m.BrigadaModule),
    canActivate: [authGuard]
  },
  // {
  //   path: 'donantes',
  //   component: MainComponent,
  //   loadChildren: () => import('./module/donor/donor.module').then((m) => m.DonorModule),
  // },
  // {
  //   path: 'voluntario',
  //   component: MainComponent,
  //   loadChildren: () => import('./module/voluntario/voluntario.module').then((m) => m.VoluntarioModule),
  // },
  {
    path: 'beneficiario',
    component: MainComponent,
    loadChildren: () => import('./module/beneficiario/beneficiario.module').then((m) => m.beneficiarioModule),
  },
  {
    path: 'auth',
    component: LoginContainerComponent,
    loadChildren: () => import('./module/auth/auth.module').then((m) => m.AuthModule),
  },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
})
export class AppRouteModule { }
