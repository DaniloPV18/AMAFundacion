import { Component,ViewChild,ElementRef, OnInit  } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth/auth.service';
import { HttpClient } from '@angular/common/http';
import { Init } from 'v8';
import { response } from 'express';

@Component({
  selector: 'app-confirmation-password',
  templateUrl: './confirmation-password.component.html',
  styleUrl: './confirmation-password.component.sass'
})
export class ConfirmationPasswordComponent implements OnInit {

  Identification: string = '';
  Code: string = '';
  Password: string = '';
  errorMessage: string = '';
  alertClass: string = 'alert-success'; // Clase CSS inicial (verde)


  showCode: boolean = true;
  showTrue: boolean = false;
  showFalse: boolean = false;

  constructor(private router: Router, private authService: AuthService, private http: HttpClient) { }
  
  @ViewChild('identificacionInput')
  identificacionInput!: ElementRef;
  @ViewChild('codigoSeguridadInput')
  codigoSeguridadInput!: ElementRef;
  @ViewChild('contrasenaInput')
  contrasenaInput!: ElementRef;
  @ViewChild('botonInput')
  botonInput!: ElementRef;

  ngOnInit() {
    this.getDataFromApi();
  }
  getDataFromApi(): void {
    this.Code='';
    this.Identification = this.authService.getIdentification();
    this.Password='';
    console.log(this.Identification)
    if(this.Identification =='') this.router.navigate(['/auth/reset-password']);
  }

  
  resetPassword(): void {

     // Verificar si algún campo está en blanco
    if (!this.Identification || !this.Code || !this.Password) {
      this.errorMessage = 'Por favor, complete todos los campos.';
      return;
      } 
    
    const sendCodeRequest = {
      Identification: this.Identification.toString(),
      Code: this.Code.toString(),
      Password: this.Password.toString()
    };

   
    this.authService.ResetPassword(sendCodeRequest).subscribe({ // si cambia la contraseña pero regresa error
      next: (response) => {

        this.errorMessage = response.message;

        if (this.errorMessage == "Clave actualizada"){
          this.identificacionInput.nativeElement.style.display = 'none';
          this.codigoSeguridadInput.nativeElement.style.display = 'none';
          this.contrasenaInput.nativeElement.style.display = 'none';
          this.botonInput.nativeElement.style.display = 'none';
          
          
          this.showCode= !this.showCode;
          this.showTrue= !this.showTrue;
          this.errorMessage="";
          this.alertClass="";
          } else {
       

          }
       // COMPROBACION PARA OCULTAR LOS INPUT DEPENDIENDO DE RESPUESTA
      },
      error: (error) => {

        this.identificacionInput.nativeElement.style.display = 'none';
        this.codigoSeguridadInput.nativeElement.style.display = 'none';
        this.contrasenaInput.nativeElement.style.display = 'none';
        this.botonInput.nativeElement.style.display = 'none';

        this.showCode= !this.showCode;
        this.showFalse= !this.showFalse;

   
      // COMPROBACION PARA OCULTAR LOS INPUT DEPENDIENDO DE RESPUESTA
      }
    });
    
  }

 
  onBack(): void {

    this.router.navigate(['/login/auth']);
  }
}
