import {Component, OnInit} from '@angular/core';
import {PersonFilter} from '../../interfaces/person-filter';
import {PersonCreateOrEditComponent} from '../person-create-or-edit/person-create-or-edit.component';
import {DialogService} from 'primeng/dynamicdialog';
import {PersonService} from '../../services/person.service';
import {ResultPaged} from "../../../../core/interfaces/result";
import {PersonDto} from "../../interfaces/person-dto";
import {HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-person-index',

  templateUrl: './person-index.component.html',
  styleUrl: './person-index.component.sass',
})
export class PersonIndexComponent implements OnInit {

  isUpdateListDetails: boolean = false;
  cambios: any;

  constructor(private dialogService: DialogService, private personService: PersonService) {
  }


  ngOnInit() {
    this.personService.createDonor$.subscribe(() => {
      this.NavigateToCreate();
    });
  }

  NavigateToCreate() {
    this.dialogService.open(PersonCreateOrEditComponent, {
      header: 'Crear Persona',
      width: '75%',
      height: '85%',
      data: {update: false},
      contentStyle: {'max-height': '500px', overflow: 'auto'},
      baseZIndex: 10000,
    }).onClose.subscribe((result) => {

      if (result) {
        this.isUpdateListDetails = true;
      }
    });
  }

  openFilterPanel: boolean = true;
  entityFilterRequest: PersonFilter | undefined;

  openCloseFilter() {
    this.openFilterPanel = !this.openFilterPanel;
  }

  getPersonRequestFilter(event: PersonFilter) {
    this.entityFilterRequest = event;
    let personFilter = Object.fromEntries(
      Object.entries(event).filter(
        ([key, value]) => value !== '' && value !== null
      )
    );
    if (Object.keys(personFilter).length !== 0) {
      const filterRequest = { ...personFilter, offset: 0, take: 10 } as PersonFilter;
      this.personService.getAllPersons(filterRequest).subscribe(
        (result: ResultPaged<PersonDto>) => {
          this.cambios = {
            listaPersona: result.result,
            totalRows: result.length,
            loading: false,
          };
        },
        (error: HttpErrorResponse) => { // Especificar el tipo 'HttpErrorResponse' para el parámetro 'error'
          console.error('Error:', error);
        }
      );
    }
  }

}
