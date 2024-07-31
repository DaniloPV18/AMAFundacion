import {
  Component,
  Input,
  OnChanges,
  OnDestroy,
  OnInit,
  SimpleChanges,
} from '@angular/core';
import { CreateOrEditBrigadesComponent } from '../create-or-edit-brigades/create-or-edit-brigades.component';
import { DialogService } from 'primeng/dynamicdialog';
import { BrigadeFilter } from '../../models/brigada-filter.interface';
import { BrigadeDto } from '../../interfaces/brigade-dto';
import { BrigadeService } from '../../services/brigade.service';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Sort } from '../../../../core/interfaces/sort';

@Component({
  selector: 'app-list-brigades',
  templateUrl: './list-brigades.component.html',
  styleUrl: './list-brigades.component.sass',
})
export class ListBrigadesComponent implements OnInit, OnChanges {
  @Input() queryRequest: BrigadeFilter | undefined;
  @Input() isUpdateListDetails: boolean = false;
  @Input() searchFilter: any = {};

  DeleteData(brigade: BrigadeDto, event: Event) {
    this.confirmationService.confirm({
      target: event.target as EventTarget,
      message: '¿Estás seguro de realizar este proceso?',
      header: 'Confirmación',
      icon: 'pi pi-info-circle',
      acceptButtonStyleClass: 'p-button-danger p-button-text',
      rejectButtonStyleClass: 'p-button-text p-button-text',
      acceptIcon: 'none',
      rejectIcon: 'none',
      acceptLabel: 'Confirmar',
      rejectLabel: 'Cancelar',
      accept: () => {
        brigade.status = 'E'
        this.totalRows -= 1;
        this.deleteBrigade(brigade.id);
      },
      reject: () => {
        this.messageService.add({
          severity: 'warn',
          summary: '',
          detail: 'Registro no eliminado',
          life: 3000,
        });
      },
    });
  }

  EditData(brigade: BrigadeDto) {
    this.NavigateUpdate(brigade);
  }
  ViewData(brigade: BrigadeDto) {
    this.NavigateView(brigade);
  }
  NavigateView(brigade: any) {
    this.dialogService.open(CreateOrEditBrigadesComponent, {
      header: 'Ver Brigada',
      width: '85%',
      height: 'auto',
      data: { update: true, brigade: brigade, view: true },
      baseZIndex: 10000,
    });
  }
  loading: boolean = false;
  listaBrigadeas: BrigadeDto[] = [];
  totalRows: number = 0;
  brigadeFiler!: BrigadeFilter;
  constructor(
    private dialogService: DialogService,
    private brigadeService: BrigadeService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService
  ) {}
  ngOnInit(): void {
    this.getBrigade();
  }

  private handleUpdateListDetails() {
    this.getBrigade(); // Llamada a la función que obtiene las brigadas
  }
  ngOnChanges(changes: SimpleChanges): void {
    for (let change in changes) {
      if (change === 'isUpdateListDetails') {
        if (this.isUpdateListDetails) {
          this.handleUpdateListDetails();
        }
      }
      if (change === 'searchFilter') {
        if (changes[change].currentValue) {
          // console.log(changes[change].currentValue)
          this.listaBrigadeas = changes[change].currentValue.listabeneficiarios;
          this.totalRows = changes[change].currentValue.totalRows;
          this.loading = changes[change].currentValue.loading;
        }
      }
    }
  }
  private getBrigade() {
    this.brigadeFiler = {
      offset: 0,
      take: 10,
      sort: '',
    };

    this.brigadeService.getAllBrigades(this.brigadeFiler).subscribe(
      (result) => {
        this.listaBrigadeas = result.result;
        this.totalRows = result.length;
        this.loading = false;
      },
      (error) => {}
    );
  }
  NavigateUpdate(brigade: BrigadeDto) {
    this.dialogService
      .open(CreateOrEditBrigadesComponent, {
        header: 'Actualizar Brigada',
        width: '85%',
        height: 'auto',
        data: { update: true, brigade: brigade },
        baseZIndex: 10000,
      })

      .onClose.subscribe((result) => {
        if (result) {
          this.getBrigade();
        }
      });
  }
  loadDetailsLazy(event: any) {
    let sortCol = event.sortField;
    let sortColOrder = event.sortOrder;
    let offset = event.first;
    let take = event.rows;
    let sortStr = '';
    if (!(sortCol === undefined || sortCol === null)) {
      let sortArray: Sort[] = [];
      let sortObj: Sort = {
        selector: sortCol,
        desc: sortColOrder !== 1,
      };
      sortArray.push(sortObj);
      sortStr = JSON.stringify(sortArray);
    }

    this.brigadeFiler.sort = sortStr;
    this.brigadeFiler.take = take;
    this.brigadeFiler.offset = offset;
    this.brigadeService.getAllBrigades(this.brigadeFiler).subscribe(
      (result) => {
        this.listaBrigadeas = result.result;
        this.totalRows = result.length;
        this.loading = false;
      },
      (error) => {}
    );
  }

  private deleteBrigade(id: number) {
    this.brigadeService.deleteBrigade(id).subscribe({
      complete: () => {
        this.messageService.add({
          severity: 'success',
          summary: '',
          detail: 'Registro eliminado',
          life: 3000,
        });
      },
      error: () => {},
    });
  }
}
