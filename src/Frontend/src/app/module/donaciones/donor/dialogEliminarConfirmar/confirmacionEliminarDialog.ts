import { Component } from '@angular/core';
import { DynamicDialogRef } from 'primeng/dynamicdialog';
import { DynamicDialogConfig } from 'primeng/dynamicdialog';

@Component({
  selector: 'app-confirmacion-eliminar-dialog',
  template: `
    <div>
      <h2>Confirmar Eliminación</h2>
      <p>¿Estás seguro de que deseas eliminar a {{ donorName }}?</p>
      <button pButton type="button" label="Cancelar" (click)="onNoClick()" class="p-button-secondary"></button>
      <button pButton type="button" label="Eliminar" (click)="onYesClick()" class="p-button-danger"></button>
    </div>
  `,
})
export class ConfirmacionEliminarDialog {
  donorName: string;

  constructor(public ref: DynamicDialogRef, public config: DynamicDialogConfig) {
    this.donorName = config.data.donorName;
  }

  onNoClick(): void {
    this.ref.close(false);
  }

  onYesClick(): void {
    this.ref.close(true);
  }
}
