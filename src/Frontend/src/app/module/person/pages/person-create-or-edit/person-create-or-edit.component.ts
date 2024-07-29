import {ChangeDetectorRef, Component, EventEmitter, Output} from '@angular/core';


import {PersonForm} from '../../interfaces/person-form';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {FormService} from '../../../../shared/services/from.service';
import {DynamicDialogConfig, DynamicDialogRef} from 'primeng/dynamicdialog';
import {PersonService} from '../../services/person.service';
import {ConfSystemServiceService} from '../../../../data/conf-system-service.service';
import {TypeIdentification} from '../../../../core/configSystem/typeIdentification';


@Component({
  selector: 'app-person-create-or-edit',
  templateUrl: './person-create-or-edit.component.html',
  styleUrl: './person-create-or-edit.component.sass'
})
export class PersonCreateOrEditComponent {

  @Output() isUpdateListDetails = new EventEmitter<boolean>();
  personForm!: FormGroup;
  formData!: PersonForm;
  volunteer: boolean = false;
  update: boolean = false;
  view: boolean = false;
  label: any = 'Crear';
  identificationTypes: TypeIdentification[] = [];
  loading: boolean = false;
  disableSubmit: boolean = false;

  constructor(
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig,
    private formService: FormService
    , private personService: PersonService
    , private configService: ConfSystemServiceService
    , private fb: FormBuilder
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
    this.view = this.config.data.view;

    this.getTypeIdentification();
    if (this.update) {
      this.label = 'Actualizar';
    } else {
      this.label = 'Crear';
      this.buildForm();
    }
    this.getTypeIdentification();
    if (this.update || this.view) {
      this.buildFormData();
    }
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
      this.disableSubmit = true;
      setTimeout(() => {
        this.isUpdateListDetails.emit(true);
        this.ref.close(this.personForm.value);
        this.disableSubmit = false;
      }, 1000);

    } else {
      this.CreatePerson();
      this.disableSubmit = true;
      setTimeout(() => {

        this.ref.close(this.personForm.value);
        this.disableSubmit = false;
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
    this.personForm = this.fb.group({
      firstName: [this.formData.firstName, [Validators.required]],
      secondName: [this.formData.secondName, [Validators.required]],
      lastName: [this.formData.lastName, [Validators.required]],
      secondLastName: [this.formData.secondLastName, [Validators.required]],
      email: [this.formData.email, [Validators.required, Validators.email]],
      identificationTypeId: [this.formData.identificationTypeId, [Validators.required]],
      identification: [this.formData.identification, [Validators.required, Validators.pattern(/^\d{10}$/), Validators.maxLength(10)]],
      phone: [this.formData.phone, [Validators.required, Validators.maxLength(10), Validators.minLength(9)]],
      donor: [this.formData.donor],
      volunteer: [this.formData.donor],
    });
  }

  private validator() {
    this.personForm.get('firstName')?.setValidators([Validators.required]);
    this.personForm.get('secondName')?.setValidators([Validators.required]);
    this.personForm.get('lastName')?.setValidators([Validators.required]);
    this.personForm.get('secondLastName')?.setValidators([Validators.required]);
    this.personForm.get('email')?.setValidators([Validators.required, Validators.email]);
    this.personForm.get('identificationTypeId')?.setValidators([Validators.required]);
    this.personForm.get('identification')?.setValidators([Validators.required, Validators.pattern(/^\d{10}$/), Validators.maxLength(10)]);
    this.personForm.get('phone')?.setValidators([Validators.required, Validators.maxLength(10), Validators.minLength(9)]);
  }

  getTypeIdentificationInput(): string {
    const selectedId = this.personForm.get('identificationTypeId')?.value;
    const selectedType = this.identificationTypes.find(type => type.id === selectedId);
    return selectedType ? selectedType.description : '';
  }
}
