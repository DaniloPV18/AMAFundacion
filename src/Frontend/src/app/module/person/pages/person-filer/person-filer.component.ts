import { Component, EventEmitter, Input, OnInit, Output, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonFilter } from '../../interfaces/person-filter';
import { FormBuilder, FormGroup } from '@angular/forms';
import { FormService } from '../../../../shared/services/from.service';
import { PersonDto } from '../../interfaces/person-dto';
import { ResultPaged } from '../../../../core/interfaces/result';
import { PersonService } from '../../services/person.service'; // Asegúrate de que esta ruta sea correcta
import { HttpErrorResponse } from '@angular/common/http';


@Component({
 selector: 'app-person-filer',
  templateUrl: './person-filer.component.html',
  styleUrl: './person-filer.component.sass'
})
export class PersonFilerComponent implements OnInit {
  IsOpen: boolean = true;
  formFilterConsult!: FormGroup;
  formBrigadeFilter!: PersonFilter;
  @Output() queryEmitter = new EventEmitter<PersonFilter>();
  @Input() openContentReceiver: boolean = false;
  numeroPersona: number = 0;
  nombrePersona: string = '';
  identification: number = 0;

  constructor(private formService: FormService, private fb: FormBuilder) {
    this.buildForm();
  }

  ngOnInit(): void {
    this.clearFiltersEvent();
    this.buildForm();
  }

  ngOnChanges(changes: SimpleChanges): void {
    for (let propName in changes) {
      if (propName === 'openContentReceiver') {
        this.IsOpen = !this.IsOpen;
      }
    }
  }

  clearFiltersEvent() {
    if(this.formFilterConsult){
      this.formFilterConsult.reset();
      this.queryEmitter.emit({
        ...this.formFilterConsult.value,
        offset: 0,
        take: 10,
      })
    }
  }

  buildForm() {
    this.formBrigadeFilter = {
      offset: 0,
      take: 10,
      sort: '',
    };
    this.formFilterConsult = this.fb.group({
      numeroPersona: [null],
      nombrePersona: [''],
      identification: [null]
    });
  }

  search() {
    this.queryEmitter.emit(this.formFilterConsult.value);
  }

  cerrar() {
    this.IsOpen = false;
  }
}
