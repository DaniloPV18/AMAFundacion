import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IndexBrigadesComponent } from './pages/index-brigades/index-brigades.component';
import { CommonModule } from '@angular/common';

const routes: Routes = [

  { path: 'index', component: IndexBrigadesComponent}
];

@NgModule({
  imports: [CommonModule,RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BrigadaRoutingModule { }
