import { ChangeDetectorRef, Component, EventEmitter, OnInit, Output } from '@angular/core';


import { PersonForm } from '../../interfaces/person-form';
import { FormGroup, Validators } from '@angular/forms';
import { FormService } from '../../../../shared/services/from.service';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { PersonService } from '../../services/person.service';
import { ConfSystemServiceService } from '../../../../data/conf-system-service.service';
import { TypeIdentification } from '../../../../core/configSystem/typeIdentification';



@Component({
  selector: 'app-person-create-or-edit',
  templateUrl: './person-create-or-edit.component.html',
  styleUrl: './person-create-or-edit.component.sass'
})
export class PersonCreateOrEditComponent  {

  @Output() isUpdateListDetails = new EventEmitter<boolean>();
  personForm!: FormGroup;
  formData!: PersonForm;
  volunteer: boolean = false;
  update: boolean = false;
  label: any = 'Crear';
  identificationTypes: TypeIdentification[] = [];
  loading: boolean = false;
  constructor(
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig,
    private formService: FormService
    , private personService: PersonService
    , private configService: ConfSystemServiceService

    , private cdr: ChangeDetectorRef) {
    this.InitializeData();


  }
  private buildFormData() {
    this.formData = {
      Id: this.config.data.person.id,
      firstName: '',
      secondName: '',
      lastName: '',
      secondLastName: '',

      
      email: '',
      donor: false,
      volunteer: false,
      identificationTypeId: '',
      identification: '',
      phone: '',

      ...this.config.data.person
     

    }
    this.personForm = this.formService.createFormGroup<PersonForm>(this.formData);
    this.validator();
  }

  ngOnInit(): void {
    this.InitializeData();
  }
  InitializeData() {
    this.update = this.config.data.update;
    this.getTypeIdentification();
    if (this.update) {
      this.label = 'Actualizar';
      this.buildFormData();
    } else {
      this.label = 'Crear';
      this.buildForm();
    }
    this.getTypeIdentification();
    this.validator();

  }
  getTypeIdentification() {
    this.configService.getTypeIdentification().subscribe((result) => {
      this.identificationTypes = result;
      
      this.cdr.detectChanges();
    }, (error) => {

    });
  }
  InputData() {
    if (this.update) {
      this.UpdatePerson();
      setTimeout(() => {
        this.isUpdateListDetails.emit(true);
        this.ref.close(this.personForm.value);
      }, 1000);
  
    } else {
      this.CreatePerson();
      setTimeout(() => {

        this.ref.close(this.personForm.value);
      }, 1000);
     
    }
  }

  
  async CreatePerson() {
    try {
      await this.personService.createPerson(this.personForm.value).toPromise();
      this.isUpdateListDetails.emit(true);
    } catch (error) {
      // Handle the error
    }
  }

  async UpdatePerson() {
    try {
      await this.personService.updatePerson(this.personForm.value).toPromise();
      // The HTTP request has completed
    } catch (error) {
      // Handle the error
    }
  }
  closeDialog() {
    this.ref.close();
  }

  onIdentificationTypeChange(value: any) {

    this.personForm.patchValue({
   
      identificationTypeId: value // Actualiza el valor de identificationTypeId en el formulario
    });
  }

  buildForm() {
    this.formData = {
 
      firstName: '',
      secondName: '',
      lastName: '',
      secondLastName: '',
 
      email: '',
      donor: false,
      volunteer: false,
      identificationTypeId: '',
      identification: '',
      phone: '',
      
 
    }
    this.personForm = this.formService.createFormGroup<PersonForm>(this.formData);

    
  }

  private validator() {
     
  }
}
