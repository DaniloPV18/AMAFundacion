import { Injectable, OnInit } from '@angular/core';
import { PersonDialogComponet } from '../shared/component/person-dialog-componet/person-dialog-componet.component';
import { BrigadeDialogComponent } from '../shared/component/brigade-dialog/brigade-dialog.component';
 
 

@Injectable({
  providedIn: 'root'
})
export class DataSetComponentService  {
  COMPONETS: { [key: string]: any } ={
    "PersonDialogComponet":PersonDialogComponet,
    "BrigadeDialogComponent":BrigadeDialogComponent,
 
  }
 get(name: string): any{
  return  this.COMPONETS[name];
 }
}
