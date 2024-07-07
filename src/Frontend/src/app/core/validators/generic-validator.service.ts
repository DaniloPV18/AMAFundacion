import { Injectable } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';

@Injectable({
  providedIn: 'root'
})
export class GenericValidatorService {

  constructor(private messageService: MessageService) { }

  buildForm(fields: any): FormGroup {
    const formGroup: FormGroup = new FormGroup({});
    Object.keys(fields).forEach((key) => {
      const validators = [];
      let value = {};
      if (fields[key].required) validators.push(Validators.required);
      if (fields[key].min) validators.push(Validators.min(fields[key].min));
      if (fields[key].max) validators.push(Validators.max(fields[key].max));
      if (fields[key].maxLength) validators.push(Validators.maxLength(fields[key].maxLength));
      if (fields[key].onlyNumber) validators.push(Validators.pattern('^[0-9]*$'));
      if (fields[key].onlyNumberNotZero) validators.push(Validators.pattern('^(?!0+$)(0|[1-9]\\d*)(\\.\\d+)?$'));

      if (fields[key].disabled) {
        value = { value: '', disabled: fields[key].disabled };
      } else {
        value ="";
      }
      formGroup.addControl(key, new FormControl(value, validators));
    });
    return formGroup;
  }

  verifyInvalidFormControl(form: any, fields: any) {

    const aFields = Object.keys(fields);
    for (const field of aFields) {

      if (form.get(field).errors != null && form.get(field)?.errors['required']) {
        this.setErrorFocusElement(`El campo '${fields[field].name}' es requerido`, field);
        break;
      }
      if (form.get(field).errors != null && form.get(field)?.errors?.maxlength?.requiredLength) {
        this.setErrorFocusElement(`El campo ${fields[field].name} no debe superar los ${fields[field].maxLength} caracteres`, field);
        break;
      }
      if (form.get(field).errors != null && form.get(field)?.errors?.min) {
        this.setErrorFocusElement(`El campo ${fields[field].name} debe ser igual o mayor a: ${form.get(field).errors?.min?.min}`, field);
        break;
      }
      if (form.get(field).errors != null && form.get(field)?.errors?.max) {
        this.setErrorFocusElement(`El campo '${fields[field].name}' no debe ser mayor a  ${form.get(field).errors?.max?.max}`, field);
        break;
      }
      if (form.get(field).errors != null && form.get(field)?.errors?.pattern?.requiredPattern && fields[field]?.onlyNumber) {
        this.setErrorFocusElement(`El campo ${fields[field].name} solo acepta números`, field);
        break;
      }
      if (form.get(field).errors != null && form.get(field)?.errors?.pattern?.requiredPattern && fields[field]?.onlyNumberNotZero) {
        this.setErrorFocusElement(`El campo ${fields[field].name} solo acepta números mayores a cero`, field);
        break;
      }
      if (form.get(field).errors != null && form.get(field)?.errors?.custom) {
        this.setErrorFocusElement(form.get(field)?.errors?.custom.message, field);
        break;
      }

      if (form.get(field).errors != null && form.get(field)?.errors?.pattern?.requiredPattern && fields[field].name === 'Email Corporativo') {
        this.setErrorFocusElement(`El campo ${fields[field].name} no es correcto.`, field);
        break;
      } 
    }
  }

  changesForm(oldData: any, newData: any): boolean {
    for (const key in oldData) {
      if (oldData.hasOwnProperty(key)) {
        if (oldData[key] !== newData[key]) {
          return true;
        }
      }
    }
    return false;
  }

  setErrorFocusElement(message:any, name: any) {
    this.messageService.add({severity:'error', detail:message});
    this.scrollToElement(name);
  }

  scrollToElement(id:any) {
    document.getElementById(`${id}`)?.scrollIntoView({ behavior: "smooth", block: "center"});
  }

  onKeyPressValidateOnlyText(event: any) {
    const pattern = /[a-zA-Z ]/;
    const inputChar = String.fromCharCode(event.charCode);

    if (!pattern.test(inputChar)) event.preventDefault();
  }

  onKeyPressValidateOnlyNumber(event: any) {
    const pattern = /\d/;
    const inputChar = String.fromCharCode(event.charCode);

    if (!pattern.test(inputChar)) event.preventDefault();
  }

  onKeyPressValidateOnlyTextNumber(event: any) {
    const pattern = /[a-zA-Z 0-9]/;
    const inputChar = String.fromCharCode(event.charCode);

    if (!pattern.test(inputChar)) event.preventDefault();
  }

  onKeyPressValidateOnlyTextNumberSymbol(event: any) {
    const pattern = /[a-zA-Z0-9@,._ ]/;
    const inputChar = String.fromCharCode(event.charCode);

    if (!pattern.test(inputChar)) event.preventDefault();
  }

  validateAllFormFields(formGroup: FormGroup | undefined) {
    if (formGroup != undefined) {
      Object.keys(formGroup.controls).forEach(field => {
        const control = formGroup.get(field);
        if (control instanceof FormControl) {
          control.markAsTouched({ onlySelf: true });
        } else if (control instanceof FormGroup) {
          this.validateAllFormFields(control);
        }
      });
    }
  }
}
