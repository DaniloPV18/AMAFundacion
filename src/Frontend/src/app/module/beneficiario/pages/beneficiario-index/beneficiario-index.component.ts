import { Component } from '@angular/core';
import { beneficiarioFilter } from '../../interfaces/beneficiario-filter';
import { beneficiarioService } from '../../services/beneficiario.service';
import { beneficiarioCreateOrEditComponent } from '../beneficiario-create-or-edit/beneficiario-create-or-edit.component';
import { DialogService } from 'primeng/dynamicdialog';

@Component({
  selector: 'app-beneficiario-index',
  templateUrl: './beneficiario-index.component.html',
  styleUrl: './beneficiario-index.component.sass',
})

export class beneficiarioIndexComponent {
  isUpdateListDetails: boolean = false;
  openFilterPanel: boolean = false;
  entityFilterRequest: beneficiarioFilter | undefined;
  cambios: any;

  constructor(
    private dialogService: DialogService,
    private beneficiarioService: beneficiarioService
  ) {}

  NavigateToCreate() {
    this.dialogService
      .open(beneficiarioCreateOrEditComponent, {
        header: 'Crear beneficiario',
        width: '85%',
        height: 'auto',
        data: { update: false },
        baseZIndex: 10000,
      })
      .onClose.subscribe((result) => {
        if (result) {
          this.isUpdateListDetails = true;
        }
      });
  }

  openCloseFilter() {
    this.openFilterPanel = true;
  }

  changedFilter(event: any) {
    this.openFilterPanel = event;
  }

  getbeneficiarioRequestFilter(beneficiarioFiltr: beneficiarioFilter) {
    this.entityFilterRequest = beneficiarioFiltr;

    let beneficiarioFilter = Object.fromEntries(
      Object.entries(beneficiarioFiltr).filter(
        ([key, value]) => value !== '' && value !== null
      )
    );

    if (Object.keys(beneficiarioFilter).length !== 0) {
      beneficiarioFilter = { ...beneficiarioFilter, offset: 0, take: 10 };

      // console.log(beneficiarioFilter);

      this.beneficiarioService
        //@ts-ignore
        .getAllbeneficiarios(beneficiarioFilter)
        .subscribe(
          (result) => {
            this.cambios = {
              listabeneficiarios: result.result,
              totalRows: result.length,
              loading: false,
            };
          },
          (error) => {}
        );
    }
  }
}
