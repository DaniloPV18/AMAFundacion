import {
  ChangeDetectorRef,
  Component,
  EventEmitter,
  OnInit,
  Output,
} from '@angular/core';

import { beneficiarioForm } from '../../interfaces/beneficiario-form';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormService } from '../../../../shared/services/from.service';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { beneficiarioService } from '../../services/beneficiario.service';
import { ConfSystemServiceService } from '../../../../data/conf-system-service.service';
import { TypeIdentification } from '../../../../core/configSystem/typeIdentification';

@Component({
  selector: 'app-beneficiario-create-or-edit',
  templateUrl: './beneficiario-create-or-edit.component.html',
  styleUrl: './beneficiario-create-or-edit.component.sass',
})
export class beneficiarioCreateOrEditComponent {
  @Output() isUpdateListDetails = new EventEmitter<boolean>();
  beneficiarioForm!: FormGroup;
  formData!: beneficiarioForm;
  volunteer: boolean = false;
  update: boolean = false;
  view: boolean = false;
  label: any = 'Crear';
  identificationTypes: TypeIdentification[] = [];
  loading2: boolean = false;
  loading: boolean = false;
  constructor(
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig,
    private formService: FormService,
    private beneficiarioService: beneficiarioService,
    private configService: ConfSystemServiceService,
    private forBuild: FormBuilder,
    private cdr: ChangeDetectorRef
  ) {
    this.InitializeData();
  }
  private buildFormData() {
    const cleanBeneficiaryData = {
      ...this.config.data.beneficiario,
      description: this.config.data.beneficiario.description?.trim(),
    };
    this.formData = {
      id:
        this.config.data.beneficiario.id ||
        this.config.data.beneficiario.personId,
      ...cleanBeneficiaryData,
      ...this.config.data.beneficiario.person,
    };
    this.beneficiarioForm = this.formService.createFormGroup<beneficiarioForm>(
      this.formData
    );

    this.validator();
  }

  ngOnInit(): void {
    this.InitializeData();
  }
  InitializeData() {
    this.update = this.config.data.update;
    this.view = this.config.data.view;

    if (this.update) {
      this.label = 'Actualizar';
      this.buildFormData();
    } else if (this.view) {
      this.label = 'View';
      this.buildFormData();
    } else {
      this.label = 'Crear';
      this.buildForm();
    }
    this.getTypeIdentification();
    this.validator();
  }
  getTypeIdentification() {
    this.configService.getTypeIdentification().subscribe(
      (result) => {
        this.identificationTypes = result;

        this.cdr.detectChanges();
      },
      (error) => {}
    );
  }
  async InputData() {
    if (this.update) {
      await this.Updatebeneficiario();
      setTimeout(() => {
        // this.isUpdateListDetails.emit(true);
        this.loading = false;
        this.ref.close(this.beneficiarioForm.value);
      }, 1000);
    } else {
      await this.Createbeneficiario();
      setTimeout(() => {
        this.loading = false;
        this.ref.close(this.beneficiarioForm.value);
      }, 1000);
    }
  }

  structureData() {
    let datos = { ...this.beneficiarioForm.value };
    for (const key in datos) {
      if (key !== 'person' && datos[key] !== undefined) {
        datos.person[key] = datos[key];
        delete datos[key];
      }
    }

    datos = {
      description: this.beneficiarioForm.value.description,
      person: {
        ...datos.person,
        nameCompleted: `${datos.person.lastName} ${datos.person.secondLastName} ${datos.person.firstName} ${datos.person.secondName}`,
      },
    };
    return datos;
  }

  async Createbeneficiario() {
    try {
      let datos = this.structureData();
      this.loading = true;

      await this.beneficiarioService.createbeneficiario(datos).toPromise();
      this.isUpdateListDetails.emit(true);
    } catch (error) {
      // Handle the error
    }
  }

  async Updatebeneficiario() {
    try {
      let datos = this.structureData();

      this.loading = true;

      datos = {
        ...datos,
        id: this.beneficiarioForm.value.personId,
        personId: this.beneficiarioForm.value.personId,
      };
      await this.beneficiarioService.updatebeneficiario(datos).toPromise();
      this.isUpdateListDetails.emit(true);
      // The HTTP request has completed
    } catch (error) {
      // Handle the error
    }
  }
  closeDialog() {
    this.ref.close();
  }

  onIdentificationTypeChange(value: any) {
    this.beneficiarioForm.patchValue({
      identificationTypeId: value, // Actualiza el valor de identificationTypeId en el formulario
    });
  }

  buildForm() {
    this.formData = {
      description: '',
      // personId: 0,
      person: {
        firstName: '',
        secondName: '',
        lastName: '',
        secondLastName: '',
        email: '',
        identificationTypeId: '',
        identification: '',
        phone: '',
      },
    };

    let dataForm = {
      ...this.formData,
      ...this.formData.person,
    };

    this.beneficiarioForm =
      this.formService.createFormGroup<beneficiarioForm>(dataForm);
    this.validator();
  }

  private validator() {
    this.beneficiarioForm
      .get('description')
      ?.setValidators([
        Validators.required,
        Validators.pattern('^[a-zA-Z0-9 \\-_ñÑ]+$'),
      ]);
    this.beneficiarioForm
      .get('firstName')
      ?.setValidators([Validators.required, Validators.pattern('^[a-zA-Z]+$')]);
    this.beneficiarioForm
      .get('secondName')
      ?.setValidators([Validators.required, Validators.pattern('^[a-zA-Z]+$')]);
    this.beneficiarioForm
      .get('lastName')
      ?.setValidators([Validators.required, Validators.pattern('^[a-zA-Z]+$')]);
    this.beneficiarioForm
      .get('secondLastName')
      ?.setValidators([Validators.required, Validators.pattern('^[a-zA-Z]+$')]);
    this.beneficiarioForm
      .get('email')
      ?.setValidators([
        Validators.required,
        Validators.pattern('^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$'),
      ]);
    this.beneficiarioForm
      .get('identificationTypeId')
      ?.setValidators([Validators.required, Validators.pattern('[0-9]*')]);
    this.beneficiarioForm
      .get('identification')
      ?.setValidators([
        Validators.required,
        Validators.pattern('[0-9]*'),
        Validators.minLength(10),
      ]);
    this.beneficiarioForm
      .get('phone')
      ?.setValidators([
        Validators.required,
        Validators.pattern('[0-9]*'),
        Validators.minLength(10),
      ]);
  }
}
