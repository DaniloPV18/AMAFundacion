import {
  ChangeDetectorRef,
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
  SimpleChanges,
} from '@angular/core';
import { DonationFilter } from '../../interfaces/donation-filter';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormService } from '../../../../shared/services/from.service';
import {
  ChangeItemDropdown,
  ConfigurationDropdownProp,
  DynamicDataToDialog,
  ItemDropdown,
} from '../../../../core/interfaces/ItemDropdown.models';
import { ConfSystemServiceService } from '../../../../data/conf-system-service.service';
import { TypeDonation } from '../../../../core/configSystem/type-donation';

@Component({
  selector: 'app-donation-filter',

  templateUrl: './donation-filter.component.html',
  styleUrl: './donation-filter.component.sass',
})
export class DonationFilterComponent implements OnInit, OnChanges {
  personaConfig!: ConfigurationDropdownProp;
  itemsPersona!: ItemDropdown[];
  lsPersona!: DynamicDataToDialog;
  idDonationType: TypeDonation[] = [];

  onItemChanged(eventData: ChangeItemDropdown) {
    if (eventData && eventData.conf.Id === 'idPersona') {
      this.formFilterConsult.get('personId')?.setValue(eventData.data.code);
    }
  }

  @Output() queryEmitter = new EventEmitter<DonationFilter>();
  @Input() openContentReceiver: boolean = false;

  IsOpen: boolean = false;
  formFilterConsult!: FormGroup;
  fomrDonationFilter!: DonationFilter;

  constructor(
    private formService: FormService,
    private configService: ConfSystemServiceService,
    private cdr: ChangeDetectorRef,
    private fb: FormBuilder
  ) {}

  GetetTypeDonation() {
    this.configService.getTypeDonation().subscribe({
      next: (result) => {
        this.idDonationType = result;
        this.cdr.detectChanges();
      },
      error: (error) => {},
    });
  }

  ngOnInit(): void {
    this.clearFiltersEvent();
    this.buildForm();
    this.InitializerData();
    this.GetetTypeDonation();
  }

  ngOnChanges(changes: SimpleChanges): void {
    for (let propName in changes) {
      if (propName === 'openContentReceiver') {
        this.IsOpen = !this.IsOpen;
      }
    }
  }

  search() {
    this.queryEmitter.emit(this.formFilterConsult.value);
  }

  clearFiltersEvent() {
    if (this.formFilterConsult) {
      this.formFilterConsult.reset();
      this.queryEmitter.emit({
        ...this.formFilterConsult.value,
        offset: 0,
        take: 10,
      });
    }
    this.itemsPersona = [];
  }

  closed() {
    this.clearFiltersEvent();
    this.IsOpen = !this.IsOpen;
  }

  InitializerData() {
    this.lsPersona = { Params: [], dataFilter: { donor: true } };
    this.personaConfig = {
      Id: 'idPersona',
      Name: 'Persona',
      Tooltip: 'Search Persona',
      Dataset: 'Persona',
      NameComponent: 'PersonDialogComponet',
    };
    this.itemsPersona = [];
  }

  buildForm() {
    this.fomrDonationFilter = {
      id: undefined,
      name: undefined,
      donationTypeId: undefined,
      personId: undefined,
      brigadeId: undefined,
      offset: 0,
      take: 10,
      sort: '',
    };

    this.formFilterConsult = this.fb.group({
      id: [this.fomrDonationFilter.id, [Validators.pattern('[0-9]*')]],
      name: [this.fomrDonationFilter.name],
      personId: [
        this.fomrDonationFilter.personId,
        [Validators.pattern('[0-9]*')],
      ],
    });
  }

  onInputChange(event: Event) {
    const input = event.target as HTMLInputElement;
    input.value = input.value.replace(/[^0-9]/g, '');
    this.formFilterConsult.get('id')?.setValue(input.value);
  }
}
