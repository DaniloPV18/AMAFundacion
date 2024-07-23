import { PrimengModule } from './primeng.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import {
  ConfirmationService,
  MessageService,
  ConfirmEventType,
} from 'primeng/api';

import { DropdownComponent } from './component/dropdown-component/dropdown-component.component';
import { PersonDialogComponet } from './component/person-dialog-componet/person-dialog-componet.component';
import { SpinnerComponent } from './component/spinner/spinner.component';
import { FormService } from './services/from.service';
import { ConfSystemServiceService } from '../data/conf-system-service.service';
import { ErrorDisplayComponent } from './component/ConfigSystem/error-display/error-display.component';
import { ToolsService } from '../services/tools.service';
import { TagModule } from 'primeng/tag';
import { BrigadeDialogComponent } from './component/brigade-dialog/brigade-dialog.component';

@NgModule({
  declarations: [
    DropdownComponent,
    PersonDialogComponet,
    ErrorDisplayComponent,
    SpinnerComponent,
    DropdownComponent,
    ErrorDisplayComponent,
    BrigadeDialogComponent,
    SpinnerComponent,
    PersonDialogComponet,
  ],
  imports: [CommonModule, ReactiveFormsModule, PrimengModule],
  exports: [
    CommonModule,
    ReactiveFormsModule,
    DropdownComponent,

    ErrorDisplayComponent,
    SpinnerComponent,
    PersonDialogComponet,
    TagModule,
    BrigadeDialogComponent,
    PrimengModule,
  ],
  providers: [
    FormService,
    ToolsService,
    ConfSystemServiceService,
    ConfirmationService,
    MessageService,
    ConfSystemServiceService,
  ],
})
export class SharedModule {}
