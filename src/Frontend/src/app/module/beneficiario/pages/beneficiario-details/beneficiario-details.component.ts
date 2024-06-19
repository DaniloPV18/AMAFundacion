import {
  Component,
  Input,
  OnChanges,
  OnInit,
  SimpleChanges,
} from '@angular/core';
import { beneficiarioService } from '../../services/beneficiario.service';
import { beneficiarioFilter } from '../../interfaces/beneficiario-filter';
import { beneficiarioDto } from '../../interfaces/beneficiario-dto';
import { beneficiarioCreateOrEditComponent } from '../beneficiario-create-or-edit/beneficiario-create-or-edit.component';
import { DialogService } from 'primeng/dynamicdialog';
import { Sort } from '../../../../core/interfaces/sort';
import { ConfirmationService, MessageService } from 'primeng/api';

@Component({
  selector: 'app-beneficiario-details',
  templateUrl: './beneficiario-details.component.html',
  styleUrl: './beneficiario-details.component.sass',
})
export class beneficiarioDetailsComponent implements OnInit, OnChanges {
  @Input() isUpdateListDetails: boolean = false;
  @Input() searchFilter: any = {};

  loading: boolean = false;
  listabeneficiarios: beneficiarioDto[] = [];
  totalRows: number = 0;
  beneficiarioFiler!: beneficiarioFilter;

  constructor(
    private dialogService: DialogService,
    private beneficiarioService: beneficiarioService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService
  ) {}

  ngOnInit(): void {
    this.getbeneficiario();
  }

  DeleteData(beneficiarioDto: any, event: Event) {
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
        beneficiarioDto.person.status = 'E';
        this.totalRows -= 1;
        this.deletebeneficiario(beneficiarioDto.personId);
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

  EditData(beneficiarioDto: any) {
    this.NavigateUpdate(beneficiarioDto);
  }

  ViewData(beneficiarioDto: any) {
    this.NavigateView(beneficiarioDto);
  }

  handleUpdateListDetails() {
    this.getbeneficiario(); // Llamada a la función que obtiene las beneficiarios
  }

  ngOnChanges(changes: SimpleChanges): void {
    // console.log(changes);
    for (let change in changes) {
      if (change === 'isUpdateListDetails') {
        this.handleUpdateListDetails();
      }
      if (change === 'searchFilter') {
        if (changes[change].currentValue) {
          this.listabeneficiarios =
            changes[change].currentValue.listabeneficiarios;
          this.totalRows = changes[change].currentValue.totalRows;
          this.loading = changes[change].currentValue.loading;
        }
      }
    }
  }
  private getbeneficiario() {
    this.beneficiarioFiler = {
      offset: 0,
      take: 10,
      // sort: '',
    };

    this.beneficiarioService
      .getAllbeneficiarios(this.beneficiarioFiler)
      .subscribe(
        (result) => {
          this.listabeneficiarios = result.result;
          this.totalRows = result.length;
          this.loading = false;
        },
        (error) => {}
      );
  }

  NavigateUpdate(beneficiarioDto: beneficiarioDto) {
    this.dialogService
      .open(beneficiarioCreateOrEditComponent, {
        header: 'Editar beneficiario',
        width: '50%',
        height: '90%',
        data: { update: true, beneficiario: beneficiarioDto },
        contentStyle: { 'max-height': '650px', overflow: 'auto' },
        baseZIndex: 10000,
      })
      .onClose.subscribe((result) => {
        if (result) {
          this.getbeneficiario();
        }
      });
  }

  NavigateView(beneficiarioDto: beneficiarioDto) {
    this.dialogService
      .open(beneficiarioCreateOrEditComponent, {
        header: 'Detalles del beneficiario',
        width: '50%',
        height: '90%',
        data: { view: true, beneficiario: beneficiarioDto },
        contentStyle: { 'max-height': '550px', overflow: 'auto' },
        baseZIndex: 10000,
      })
      .onClose.subscribe((result) => {
        if (result) {
          this.getbeneficiario();
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

    this.beneficiarioFiler.sort = sortStr;
    this.beneficiarioFiler.take = take;
    this.beneficiarioFiler.offset = offset;
    this.beneficiarioService
      .getAllbeneficiarios(this.beneficiarioFiler)
      .subscribe(
        (result) => {
          this.listabeneficiarios = result.result;
          this.totalRows = result.length;
          this.loading = false;
        },
        (error) => {}
      );
  }

  private deletebeneficiario(id: number) {
    this.beneficiarioService.deletebeneficiario(id).subscribe({
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
