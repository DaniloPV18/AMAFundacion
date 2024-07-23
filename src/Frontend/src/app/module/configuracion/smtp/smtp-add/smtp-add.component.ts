/*  import { FormsModule } from '@angular/forms';  */
import { ReactiveFormsModule } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { SmtpConfigurationService } from '../../../../services/configuracion/smtp.service';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-smtp-add',
  templateUrl: './smtp-add.component.html',
  styleUrl: './smtp-add.component.sass'
})


export class SmtpAddComponent implements OnInit {

  smtpForm!: FormGroup;

  Id : number = 0;
  CompanyId:number = 1;
  Profile: number = 1;
  Mail: string ='';
  DisplayName: string = '';
  Password: string = '';
  Host: string = '';
  Port: number=0;

  Authentication: boolean = true;

  constructor(private router: Router, private smtpService: SmtpConfigurationService, private http: HttpClient,private formBuilder: FormBuilder) { }

  ngOnInit() {

    this.initForm();


    this.getDataFromApi();
  }

  initForm(): void {
    // Inicializar el formulario con campos y validadores
    this.smtpForm = this.formBuilder.group({
      DisplayName: ['', Validators.required],
      Password: ['', Validators.required],
      Mail: ['', [Validators.required, Validators.email]],
      Host: ['', Validators.required],
      Port: ['', [Validators.required, Validators.pattern(/^[0-9]+$/)]],
      // Otros campos del formulario...
    });
  }

  getDataFromApi(): void {
    const data={
      Id: '',
      Profile: this.Profile.toString(),
    }
    // Llamar al servicio para obtener datos del API y llenar el formulario
    this.smtpService.getAllConfigurations(data).subscribe({
      next: (data) => {


        if(data.length >0){//cantidad

        const firstConfig = data[0];
        this.Id = firstConfig.id;
        // this.CompanyId = firstConfig.CompanyId;
        this.DisplayName = firstConfig.displayName;
        this.Mail = firstConfig.mail;
        this.Host = firstConfig.host;
        this.Port = firstConfig.port;

        }else{
        this.DisplayName = '';
        this.Mail = '';
        this.Host = '';
        this.Password = '';
        this.Port = 0;
        }

      },
      error: (error) => {
        console.error('Error al obtener datos del API:', error);
      }
    });
  }


  onAddSMTP(): void {

    if(this.Id >0){ // EXISTEN REGISTROS

      const dataUser = {
        Id: this.Id,
        Profile: this.Profile,
        Mail: this.Mail.toString(),
        DisplayName: this.DisplayName.toString(),
        Host: this.Host.toString(),
        Port: this.Port,
        Authenticate: this.Authentication
      }

        this.smtpService.updateSmtpConfig(this.Id,dataUser).subscribe({
          next: (response) => {

          },
          error: (error) => {
            console.error('Hubo un error en la actualización de datos');
          }
        });
          //

        if(this.Password!== ''){ //SI EXISTEN DATOS EN PASSWORD, ACTUALIZAR CONTRASEÑA


          this.smtpService.updateSmtpPassword(this.Id,this.Password.toString()).subscribe({
            next: (response) => {



            },
            error: (error) => {
              console.error('Hubo un error en la actualización de datos Password');
            }
          });
        }

    }else{ // NO EXISTEN REGISTROS


       const dataUser = {
      Profile: this.Profile,
      CompanyId: this.CompanyId,//
      Mail: this.Mail.toString(),
      DisplayName: this.DisplayName.toString(),
      Host: this.Host.toString(),
      Password: this.Password.toString(),
      Port: this.Port,
      Authenticate: this.Authentication
    };


    this.smtpService.addSmtpConfig(dataUser).subscribe({
      next: (response) => {

        // Maneja la respuesta del servidor según tus necesidades
      },
      error: (error) => {

        // Maneja el error del servidor según tus necesidades
      }
    });
    }

  }




  onBack(): void {
    this.router.navigate(['/configuracion/smtp']);
  }
}
