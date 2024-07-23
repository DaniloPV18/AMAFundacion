import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ValidationErrors } from '@angular/forms';

@Component({
  selector: 'app-error-display',
  
  templateUrl: './error-display.component.html',
  styleUrl: './error-display.component.sass'
})
export class ErrorDisplayComponent {
  @Input() control: any;
  @Input() minLength: number | undefined;
  @Input() maxLength: number | undefined;
  @Input() isNumeric: boolean | undefined;
  @Input() pattern: string | undefined;

  getErrors(): { [key: string]: string } {
    const errors: ValidationErrors | null = this.control?.errors;
    const errorMessages: { [key: string]: string } = {
      required: 'El campo es requerido',
      minlength: this.minLength ? `El valor debe tener al menos ${this.minLength} caracteres` : 'El valor es demasiado corto',
      maxlength: this.maxLength ? `El valor debe tener como máximo ${this.maxLength} caracteres` : 'El valor es demasiado largo',
      pattern: this.pattern ? `El valor debe contener solo ${this.pattern}`:   'El valor del campo no es correcto',
      email:   'El campo debe ser de formato email',
     
  
    };

    const result: { [key: string]: string } = {};

    if (errors) {
      for (const key of Object.keys(errors)) {
        if (errorMessages[key]) {
          result[key] = errorMessages[key];
        }
      }
    }

    return result;
  }
}
