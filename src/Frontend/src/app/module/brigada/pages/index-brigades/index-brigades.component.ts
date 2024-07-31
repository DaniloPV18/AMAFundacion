import {
  Component,
  EventEmitter,
  OnChanges,
  OnDestroy,
  OnInit,
  Output,
  SimpleChanges,
} from '@angular/core';
import { DialogService } from 'primeng/dynamicdialog';
import { CreateOrEditBrigadesComponent } from '../create-or-edit-brigades/create-or-edit-brigades.component';
import { BrigadeFilter } from '../../models/brigada-filter.interface';
import { BrigadeService } from '../../services/brigade.service';
import { FORMERR } from 'dns';

@Component({
  selector: 'app-index-brigades',
  templateUrl: './index-brigades.component.html',
  styleUrls: ['./index-brigades.component.sass'],
})
export class IndexBrigadesComponent implements OnInit {
  entityFilterRequest: BrigadeFilter | undefined;
  isUpdateListDetails: boolean = false;
  openFilterPanel = true;
  loading: boolean = false;
  cambios: any;

  constructor(
    private dialogService: DialogService,
    private brigadeService: BrigadeService
  ) {}

  ngOnInit(): void { }

  NavigateToCreate() {
    const refdialog = this.dialogService
      .open(CreateOrEditBrigadesComponent, {
        header: 'Crear Brigada',
        width: '85%',
        height: 'auto',
        data: {},
        baseZIndex: 10000,
      })
      .onClose.subscribe((result) => {
        if (result) {
          this.isUpdateListDetails = true;
        }
      });
  }

  openCloseFilter() {
    this.openFilterPanel = !this.openFilterPanel;
  }

  getBrigadaRequestFilter(event: BrigadeFilter) {
    this.entityFilterRequest = event;

    let beneficiarioFilter = Object.fromEntries(
      Object.entries(event).filter(
        ([key, value]) => value !== '' && value !== null
      )
    );

    if (Object.keys(beneficiarioFilter).length !== 0) {
      beneficiarioFilter = { ...beneficiarioFilter, offset: 0, take: 10 };

      // console.log(beneficiarioFilter);

      this.brigadeService
        //@ts-ignore
        .getAllBrigades(beneficiarioFilter)
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
