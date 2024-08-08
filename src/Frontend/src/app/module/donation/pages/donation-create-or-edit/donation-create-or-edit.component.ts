import {
  ChangeDetectorRef,
  Component,
  EventEmitter,
  OnInit,
  Output,
} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { FormService } from '../../../../shared/services/from.service';
import { DonationService } from '../../services/donation.service';
import { ConfSystemServiceService } from '../../../../data/conf-system-service.service';
import {
  ChangeItemDropdown,
  ConfigurationDropdownProp,
  DynamicDataToDialog,
  ItemDropdown,
} from '../../../../core/interfaces/ItemDropdown.models';
import { TypeDonation } from '../../../../core/configSystem/type-donation';
import { DonationForm } from '../../interfaces/donation-form';

@Component({
  selector: 'app-donation-create-or-edit',
  templateUrl: './donation-create-or-edit.component.html',
  styleUrls: ['./donation-create-or-edit.component.sass'],
})
export class DonationCreateOrEditComponent implements OnInit {
  personaConfig!: ConfigurationDropdownProp;
  @Output() isUpdateListDetails = new EventEmitter<boolean>();
  lsPersona!: DynamicDataToDialog;
  itemsPersona: ItemDropdown[] = [];

  brigadeConfig!: ConfigurationDropdownProp;
  lsBrigade!: DynamicDataToDialog;
  itemsBrigade: ItemDropdown[] = [];

  donationForm!: FormGroup;
  formData!: DonationForm;
  update: boolean = false;
  label: any = 'Crear';
  idDonationType: TypeDonation[] = [];
  loading: boolean = false;
  view: boolean = false;
  disableSubmit: boolean = false;

  constructor(
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig,
    private formService: FormService,
    private donationService: DonationService,
    private configService: ConfSystemServiceService,
    private cdr: ChangeDetectorRef,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.InitializeData();
    this.donationForm.get('price')?.valueChanges.subscribe({
      next: (price) => {
        const amount = this.donationForm.get('amount')?.value ?? 0;
        const total = (price ?? 0) * amount;
        this.donationForm.get('total')?.setValue(total.toFixed(2));
      },
    });

    this.donationForm.get('amount')?.valueChanges.subscribe({
      next: (amount) => {
        const price = this.donationForm.get('price')?.value ?? 0;
        const total = (amount ?? 0) * price;
        this.donationForm.get('total')?.setValue(total.toFixed(2));
      },
    });
  }

  InitializeData() {
    this.update = this.config.data.update;
    this.view = this.config.data.view;

    if (this.update) {
      this.label = 'Actualizar';
      this.buildFormUpdate();
    } else {
      this.label = 'Crear';
      this.buildFormCreated();
    }
    this.GetetTypeDonation();
    this.InitializerDataPerson();
    this.InitializerDataBrigade();
  }

  private buildFormUpdate() {
    this.formData = {
      name: '',
      amount: 0,
      donationTypeId: 0,
      price: 0,
      total: 0,
      personId: 0,
      brigadeId: 0,

      ...this.config.data.donation,
      assignedAt: new Date(this.config.data.donation.assignedAt),
    };
    this.donationForm = this.formService.createFormGroup<DonationForm>(
      this.formData
    );
    this.validator();
  }

  private buildFormCreated() {
    this.formData = {
      name: '',
      amount: 0,
      assignedAt: new Date(),
      donationTypeId: 0,
      price: 0,
      total: 0,
      personId: 0,
      brigadeId: 0,
    };

    this.donationForm = this.fb.group({
      name: [this.formData.name, [Validators.required]],
      assignedAt: [this.formData.assignedAt, [Validators.required]],
      amount: [
        this.formData.amount,
        [Validators.required, Validators.pattern('[0-9]*'), Validators.min(1)],
      ],
      donationTypeId: [
        this.formData.donationTypeId,
        [Validators.required, Validators.pattern('[0-9]*'), Validators.min(1)],
      ],
      personId: [
        this.formData.personId,
        [Validators.required, Validators.pattern('[0-9]*'), Validators.min(1)],
      ],
      brigadeId: [
        this.formData.brigadeId,
        [Validators.required, Validators.pattern('[0-9]*'), Validators.min(1)],
      ],
      price: [
        this.formData.price,
        [
          Validators.required,
          Validators.pattern('^\\d+(\\.\\d{1,2})?$'),
          Validators.min(0.1),
        ],
      ],
      total: [
        this.formData.total,
        [
          Validators.required,
          Validators.pattern('^\\d+(\\.\\d{1,2})?$'),
          Validators.min(0.1),
        ],
      ],
    });
  }

  private validator() {
    this.donationForm.get('name')?.setValidators([Validators.required]);
    this.donationForm
      .get('donationTypeId')
      ?.setValidators([Validators.required, Validators.min(0)]);
    this.donationForm
      .get('personId')
      ?.setValidators([Validators.required, Validators.min(0)]);
    this.donationForm
      .get('brigadeId')
      ?.setValidators([Validators.required, Validators.min(0)]);
    this.donationForm
      .get('price')
      ?.setValidators([
        Validators.required,
        Validators.pattern('^\\d+(\\.\\d{1,2})?$'),
        Validators.min(0.1),
      ]);
    this.donationForm
      .get('amount')
      ?.setValidators([
        Validators.required,
        Validators.pattern('[0-9]*'),
        Validators.min(1),
      ]);
  }

  InitializerDataPerson() {
    this.lsPersona = { Params: [], dataFilter: { donor: true } };
    this.personaConfig = {
      Id: 'IdPersona',
      Name: 'Persona',
      Tooltip: 'Search Persona',
      Dataset: 'Persona',
      NameComponent: 'PersonDialogComponet',
    };
    this.itemsPersona = [];
    if (this.update || this.view) {
      this.itemsPersona.push({
        code: this.donationForm.get('personId')?.value,
        description:
          String(this.donationForm.get('identificationPerson')?.value) +
          '-' +
          String(this.donationForm.get('nameCompletedPerson')?.value),
      });
    }
  }

  InitializerDataBrigade() {
    this.lsBrigade = { Params: [] };
    this.brigadeConfig = {
      Id: 'IdBrigade',
      Name: 'Brigade',
      Tooltip: 'Search Brigade',
      Dataset: 'BrigadeDto',
      NameComponent: 'BrigadeDialogComponent',
    };
    this.itemsBrigade = [];
    if (this.update || this.view) {
      this.itemsBrigade.push({
        code: this.donationForm.get('brigadeId')?.value,
        description:
          String(this.donationForm.get('brigadeId')?.value) +
          '-' +
          String(this.donationForm.get('nameBrigade')?.value),
      });
      if (this.view) {
        this.donationForm.get('donationTypeId')?.disable();
      }
    }
  }

  GetetTypeDonation() {
    this.configService.getTypeDonation().subscribe({
      next: (result) => {
        this.idDonationType = result;
        this.cdr.detectChanges();
      },
      error: (error) => {},
    });
  }

  onItemChanged(eventData: ChangeItemDropdown) {
    if (eventData && eventData.conf.Id === 'IdPersona') {
      this.donationForm.get('personId')?.setValue(eventData.data.code);
    }
  }

  onItemChangedBrigade(eventData: ChangeItemDropdown) {
    if (eventData && eventData.conf.Id === 'IdBrigade') {
      this.donationForm.get('brigadeId')?.setValue(eventData.data.code);
    }
  }

  InputData() {
    this.disableSubmit = true;
    if (this.update) {
      this.updateDonation();
    } else {
      this.createDonation();
    }
  }

  async createDonation() {
    try {
      this.donationService.createdonation(this.donationForm.value).subscribe({
        next: () => {
          this.isUpdateListDetails.emit(true);
          this.ref.close(this.donationForm.value);
          this.disableSubmit = false;
        },
      });
    } catch (error) {
      // Handle the error
    }
  }

  updateDonation() {
    try {
      this.donationService.updatedonation(this.donationForm.value).subscribe({
        next: () => {
          this.isUpdateListDetails.emit(true);
          this.ref.close(this.donationForm.value);
          this.disableSubmit = false;
        },
      });

      // The HTTP request has completed
    } catch (error) {
      // Handle the error
    }
  }

  closeDialog() {
    this.ref.close();
  }

  valorDate(field: string) {
    const fieldValue = this.donationForm.get(field)?.value;
    if (fieldValue instanceof Date) {
      // Formatear la fecha utilizando toLocaleDateString
      return fieldValue.toLocaleDateString('en-US', {
        month: '2-digit',
        day: '2-digit',
        year: 'numeric',
      });
      // Si no es una fecha, devolver el valor sin formatear
    }
    return fieldValue || '';
  }

  onIdentificationTypeChange(value: any) {
    this.donationForm.patchValue({
      identificationTypeId: value, // Actualiza el valor de identificationTypeId en el formulario
    });
  }

  onInputChange(event: Event, form: string) {
    const input = event.target as HTMLInputElement;
    input.value = input.value.replace(/[^0-9]/g, '');
    this.donationForm.get(form)?.setValue(input.value);
  }

  updateTotal() {
    const price = parseFloat(this.donationForm.get('price')?.value || 0);
    const amount = parseInt(this.donationForm.get('amount')?.value || 0, 10);
    const total = (price * amount).toFixed(2);
    this.donationForm.get('total')?.setValue(total);
  }

  getDonationTypeName(): string {
    const selectedId = this.donationForm.get('donationTypeId')?.value;
    const selectedType = this.idDonationType.find(
      (type) => type.id === selectedId
    );
    return selectedType ? selectedType.name : '';
  }
}
