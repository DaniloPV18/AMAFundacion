import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonFilerComponent } from '../person-filer/person-filer.component';
import { PersonFilter } from '../../interfaces/person-filter';
import { PersonCreateOrEditComponent } from '../person-create-or-edit/person-create-or-edit.component';
import { DialogService } from 'primeng/dynamicdialog';
import { PersonService } from '../../services/person.service';
@Component({
  selector: 'app-person-index',
  
  templateUrl: './person-index.component.html',
  styleUrl: './person-index.component.sass',
})
export class PersonIndexComponent implements OnInit{

  isUpdateListDetails:boolean = false;

  constructor(private dialogService: DialogService, private personDonorService: PersonService) {}


ngOnInit() {
    this.personDonorService.createDonor$.subscribe(() => {
      this.NavigateToCreate();
    });
  }
NavigateToCreate() {
  this.dialogService.open(PersonCreateOrEditComponent, {
    header: 'Crear Persona',
    width: '75%',
    height: '85%',
    data: {update: false},
    contentStyle: { 'max-height': '500px', overflow: 'auto' },
    baseZIndex: 10000,
    }).onClose.subscribe((result) => {

      if (result) {
        this.isUpdateListDetails=   true;
      }
    });
}
openFilterPanel: boolean = true;
entityFilterRequest: PersonFilter | undefined;

openCloseFilter() {
  this.openFilterPanel = !this.openFilterPanel;
}
getPersonRequestFilter($event: PersonFilter) {
  this.entityFilterRequest ={
    ...$event
  } 
}

}
