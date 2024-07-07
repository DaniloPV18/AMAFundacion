import { Component, EventEmitter, Input, Output, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonFilter } from '../../interfaces/person-filter';
import { FormGroup } from '@angular/forms';
import { FormService } from '../../../../shared/services/from.service';
 

@Component({
  selector: 'app-person-filer', 
  templateUrl: './person-filer.component.html',
  styleUrl: './person-filer.component.sass'
})
export class PersonFilerComponent {
Buscar() {
throw new Error('Method not implemented.');
}
  IsOpen: boolean = true;
  formFilterConsult!: FormGroup;
  fomrBrigadeFilter!: PersonFilter;
  @Output() queryEmitter = new EventEmitter<PersonFilter>();
  @Input() openContentReceiver: boolean = false;



  constructor(private formService: FormService) {
    this.buildForm();
  }
  ngOnInit(): void {
    this.clearFiltersEvent();
    this.buildForm();  }
  ngOnChanges(changes: SimpleChanges): void {

    for (let propName in changes) {
       if (propName === 'openContentReceiver') {
        this.IsOpen = !this.IsOpen;
      }
    }
  }

  clearFiltersEvent() {
    this.formFilterConsult.reset();
    this.queryEmitter.emit(this.formFilterConsult.value);
  }

  buildForm() {
    this.fomrBrigadeFilter = {
      offset: 0,
      take: 10,
      sort: '',
  
    };
    this.formFilterConsult = this.formService.createFormGroup<PersonFilter>(this.fomrBrigadeFilter);
  }

}
