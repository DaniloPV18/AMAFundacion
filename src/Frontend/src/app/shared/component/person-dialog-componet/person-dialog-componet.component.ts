import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { DynamicDialogRef, DynamicDialogConfig } from 'primeng/dynamicdialog';
import { ItemDropdown } from '../../../core/interfaces/ItemDropdown.models';
import { PersonaDialogService } from './persona-dialog.service';
import { Sort } from '../../../core/interfaces/sort';
import { TextValidatorService } from '../../../core/validators/text-validator.service';
import { PersonDto } from '../../../module/person/interfaces/person-dto';
import { PersonFilter } from '../../../module/person/interfaces/person-filter';
import { ResultList } from '../../../core/interfaces/result';
import { Router } from '@angular/router';

@Component({
  selector: 'app-person-dialog-componet',

  templateUrl: './person-dialog-componet.component.html',
  styleUrl: './person-dialog-componet.component.sass'
})
export class PersonDialogComponet implements OnInit {
  irAPaginaCrearPersona() {

    this.router.navigate(['configuracion/person']);

    this.ref.close();
  }
  isFirstLoad: boolean = true;
  loading: boolean = false;
  totalRows: number = 0;
  lsPersona: PersonDto[] = [];
  codigosMessage: any;
  mensajesMessage: any;
selectionPerson?:PersonDto;
  constructor(private personaDialogService: PersonaDialogService
    , public ref: DynamicDialogRef
    , public config: DynamicDialogConfig
    , private router: Router
    , private messageService: MessageService
    , private readonly textValidatorService: TextValidatorService) {
  }

  ngOnInit(): void {

    let personaReq: PersonFilter = {
      ...(this.config.data.dataFilter ? this.config.data.dataFilter : {}),
      offset: 0,
      take: 10
    };

    this.getPersonaData(personaReq);
  }

  loadPersonaLazy(event: any) {
    if (this.isFirstLoad) {
      this.isFirstLoad = false;
      return;
    }

    let personaReq: PersonFilter = {
      ...(this.config.data.dataFilter ? this.config.data.dataFilter : {}),
      offset: event.first,
      take: event.rows,
      sort: ""
    };

    let sortCol = event.sortField;
    let sortColOrder = event.sortOrder;
    let sortStr = "";
    if (!(sortCol === undefined || sortCol === null)) {
      let sortArray: Sort[] = [];
      let sortObj: Sort = {
        selector: sortCol,
        desc: sortColOrder !== 1,
      };
      sortArray.push(sortObj);
      sortStr = JSON.stringify(sortArray);
    }
    personaReq.sort = sortStr;

    let filterObj = event.filters;
    if (filterObj.hasOwnProperty('DocumentoIdentidad')) {
      personaReq.identification = filterObj['DocumentoIdentidad']['value'];
    }
    if (filterObj.hasOwnProperty('Nombre')) {
      personaReq.firstName = filterObj['Nombre']['value'];
    }
    if (filterObj.hasOwnProperty('Apellido')) {
      personaReq.lastName = filterObj['Apellido']['value'];
    }

    this.getPersonaData(personaReq);
  }

  getPersonaData(request: PersonFilter) {
    [this.codigosMessage, this.mensajesMessage]
    this.loading = true;
    this.personaDialogService.getPaginated(request)
      .subscribe(
        {
          next: (data) => {
            let dataTmp = <ResultList<PersonDto>>data;
            if (dataTmp) {
              this.totalRows = dataTmp.length;
              this.lsPersona = dataTmp.result;

            }
          },
          error: (error) => {
            this.loading = false;
            if (error) {

            }
          },
          complete: () => {
            this.loading = false;
          }
        }
      );
  }

  onRowDblClick(event: any, dataSelected: any) {
    if (dataSelected) {
      let _description = ((dataSelected.identification) ? dataSelected.identification : "") + " - " +
        ((dataSelected.firstName) ? dataSelected.firstName : "") + " - " +
        ((dataSelected.lastName) ? dataSelected.lastName : "");
      let itemDropdown: ItemDropdown = {
        code: dataSelected.id,
        description: _description,
        dataSerialize: JSON.stringify(dataSelected)
      }
      this.ref.close(itemDropdown);
    }

  }

  onKeyDownLetters = (event: any) => this.textValidatorService.validateOnlyLetters(event);
  onKeyDownLettersAndNumbers = (event: any) => this.textValidatorService.validateOnlyLettersAndNumbers(event);
  onInput = (event: any) => this.textValidatorService.changeUppercase(event);
}
