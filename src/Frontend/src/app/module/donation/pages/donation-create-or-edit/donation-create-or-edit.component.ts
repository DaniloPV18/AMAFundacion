import { ChangeDetectorRef, Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormGroup, Validators } from '@angular/forms';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { FormService } from '../../../../shared/services/from.service';
import { DonationService } from '../../services/donation.service';
import { ConfSystemServiceService } from '../../../../data/conf-system-service.service';
import { ChangeItemDropdown, ConfigurationDropdownProp, DynamicDataToDialog, ItemDropdown } from '../../../../core/interfaces/ItemDropdown.models';
import { TypeDonation } from '../../../../core/configSystem/type-donation';
import { DonationForm } from '../../interfaces/donation-form';
import { TextValidatorService } from '../../../../core/validators/text-validator.service';

@Component({
  selector: 'app-donation-create-or-edit',
  templateUrl: './donation-create-or-edit.component.html',
  styleUrls: ['./donation-create-or-edit.component.sass']
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

  constructor(
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig,
    private formService: FormService,
    private donationService: DonationService,
    private configService: ConfSystemServiceService,
    private cdr: ChangeDetectorRef,
    private readonly textValidatorService: TextValidatorService
  ) { }

  ngOnInit(): void {
    this.InitializeData();
  }

  InitializeData() {

    this.update = this.config.data.update;
    this.view = this.config.data.view;

    if (this.update) {
      this.label = 'Actualizar';
      this.buildFormData();
    } else {
      this.label = 'Crear';
      this.buildForm();
    }
    this.GetetTypeDonation();
    this.InitializerDataPerson();
    this.InitializerDataBrigade();
  }

  private buildFormData() {
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
    this.donationForm = this.formService.createFormGroup<DonationForm>(this.formData);
    this.validator();
  }

  private buildForm() {
    this.formData = {
      name: '',
      amount: 0,
      assignedAt: new Date(),

      donationTypeId: 0,
      price: 0,
      total: 0,
      personId: 0,
      brigadeId: 0
    };
    this.donationForm = this.formService.createFormGroup<DonationForm>(this.formData);
    this.validator();
  }

  private validator() {
    this.donationForm.get('name')?.setValidators([Validators.required]);
    this.donationForm.get('donationTypeId')?.setValidators([Validators.required, Validators.min(0)]);
    this.donationForm.get('personId')?.setValidators([Validators.required, Validators.min(0)]);
    this.donationForm.get('brigadeId')?.setValidators([Validators.required, Validators.min(0)]);
  }

  InitializerDataPerson() {
    this.lsPersona = { Params: [], dataFilter: { donor: true } };
    this.personaConfig = {
      Id: 'IdPersona',
      Name: 'Persona',
      Tooltip: 'Search Persona',
      Dataset: 'Persona',
      NameComponent: 'PersonDialogComponet'
    };
    this.itemsPersona = [];
    if (this.update || this.view) {
      this.itemsPersona.push({
        code: this.donationForm.get('personId')?.value,
        description: String(this.donationForm.get('identificationPerson')?.value)
          + '-' + String(this.donationForm.get('nameCompletedPerson')?.value)
      });
    }
  }

  InitializerDataBrigade() {
    this.lsBrigade = { Params: [] };
    this.brigadeConfig = {
      Id: 'IdBrigade',

      Name: 'Brigade',
      width: '40%',
      Tooltip: 'Search Brigade',
      Dataset: 'BrigadeDto',
      NameComponent: 'BrigadeDialogComponent'
    };
    this.itemsBrigade = [];
    if (this.update || this.view) {
      this.itemsBrigade.push({
        code: this.donationForm.get('brigadeId')?.value,
        description: String(
          this.donationForm.get('brigadeId')?.value)
          + '-' +
          String(this.donationForm.get('nameBrigade')?.value)
      });
    }
  }

  GetetTypeDonation() {
    this.configService.getTypeDonation().subscribe(
      (result) => {
        this.idDonationType = result;
        this.cdr.detectChanges();
      },
      (error) => {

      }
    );
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
    if (this.update) {
      this.Updatedonation();
      setTimeout(() => {
        this.isUpdateListDetails.emit(true);
        this.ref.close(this.donationForm.value);
      }, 1000);
    } else {
      this.Createdonation();
      setTimeout(() => {
        this.isUpdateListDetails.emit(true);
        this.ref.close(this.donationForm.value);
      }, 1000);

    }
  }

  async Createdonation() {
    try {
      await this.donationService.createdonation(this.donationForm.value).toPromise();
    } catch (error) {
      // Handle the error
    }
  }

  async Updatedonation() {
    try {
      await this.donationService.updatedonation(this.donationForm.value).toPromise();
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
      identificationTypeId: value // Actualiza el valor de identificationTypeId en el formulario
    });
  }

  calculateTotal(): number {
    const price = this.donationForm.get('price')?.value ?? 0;
    const amount = this.donationForm.get('amount')?.value ?? 0;
    return Math.abs(price * amount);
  }

  onInputNumberPositive = (event: any) => this.textValidatorService.preventNegativeNumbers(event);  
}
