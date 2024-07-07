import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TextValidatorService {

  validateTelephone(event:any): boolean {
    const pattern: RegExp = /^\d*$/;
    let inputChar: string = "";
    let clipboardData = event.clipboardData;
    inputChar = (clipboardData) ? clipboardData.getData('text') : String.fromCharCode(event.charCode);
    if (!pattern.test(inputChar)) {
      event.preventDefault();
      return  false;
    }
    return true;
  }

  changeUppercase(event: any) {
    event.target.value = event.target.value.toUpperCase();
  }

  validateMaxLength(event:any,maxLength:number){
    const inputValue = event.target.value;
    if (inputValue.length > maxLength) {
      event.target.value = inputValue.slice(0, maxLength);
    }
  }

  validateEmail(event: any): boolean {
    const emailPattern: RegExp = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    let inputChar: string = "";
    let clipboardData = event.clipboardData;
    inputChar = (clipboardData) ? clipboardData.getData('text') : String.fromCharCode(event.charCode);
    if (!emailPattern.test(inputChar)) {
      event.preventDefault();
      return  false;
    }
    return true;
  }

  validateMoreThanOneEmail(event: any): void {
    setTimeout(() => {
      const inputValue: string = event.target.value;
      const emailPattern: RegExp = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}(;[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})*$/;
      if (!emailPattern.test(inputValue)) {
        // Limpiar el valor si no coincide con el patrón
        event.target.value = '';
      }
    }, 0);
  }


  validateOnlyTextNumberSymbol(event: any): boolean {
    const pattern: RegExp = /[a-zA-ZÀ-ÿ\u00f1\u00d10-9@,-._ ]/;
    let inputChar: string = "";

    let clipboardData = event.clipboardData;
    inputChar = (clipboardData) ? clipboardData.getData('text') : String.fromCharCode(event.charCode);


    if (!pattern.test(inputChar)) {
        event.preventDefault();
        return false;
    }
    return true;
  }

  validateTextNumberSym(event: any): boolean {
    const pattern: RegExp = /^[a-zA-Z0-9/]+$/;
    let inputChar: string = "";

    let clipboardData = event.clipboardData;
    inputChar = (clipboardData) ? clipboardData.getData('text') : String.fromCharCode(event.charCode);

    if (!pattern.test(inputChar)) {
        event.preventDefault();
        return false;
    }
    return true;
  }

  validateOnlyNumber(event: any): boolean {
    return this.validateTelephone(event);
  }

  moveWithPoint(event: any): void {
    if (event.key === '.') {
      event.preventDefault();
      const inputElement = event.target as HTMLInputElement;
      const length = inputElement.value.length;
      const positionToMove = length - 2;
      inputElement.focus();
      inputElement.setSelectionRange(positionToMove, positionToMove);
    }

  }

  validateOnlyLetters(event: any, espacios: boolean = true): boolean {
    let pattern: RegExp;
    if(espacios)
      pattern = /^[a-zA-ZáéíñóúüÁÍÉÑÓÚÜ\s]*$/;
    else
      pattern = /^[a-zA-ZáéíñóúüÁÍÉÑÓÚÜ]*$/;

    let inputChar: string = "";
    let clipboardData = event.clipboardData;
    inputChar = (clipboardData) ? clipboardData.getData('text') : String.fromCharCode(event.charCode);
    if (!pattern.test(inputChar)) {
      event.preventDefault();
      return  false;
    }
    return true;
  }

  validateNameBeneficiary(event: any): boolean {
    const pattern : RegExp = /^[a-zA-ZáéíñóúüÁÍÉÑÓÚÜ/\s]*$/;
    let inputChar: string = "";
    let clipboardData = event.clipboardData;
    inputChar = (clipboardData) ? clipboardData.getData('text') : String.fromCharCode(event.charCode);
    if (!pattern.test(inputChar)) {
      event.preventDefault();
      return  false;
    }
    return true;
  }

  validateOnlyLettersAndNumbers(event: any, espacios: boolean = true): boolean {
    let pattern: RegExp;

    if(espacios)
      pattern = /^[a-zA-ZáéíñóúüÁÍÉÑÓÚÜ0-9\s]*$/;
    else
      pattern = /^[a-zA-ZáéíñóúüÁÍÉÑÓÚÜ0-9]*$/;

    let inputChar: string = "";
    String.fromCharCode(event.charCode);
    let clipboardData = event.clipboardData;
    inputChar = (clipboardData) ? clipboardData.getData('text') :String.fromCharCode(event.charCode);

    if (!pattern.test(inputChar)) {
      event.preventDefault();
      return  false;
    }
    return true;
  }

  validateLettersAndNumbersWithSpecialChars(event: any, espacios: boolean = true): boolean {
    let pattern: RegExp = /^[a-zA-Z0-9\s]*$/;
    let inputChar: string = "";
    String.fromCharCode(event.charCode);
    let clipboardData = event.clipboardData;
    inputChar = (clipboardData) ? clipboardData.getData('text') :String.fromCharCode(event.charCode);

    if (!pattern.test(inputChar)) {
      event.preventDefault();
      return  false;
    }
    return true;
  }

}
