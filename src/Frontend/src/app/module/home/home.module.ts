import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeRouteModule } from './home.route.module';
import { IndexComponent } from './index/index.component';

@NgModule({
  declarations:[
    IndexComponent
  ],
  imports: [
    HomeRouteModule
  ],
  exports: [
    // RouterModule
  ],
})
export class HomeModule {}
