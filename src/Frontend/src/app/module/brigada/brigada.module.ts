import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BrigadaRoutingModule } from './brigada-routing.module';
import { SharedModule } from '../../shared/shared.module';
import { IndexBrigadesComponent } from './pages/index-brigades/index-brigades.component';
import { RippleModule } from 'primeng/ripple';
import { TagModule } from 'primeng/tag';
import { CreateOrEditBrigadesComponent } from './pages/create-or-edit-brigades/create-or-edit-brigades.component';
import { ListBrigadesComponent } from './pages/list-brigades/list-brigades.component';
import { FilterBrigadesComponent } from './pages/filter-brigades/filter-brigades.component';
import { BrigadeService } from './services/brigade.service';


@NgModule({
  declarations: [
    IndexBrigadesComponent,
 
    FilterBrigadesComponent,
    ListBrigadesComponent,
    CreateOrEditBrigadesComponent,
  ],
  imports: [
 
 
    BrigadaRoutingModule,
    SharedModule,
  ],
  exports: [
    BrigadaRoutingModule
  ],
  providers: [BrigadeService],
 
})
export class BrigadaModule {}
