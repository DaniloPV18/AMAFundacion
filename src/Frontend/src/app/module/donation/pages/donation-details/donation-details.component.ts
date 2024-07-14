import {
  Component,
  Input,
  OnChanges,
  OnInit,
  SimpleChanges,
} from '@angular/core';
import { DonationCreateOrEditComponent } from '../donation-create-or-edit/donation-create-or-edit.component';
import { DialogService } from 'primeng/dynamicdialog';
import { Sort } from '../../../../core/interfaces/sort';
import { DonationDto } from '../../interfaces/donation-dto';
import { DonationFilter } from '../../interfaces/donation-filter';
import { DonationService } from '../../services/donation.service';
import { ConfirmationService, MessageService } from 'primeng/api';

@Component({
  selector: 'app-donation-details',

  templateUrl: './donation-details.component.html',
  styleUrl: './donation-details.component.sass',
})
export class DonationDetailsComponent implements OnInit, OnChanges {
  @Input() isUpdateListDetails: boolean = false;
  @Input() searchFilter: any = {};

  DeleteData(donationDto: any, event: Event) {
    this.confirmationService.confirm({
      target: event.target as EventTarget,
      message: '¿Estás seguro de realizar este proceso?',
      header: 'Confirmación',
      icon: 'pi pi-info-circle',
      acceptButtonStyleClass: 'p-button-danger p-button-text',
      rejectButtonStyleClass: 'p-button-text p-button-text',
      acceptIcon: 'none',
      rejectIcon: 'none',
      acceptLabel: 'Confirmar',
      rejectLabel: 'Cancelar',
      accept: () => {
        donationDto = this.listaDonations.filter(
          (item) => item.id === donationDto.id
        )[0];
        donationDto.status = 'E';
        this.totalRows -= 1;
        this.DeleteDonation(donationDto.id);
      },
      reject: () => {
        this.messageService.add({
          severity: 'warn',
          summary: '',
          detail: 'Registro no eliminado',
          life: 3000,
        });
      },
    });
  }
  EditData(donationDto: any) {
    this.NavigateUpdate(donationDto);
    this.GetDonation();
  }
  ViewData(donationDto: any) {
    this.NavigateView(donationDto);
  }
  NavigateView(donationDto: any) {
    this.dialogService.open(DonationCreateOrEditComponent, {
      header: 'Ver Donación',
      width: '75%',
      height: '100%',
      data: { update: true, donation: donationDto, view: true },
      contentStyle: { 'max-height': '500px', overflow: 'auto' },
      baseZIndex: 10000,
    });
  }
  loading: boolean = false;
  listaDonations: DonationDto[] = [];
  totalRows: number = 0;
  donationFiler!: DonationFilter;
  constructor(
    private dialogService: DialogService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private donationService: DonationService
  ) {}
  ngOnInit(): void {
    this.GetDonation();
  }
  ngOnChanges(changes: SimpleChanges): void {
    for (let propName in changes) {
      if (propName === 'isUpdateListDetails' && this.isUpdateListDetails) {
        this.ngOnInit();
      }
      if (propName === 'searchFilter') {
        if (changes[propName].currentValue) {
          console.log(changes[propName].currentValue);
          this.listaDonations =
            changes[propName].currentValue.listabeneficiarios;
          this.totalRows = changes[propName].currentValue.totalRows;
          this.loading = changes[propName].currentValue.loading;
        }
      }
    }
  }
  private GetDonation() {
    this.donationFiler = {
      offset: 0,
      take: 10,
      sort: '',
    };

    this.donationService.GetAlldonations(this.donationFiler).subscribe({
      next: (result) => {
        this.listaDonations = result.result;
        this.totalRows = result.length;
        this.loading = false;
      },
      error: (error) => {},
    });
  }
  NavigateUpdate(donationDto: DonationDto) {
    this.dialogService
      .open(DonationCreateOrEditComponent, {
        header: 'Actualizar Donación',
        width: 'auto',
        style: {
          'max-height': '90%',
          'max-width': '80%',
          overflow: 'auto',
        },
        height: 'auto',
        data: { update: true, donation: donationDto },
        baseZIndex: 10000,
      })
      .onClose.subscribe((result) => {
        if (result) {
          this.GetDonation();
        }
      });
  }
  loadDataTableLazy(event: any) {
    let sortCol = event.sortField;
    let sortColOrder = event.sortOrder;
    let offset = event.first;
    let take = event.rows;
    let sortStr = '';
    if (!(sortCol === undefined || sortCol === null)) {
      let sortArray: Sort[] = [];
      let sortObj: Sort = {
        selector: sortCol,
        desc: sortColOrder !== 1,
      };
      sortArray.push(sortObj);
      sortStr = JSON.stringify(sortArray);
    }

    this.donationFiler.sort = sortStr;
    this.donationFiler.take = take;
    this.donationFiler.offset = offset;
    this.donationService.GetAlldonations(this.donationFiler).subscribe({
      next: (result) => {
        this.listaDonations = result.result;
        this.totalRows = result.length;
        this.loading = false;
      },
      error: (error) => {},
    });
  }

  private DeleteDonation(id: number) {
    this.donationService.deletedonation(id).subscribe({
      complete: () => {
        this.messageService.add({
          severity: 'success',
          summary: '',
          detail: 'Registro eliminado',
          life: 3000,
        });
        this.GetDonation();
      },
      error: () => {
        this.GetDonation();
      },
    });
  }
}
