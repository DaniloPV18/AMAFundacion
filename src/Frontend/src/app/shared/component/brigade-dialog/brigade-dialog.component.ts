import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrigadeDto } from '../../../module/brigada/interfaces/brigade-dto';
import { BrigadeDialogService } from './brigade-dialog.service';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { MessageService } from 'primeng/api';
import { TextValidatorService } from '../../../core/validators/text-validator.service';
import { BrigadeFilter } from '../../../module/brigada/models/brigada-filter.interface';
import { Sort } from '../../../core/interfaces/sort';
import { ResultList } from '../../../core/interfaces/result';
import { ItemDropdown } from '../../../core/interfaces/ItemDropdown.models';

@Component({
  selector: 'app-brigade-dialog',
 
  templateUrl: './brigade-dialog.component.html',
  styleUrl: './brigade-dialog.component.sass'
})
export class BrigadeDialogComponent implements OnInit {
  isFirstLoad: boolean = true;
  loading: boolean = false;
  totalRows: number = 0;
  lsBrigade: BrigadeDto[] = [];
  codigosMessage: any;
  mensajesMessage: any;

  constructor(private BrigadeDialogService: BrigadeDialogService
    , public ref: DynamicDialogRef
    , public config: DynamicDialogConfig
    , private messageService: MessageService
    , private readonly textValidatorService: TextValidatorService){
  }

  ngOnInit(): void {
    let BrigadeReq: BrigadeFilter = {
 
      offset:0,
      take:10,
      sort:""
    };
    this.getBrigadeData(BrigadeReq);
  }

  loadBrigadeLazy(event: any) {
    if (this.isFirstLoad) {
      this.isFirstLoad = false;
      return;
    }
    let BrigadeReq: BrigadeFilter = {
 
      offset:event.first,
      take:event.rows,
      sort:""
    };

    let sortCol = event.sortField;
    let sortColOrder = event.sortOrder;
    let sortStr = "";
    if (!(sortCol === undefined || sortCol ===null)){
      let sortArray: Sort[] = [];
      let sortObj: Sort ={
        selector: sortCol,
        desc: sortColOrder !== 1,
      };
      sortArray.push(sortObj);
      sortStr = JSON.stringify(sortArray);
    }
    BrigadeReq.sort = sortStr;

    let filterObj = event.filters;
    
    if(filterObj.hasOwnProperty('name')){
      BrigadeReq.name = filterObj['name']['value'];
    }
    if(filterObj.hasOwnProperty('id')){
      BrigadeReq.id = filterObj['id']['value'];
    }

    this.getBrigadeData(BrigadeReq);
  }

  getBrigadeData(request: BrigadeFilter){
    [this.codigosMessage, this.mensajesMessage] 
    this.loading =true;
    this.BrigadeDialogService.getPaginated(request)
      .subscribe(
        {
          next: (data) => {
            let dataTmp = <ResultList<BrigadeDto>>data;
            if(dataTmp) {
              this.totalRows = dataTmp.length;
              this.lsBrigade = dataTmp.result;
 
            }
          },
          error: (error) => {
            this.loading = false;
            if(error){
         
            }
          },
          complete: () => {
            this.loading = false;
          }
        }
      );
  }

  onRowDblClick(event: any, dataSelected:any){
    if(dataSelected){
      let _description = ((dataSelected.id) ? dataSelected.id : "" ) + " - " +
       ((dataSelected.name) ? dataSelected.name: "") 
      let itemDropdown: ItemDropdown = {
        code: dataSelected.id,
        description: _description,
        dataSerialize: JSON.stringify(dataSelected)
      }
      this.ref.close(itemDropdown);
    }

  }

  onKeyDownLetters = (event: any) => this.textValidatorService.validateOnlyLetters(event);
  onKeyDownLettersAndNumbers = (event: any) => this.textValidatorService.validateOnlyLettersAndNumbers(event);
  onInput = (event: any) => this.textValidatorService.changeUppercase(event);
}
