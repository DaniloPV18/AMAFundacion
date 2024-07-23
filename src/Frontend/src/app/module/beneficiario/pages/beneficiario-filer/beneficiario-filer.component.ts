import {
  Component,
  EventEmitter,
  Input,
  Output,
  SimpleChanges,
} from '@angular/core';

import { FormGroup } from '@angular/forms';
import { FormService } from '../../../../shared/services/from.service';
import { beneficiarioFilter } from '../../interfaces/beneficiario-filter';

@Component({
  selector: 'app-beneficiario-filer',
  templateUrl: './beneficiario-filer.component.html',
  styleUrl: './beneficiario-filer.component.sass',
})
export class beneficiarioFilerComponent {
  @Output() queryEmitter = new EventEmitter<beneficiarioFilter>();
  @Output() changeFilter = new EventEmitter<boolean>();
  @Input() openContentReceiver: boolean = false;

  IsOpen: boolean = true;
  formFilterConsult!: FormGroup;
  formBeneficiaryFilter!: beneficiarioFilter;

  constructor(private formService: FormService) {
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
    this.formFilterConsult.reset();
    // this.formFilterConsult.setValue({ offset: 0, take: 10 });
    this.queryEmitter.emit({
      ...this.formFilterConsult.value,
      offset: 0,
      take: 10,
    });
  }

  closed() {
    // this.clearFiltersEvent();
    this.changeFilter.emit(false);
  }

  Buscar() {
    this.queryEmitter.emit(this.formFilterConsult.value);
    this.changeFilter.emit(true);
  }

  buildForm() {
    this.formBeneficiaryFilter = {
      Identification: '',
      PersonId: null,
      Name: '',
      Email: '',
      offset: 10,
      take: 0,
      sort: '',
    };

    this.formFilterConsult =
      this.formService.createFormGroup<beneficiarioFilter>(
        this.formBeneficiaryFilter
      );
  }
}
