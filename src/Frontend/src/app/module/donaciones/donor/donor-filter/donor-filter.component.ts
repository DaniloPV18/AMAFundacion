import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { FilterService } from '../filter.service';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';

@Component({
  selector: 'app-donor-filter',
  templateUrl: './donor-filter.component.html',
  styleUrls: ['./donor-filter.component.sass'],
})
export class DonorFilterComponent implements OnInit {
  filtroForm!: FormGroup;

  constructor(private fb: FormBuilder, private filterService: FilterService) {}

  ngOnInit() {
    this.filtroForm = this.fb.group({
      nombreFiltro: [''],
      numeroFiltro: [''],
    });

    this.filtroForm.valueChanges
      .pipe(debounceTime(300), distinctUntilChanged())
      .subscribe((value) => {
        this.filterService.actualizarFiltro(value);
      });
  }
}
