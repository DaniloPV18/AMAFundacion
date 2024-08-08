import { NgModule, isDevMode } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRouteModule } from './app.routes';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { HomeModule } from './module/home/home.module';
import { AuthModule } from './module/auth/auth.module';
import { LayoutModule } from './module/layout/layout.module';





import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { DonacionesModule } from './module/donaciones/donaciones.module';
import { MessageService } from 'primeng/api';

import { SharedModule } from './shared/shared.module';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpErrorInterceptorService } from './shared/services/http-error-interceptor.service';
import { HttpJwtInterceptorService } from './shared/services/http-jwt-interceptor.service';
import { ServiceWorkerModule } from '@angular/service-worker';

import { environment } from '../environments/environment';

@NgModule({
  declarations: [AppComponent],
  imports: [
    // AppComponent,
    FormsModule,
    BrowserModule,
    RouterModule,
    AppRouteModule,
    HomeModule,
    AuthModule,
    LayoutModule,
    SharedModule,
    ReactiveFormsModule,
    CommonModule,
    ServiceWorkerModule.register('ngsw-worker.js', {
      enabled: environment.production, //!isDevMode(),
      // enabled: !isDevMode(),
      // Register the ServiceWorker as soon as the application is stable
      // or after 30 seconds (whichever comes first).
      registrationStrategy: 'registerWhenStable:30000'
    }),
  ],
  providers: [   MessageService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpJwtInterceptorService,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpErrorInterceptorService,
      multi: true
    }

  ],
  exports: [AppRouteModule, SharedModule]
  ,
  bootstrap: [AppComponent],
})
export class AppModule {}
