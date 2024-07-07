import { Injectable } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class FormService {

  createFormGroup<T>(form:T): FormGroup {
    const formGroup: any = {};
    for (const key in form) {
      if (Object.prototype.hasOwnProperty.call(form, key)) {
        const nullable = (form as any)[key]?.nullable || false; // Verify si la property is  nullable
        const validators = nullable ? [] : [Validators.required]; 
        formGroup[key] = new FormControl((form as any)[key], validators);
      }
    }
     return new FormGroup(formGroup);
  }
}
