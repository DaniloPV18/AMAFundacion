import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'users',
    loadChildren: () => import('./user/user.module').then((m) => m.UserModule)
  },
  {
    path: 'smtp',
    loadChildren: () => import('./smtp/crud-smtp.route.module').then((m) => m.SmtpRouteModule)
  },
  {
    path: 'person',
    loadChildren: () => import('../person/person.module').then((m) => m.PersonModule)
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ]
})
export class ConfiguracionRouteModule { }
