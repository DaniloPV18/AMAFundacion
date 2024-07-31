import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { PersonService } from '../../services/person.service';
import { PersonFilter } from '../../interfaces/person-filter';
import { PersonDto } from '../../interfaces/person-dto';
import { PersonCreateOrEditComponent } from '../person-create-or-edit/person-create-or-edit.component';
import { DialogService } from 'primeng/dynamicdialog';
import { Sort } from '../../../../core/interfaces/sort';
@Component({
  selector: 'app-person-details',
  templateUrl: './person-details.component.html',
  styleUrl: './person-details.component.sass'
})
export class PersonDetailsComponent implements OnInit, OnChanges {
@Input() isUpdateListDetails:boolean = false;
@Input() searchFilter: any = {};
DeleteData(PersonDto: any) {
  this.deletePerson(PersonDto.id);
}
EditData(PersonDto: any) {
this.NavigateUpdate(PersonDto);
}
ViewData(PersonDto: any) {
  this.NavigateView(PersonDto);
}
  loading:boolean=false
  listaPersonas: PersonDto[]=[];
  totalRows: number=0;
  personFiler!:PersonFilter;
  constructor(private dialogService: DialogService,private personService: PersonService) {

  }
  ngOnInit(): void {
   this.getPerson();
  }
  handleUpdateListDetails() {
    this.getPerson();  // Llamada a la función que obtiene las personas
  }

  ngOnChanges(changes: SimpleChanges): void {
    console.log(changes);
    for(let change in changes){
      if(change==='isUpdateListDetails'){
        this.handleUpdateListDetails();
      }
      if (change === 'searchFilter') {
        if (changes[change].currentValue) {
          console.log(changes[change].currentValue);
          this.listaPersonas =
            changes[change].currentValue.listaPersona;
          this.totalRows = changes[change].currentValue.totalRows;
          this.loading = changes[change].currentValue.loading;
        }
      }
    }
  }

  NavigateUpdate(personDto: PersonDto) {
    this.dialogService.open(PersonCreateOrEditComponent, {
      header: 'Actualizar Persona',
      width: '85%',
      height: 'auto',
      data: {update: true, person:personDto },
      contentStyle: { 'max-height': '500px', overflow: 'auto' },
      baseZIndex: 10000,
    })
    .onClose.subscribe((result) => {
      if (result) {
       this.getPerson();
      }
    });
  }

  NavigateView(personDto: PersonDto) {
    this.dialogService.open(PersonCreateOrEditComponent, {
      header: 'Ver Persona',
      width: '85%',
      height: 'auto',
      data: { view: true, person: personDto},
      contentStyle: { 'max-height': '500px', overflow: 'auto' },
      baseZIndex: 10000,
    }) .onClose.subscribe((result) => {
      if (result) {
        this.getPerson();
      }
    });
  }

  private getPerson() {
    this.personFiler= {
      offset: 0,
      take: 10,
      sort: '',
    }

    this.personService.getAllPersons(this.personFiler).subscribe((result) => {
      this.listaPersonas = result.result;
      this.totalRows=result.length;
      this.loading=false;
    }, (error) => {

    });
  }


  loadDetailsLazy(event:any) {
    let sortCol = event.sortField;
    let sortColOrder = event.sortOrder;
    let offset = event.first;
    let take = event.rows;
    let sortStr = "";
    if (!(sortCol === undefined || sortCol ===null)){
      let sortArray: Sort[] = [];
      let sortObj: Sort ={
        selector: sortCol,
        desc: sortColOrder !== 1,
      };
      sortArray.push(sortObj);
      sortStr = JSON.stringify(sortArray);
    }

    this.personFiler.sort = sortStr;
    this.personFiler.take = take;
    this.personFiler.offset = offset;
    this.personService.getAllPersons(this.personFiler).subscribe((result) => {
      this.listaPersonas = result.result;
      this.totalRows=result.length;
      this.loading=false;
    }, (error) => {

    });
  }

  private deletePerson(id: number) {
    this.personService.deletePerson(id).subscribe((result) => {
      this.getPerson();
    }, (error) => {

    });
  }
}
