import { NgModule } from '@angular/core';
import { SmtpModule } from './smtp/crud-smtp.module';
import { ConfiguracionRouteModule } from './configuracion.routes.module';
import { CommonModule } from '@angular/common';

import { RippleModule } from 'primeng/ripple';
import { TagModule } from 'primeng/tag';
import { SharedModule } from '../../shared/shared.module';



@NgModule({
  imports: [
    SmtpModule,
    CommonModule,
    RippleModule,
    TagModule,
    SharedModule,
    ConfiguracionRouteModule,
  ],
  exports: [
     ConfiguracionRouteModule
  ],
// providers:[SmtpConfigurationService]

})
export class ConfiguracionModule {}
