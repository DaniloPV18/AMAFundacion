import {
  Component,
  OnChanges,
  OnInit,
  Input,
  SimpleChanges,
} from '@angular/core';
import { DonorService } from '../donor.service';
import { DonorCreateComponent } from '../donor-create/donor-create.component';
import { FilterService } from '../filter.service';
import { PersonFilter } from '../../../person/interfaces/person-filter';
import { PersonDto } from '../../../person/interfaces/person-dto';
import { PersonCreateOrEditComponent } from '../../../person/pages/person-create-or-edit/person-create-or-edit.component';
import { PersonService } from '../../../person/services/person.service';
import { Sort } from '../../../../core/interfaces/sort';
import { DialogService } from 'primeng/dynamicdialog';
import {
  ConfirmationService,
  MessageService,
  ConfirmEventType,
} from 'primeng/api';

@Component({
  selector: 'app-donor-list',
  templateUrl: './donor-list.component.html',
  styleUrls: ['./donor-list.component.sass'],
})
export class DonorListComponent implements OnInit, OnChanges {
  @Input() isUpdateListDetails: boolean = false;

  EditData(PersonDto: any) {
    this.NavigateUpdate(PersonDto);
  }

  loading: boolean = false;
  listaPersonas: PersonDto[] = [];
  totalRows: number = 0;
  personFiler!: PersonFilter;

  donorList: any[] = [];
  donorListFiltered: any[] = [];
  donanteSeleccionado: any;

  numeroDeClicks = 0;

  constructor(
    private filterService: FilterService,
    private donorService: DonorService,
    private dialogService: DialogService,
    private personService: PersonService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService
  ) {}

  ngOnInit(): void {

    this.Cargar_datos();
  }
  Cargar_datos(): void{
    this.getPerson();

    this.donorService.getDonorList().subscribe({
      next: (response) => {
        this.donorList = response.result;
        this.filterService.filtro$.subscribe((filtros) => {
          this.aplicarFiltros(filtros);
        });

        this.aplicarFiltros({ nombreFiltro: '', numeroFiltro: null });
      },
      error: (error) => {
        console.error('Error al obtener datos:', error);
      },
    });
  }
  handleUpdateListDetails() {
    this.getPerson();
  }
  ngOnChanges(changes: SimpleChanges): void {
    for (let change in changes) {
      if (change === 'isUpdateListDetails') {
        this.handleUpdateListDetails();
      }
    }
  }
  private getPerson() {
    this.personFiler = {
      offset: 0,
      take: 10,
      sort: '',
    };

    this.personService.getAllPersons(this.personFiler).subscribe({
      next: (result) => {
        this.listaPersonas = result.result;
        this.totalRows = result.length;
        this.loading = false;
      },
      error: (error) => {},
    });
  }
  NavigateUpdate(personDto: PersonDto) {
    this.dialogService
      .open(PersonCreateOrEditComponent, {
        header: 'Crear Donante',
        width: '75%',
        height: '85%',
        data: { update: true, person: personDto },
        contentStyle: { 'max-height': '500px', overflow: 'auto' },
        baseZIndex: 10000,
      })
      .onClose.subscribe((result) => {
        if (result) {
          this.getPerson();
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

    this.personFiler.sort = sortStr;
    this.personFiler.take = take;
    this.personFiler.offset = offset;
    this.personService.getAllPersons(this.personFiler).subscribe({
      next: (result) => {
        this.listaPersonas = result.result;
        this.totalRows = result.length;
        this.loading = false;
      },
      error: (error) => {},
    });
  }

  aplicarFiltros(filtros: any) {
    const { nombreFiltro, numeroFiltro } = filtros;

    this.donorListFiltered = this.donorList.filter((donor) => {
      const nombreMatch =
        !nombreFiltro ||
        this.removerTildes(donor.nombreCompleto.toLowerCase()).includes(
          this.removerTildes(nombreFiltro.toLowerCase())
        );

      const numeroMatch =
        !numeroFiltro ||
        donor.identificacion.toString().includes(numeroFiltro.toString());

      return nombreMatch && numeroMatch;
    });
  }

  private removerTildes(str: string): string {
    return str.normalize('NFD').replace(/[\u0300-\u036f]/g, '');
  }

  private eliminarDonante(id: number) {
    this.donorService.deleteDonor(id).subscribe({
      next: (result) => {
        //this.getPerson();
        this.Cargar_datos();
        this.messageService.add({
          severity: 'info',
          summary: 'Confirmado',
          detail: 'Donante eliminado exitosamente',
        });
      },
      error: (error) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: 'Error al eliminar el donante',
        });
      },
    });
  }

  confirmacionEliminar(event: Event, donor: any) {
    this.numeroDeClicks++;
    this.confirmationService.confirm({
      target: event.target as EventTarget,
      message: '¿Desea eliminar este registro?',
      header: 'Confirmación de Eliminación',
      icon: 'pi pi-info-circle',
      acceptButtonStyleClass: 'p-button-danger p-button-text',
      rejectButtonStyleClass: 'p-button-text p-button-text',
      acceptIcon: 'none',
      rejectIcon: 'none',
      accept: () => {
       this.totalRows -= 1;
       this.eliminarDonante(donor.personId);
      },
      reject: () => {
        this.messageService.add({
          severity: 'error',
          summary: 'Rechazado',
          detail: 'Eliminación Cancelada',
        });
      },
    });
  }
}
