import {
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  SimpleChanges,
} from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FormService } from '../../../../shared/services/from.service';
import { BrigadeFilter } from '../../models/brigada-filter.interface';
import { ChangeItemDropdown, ConfigurationDropdownProp, DynamicDataToDialog, ItemDropdown } from '../../../../core/interfaces/ItemDropdown.models';

@Component({
  selector: 'app-filter-brigades',
  templateUrl: './filter-brigades.component.html',
  styleUrl: './filter-brigades.component.sass',
})
export class FilterBrigadesComponent implements OnInit {
itemsPersona!: ItemDropdown[];
lsPersona!: DynamicDataToDialog;
personaConfig!: ConfigurationDropdownProp;
onItemChanged(eventData: ChangeItemDropdown) {
  if (eventData && eventData.conf.Id === 'idPersona') {

    this.formFilterConsult.get('personId')?.setValue(eventData.data.code);
  }

}
  @Output() queryEmitter = new EventEmitter<BrigadeFilter>();
  @Input() openContentReceiver: boolean =false;

  IsOpen: boolean = false;
  formFilterConsult!: FormGroup;
  fomrBrigadeFilter!: BrigadeFilter;

  constructor(private formService: FormService) {

  }

  ngOnInit(): void {
    // this.openContentReceiver=true
    this.clearFiltersEvent();
    this.buildForm();
    this.InitializerData();
  }

  ngOnChanges(changes: SimpleChanges): void {
    for (let propName in changes) {
      if (propName === 'openContentReceiver') {
        this.IsOpen = !this.IsOpen;
      }
    }
  }

  Buscar() {
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
    // this.clearFiltersEvent();
    this.IsOpen = !this.IsOpen;
  }
  InitializerData() {
    this.lsPersona = { Params: [] };
    this.personaConfig = {
      Id: 'idPersona',
      Name: 'Persona',
      Tooltip: 'Search Persona',
      Dataset: 'Persona',
      NameComponent: 'PersonDialogComponet'
    };
    this.itemsPersona = [];

  }

  buildForm() {
    this.fomrBrigadeFilter = {
      id: undefined,
      companyId: undefined,
      personId: undefined,
      name: undefined,
      descripction: undefined,
      offset: 0,
      take: 10,
      sort: '',

    };
    this.formFilterConsult = this.formService.createFormGroup<BrigadeFilter>(
      this.fomrBrigadeFilter
    );
  }
}
