import {
  Component,
  OnInit,
  Input,
  OnChanges,
  SimpleChange,
  SimpleChanges,
} from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { VoluntarioService } from '../voluntario.service';
import { VoluntarioCreateComponent } from '../../voluntario/voluntario-create/voluntario-create.component';
import { PersonService } from '../../person/services/person.service';
import { PersonDto } from '../../person/interfaces/person-dto';
import { PersonCreateOrEditComponent } from '../../person/pages/person-create-or-edit/person-create-or-edit.component';
import { PersonFilter } from '../../person/interfaces/person-filter';
import { Sort } from '../../../core/interfaces/sort';
import {
  ConfirmationService,
  MessageService,
  ConfirmEventType,
} from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
@Component({
  selector: 'app-voluntario-list',
  templateUrl: './voluntario-list.component.html',
  styleUrl: './voluntario-list.component.sass',
})
export class VoluntarioListComponent implements OnInit, OnChanges {
  @Input() isUpdateListDetails: boolean = false;

  voluntarioList: any[] = [];
  volunteerList: Volunteer[] = [];
  volunteerListFiltered: Volunteer[] = [];
  voluntarioListFiltered: any[] = [];
  voluntarioSeleccionado: any;

  loading: boolean = false;
  listaPersonas: PersonDto[] = [];
  totalRows: number = 0;
  personFiler!: PersonFilter;

  EditData(PersonDto: any) {
    this.NavigateUpdate(PersonDto);
  }
  constructor(
    private voluntarioService: VoluntarioService,
    private dialog: MatDialog,
    private dialogService: DialogService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private personService: PersonService
  ) {}

  ngOnInit() {
    this.getPerson();
    this.voluntarioService.getVoluntarioList().subscribe(
      (response: VoluntarioListResponse) => {
        this.voluntarioList = response.result;
      },
      (error) => {
        console.error('Error al obtener datos:', error);
      }
    );
  }

  handleUpdateListDetails() {
    this.getPerson(); // Llamada a la función que obtiene las personas
  }
  ngOnChanges(changes: SimpleChanges): void {
    console.log(changes);
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

    this.personService.getAllPersons(this.personFiler).subscribe(
      (result) => {
        this.listaPersonas = result.result;
        this.totalRows = result.length;
        this.loading = false;
      },
      (error) => {}
    );
  }

  NavigateUpdate(personDto: PersonDto) {
    this.dialogService
      .open(PersonCreateOrEditComponent, {
        header: 'Crear Voluntario',
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
    this.personService.getAllPersons(this.personFiler).subscribe(
      (result) => {
        this.listaPersonas = result.result;
        this.totalRows = result.length;
        this.loading = false;
      },
      (error) => {}
    );
  }

  private deletePerson(id: number) {
    this.personService.deletePerson(id).subscribe(
      (result) => {
        this.getPerson();
      },
      (error) => {}
    );
  }

  verDetalles(voluntario: any): void {
    voluntario.expandido = !voluntario.expandido;
  }

  private eliminarVoluntario(id: number) {
    this.voluntarioService.deleteVoluntario(id).subscribe(
      (result) => {
        //this.getPerson();
        this.messageService.add({
          severity: 'info',
          summary: 'Confirmado',
          detail: 'Voluntario eliminado exitosamente',
        });
      },
      (error) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: 'Error al eliminar el Voluntario',
        });
      }
    );
  }
  confirmacionEliminar(event: Event, voluntario: any) {
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
        console.log('eliminado');
        // this.eliminarVoluntario(volunter.id);
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
