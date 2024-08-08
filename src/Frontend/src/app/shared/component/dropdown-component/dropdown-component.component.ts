import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnDestroy,
  OnInit,
  Output,
  SimpleChanges,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormGroup, FormControl } from '@angular/forms';
import { DynamicDialogRef, DialogService } from 'primeng/dynamicdialog';
import {
  DynamicDataToDialog,
  ConfigurationDropdownProp,
  ItemDropdown,
  ChangeItemDropdown,
} from '../../../core/interfaces/ItemDropdown.models';
import { DataSetComponentService } from '../../../data/datasetcomponet.service';
import { throws } from 'assert';

@Component({
  selector: 'app-dropdown',

  templateUrl: './dropdown-component.component.html',
  styleUrl: './dropdown-component.component.sass',
})
export class DropdownComponent implements OnDestroy, OnChanges {
  @Input() dataToDialog!: DynamicDataToDialog;
  @Input() className!: string;
  @Input() title?: string;
  @Input() confProp!: ConfigurationDropdownProp;
  @Input() itemsProp!: ItemDropdown[];
  @Input() disabledProp: boolean = false;
  @Output() itemChanged = new EventEmitter<ChangeItemDropdown>();

  items: ItemDropdown[] = [];
  ref!: DynamicDialogRef;
  formItemDropdownGroup: FormGroup;
  disabledPropControl: boolean = false;
  classButtonControl: string = '';

  constructor(
    public dialogService: DialogService,
    private datasetComponentService: DataSetComponentService
  ) {
    this.items = [];
    this.disabledPropControl = this.disabledProp;
    // if (this.disabledPropControl) {
    //   this.classButtonControl = "width: 50px; height:40px; color: white; background-color: rgb(122, 116, 182); position: absolute; right: 0";
    // } else {
    //   this.classButtonControl = "width: 50px;  height:40px; color: white; background-color: rgb(34, 25, 135); position: absolute; right: 0";
    // }

    if (this.disabledPropControl) {
      this.classButtonControl =
        'background-color: rgb(122, 116, 182); position: absolute; right: 0px;';
    } else {
      this.classButtonControl =
        'background-color: rgb(34, 25, 135); position: absolute; right: 0px;';
    }

    this.formItemDropdownGroup = new FormGroup({
      itemFormControl: new FormControl({
        value: null,
        disabled: this.disabledProp,
      }),
    });
  }
  ngOnChanges(changes: SimpleChanges): void {
    for (let propName in changes) {
      if (propName === 'itemsProp') {
        this.items = changes[propName].currentValue;
        if (this.items.length > 0) {
          this.formItemDropdownGroup
            .get('itemFormControl')
            ?.patchValue(this.items[0].code);
        } else {
          this.formItemDropdownGroup.get('itemFormControl')?.patchValue(null);
        }
      }
      if (propName === 'disabledProp') {
        this.disabledProp = changes[propName].currentValue;
        if (this.disabledProp) {
          this.formItemDropdownGroup.get('itemFormControl')?.disable();
        } else {
          this.formItemDropdownGroup.get('itemFormControl')?.enable();
        }
        this.disabledPropControl = this.disabledProp;
      }
    }
  }

  ngOnDestroy(): void {
    if (this.ref) {
      this.ref.close();
    }
  }

  // Events
  openDialog() {
    if (!this.disabledPropControl) {
      this.openDialogProcess();
    }
  }

  clearItems() {
    this.clearItemsProcess();
  }

  // Private Functions
  private openDialogProcess() {
    this.ref = this.dialogService.open(
      this.datasetComponentService.get(this.confProp.NameComponent),
      {
        width: this.confProp.width ?? 'auto',
        height: this.confProp.height ?? 'auto',
        header: this.title,
        style: { 'max-height': '90%', 'max-width': '90%' },
        data: {
          dataToDialogArr: this.dataToDialog.Params,
          dataFilter: this.dataToDialog.dataFilter,
        },
      }
    );

    this.ref.onClose.subscribe((itemSel: ItemDropdown) => {
      if (itemSel) {
        this.items = [];
        itemSel.description = itemSel.description?.toUpperCase();
        this.items.push(itemSel);
        this.formItemDropdownGroup
          .get('itemFormControl')
          ?.patchValue(itemSel.code);
        // Emit new values to parent
        let _conf: ConfigurationDropdownProp = {
          Id: this.confProp.Id,
          Name: this.confProp.Name,
          Tooltip: this.confProp.Tooltip,
          NameComponent: this.confProp.NameComponent,
          Dataset: this.confProp.Dataset,
        };
        let _data: ItemDropdown = {
          code: itemSel.code,
          description: itemSel.description,
          dataSerialize: itemSel.dataSerialize,
        };
        let _itemChanged: ChangeItemDropdown = {
          conf: _conf,
          data: _data,
        };
        this.itemChanged.emit(_itemChanged);
      }
    });
  }

  private clearItemsProcess() {
    // Clear List of Items
    this.items = [];

    // Emit new values to parent
    let _conf: ConfigurationDropdownProp = {
      Id: this.confProp.Id,
      Name: this.confProp.Name,
      Tooltip: this.confProp.Tooltip,
      NameComponent: this.confProp.NameComponent,
      Dataset: this.confProp.Dataset,
    };
    let _data: ItemDropdown = {
      code: '',
      description: '',
      dataSerialize: '',
    };
    let _itemChanged: ChangeItemDropdown = {
      conf: _conf,
      data: _data,
    };
    this.itemChanged.emit(_itemChanged);
  }
}
