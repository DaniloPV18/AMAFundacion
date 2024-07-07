import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DonationCreateOrEditComponent } from '../donation-create-or-edit/donation-create-or-edit.component';
import { DialogService } from 'primeng/dynamicdialog';
import { DonationFilter } from '../../interfaces/donation-filter';
import { DonationService } from '../../services/donation.service';

@Component({
  selector: 'app-donation-index',
  templateUrl: './donation-index.component.html',
  styleUrl: './donation-index.component.sass'
})
export class DonationIndexComponent {
  isUpdateListDetails:boolean = false;
  cambios: any;
  NavigateToCreate() {
    this.dialogService.open(DonationCreateOrEditComponent, {
      header: 'Crear Donación',
      width: 'auto',
        height: 'auto',
      data: {update: false},
      contentStyle: { 'min-height': '500px', 'min-width': '500px' },
      baseZIndex: 10000,
    })
    .onClose.subscribe((result) => {

      if (result) {
        this.isUpdateListDetails=   true;
      }
    });
  }
  openFilterPanel: boolean = true;
  entityFilterRequest: DonationFilter | undefined;
  constructor(private dialogService: DialogService
    , private donationService:DonationService
    ) {}

  openCloseFilter() {
    this.openFilterPanel = !this.openFilterPanel;
  }
  getPersonRequestFilter(event: DonationFilter) {
    this.entityFilterRequest = event;

      let beneficiarioFilter = Object.fromEntries(
        Object.entries(event).filter(
          ([key, value]) => value !== '' && value !== null
        )
      );

      if (Object.keys(beneficiarioFilter).length !== 0) {
        beneficiarioFilter = { ...beneficiarioFilter, offset: 0, take: 10 };
        this.donationService
          //@ts-ignore
          .GetAlldonations(beneficiarioFilter)
          .subscribe(
            (result) => {
              this.cambios = {
                listabeneficiarios: result.result,
                totalRows: result.length,
                loading: false,
              };
            },
            (error) => {}
          );
      }
    }
  }
