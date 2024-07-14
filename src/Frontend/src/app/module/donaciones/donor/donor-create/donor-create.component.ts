import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { HttpClient } from '@angular/common/http';
import { DonorService } from '../donor.service';
import { MessageService } from 'primeng/api';
import { Console } from 'console';

@Component({
  selector: 'app-donor-create',
  templateUrl: './donor-create.component.html',
  styleUrls: ['./donor-create.component.sass'],
})
export class DonorCreateComponent implements OnInit {
  visible: boolean = true;
  donorForm: FormGroup;
  donante: any;

  constructor(
    private dialogRef: MatDialogRef<DonorCreateComponent>,
    private fb: FormBuilder,
    private http: HttpClient,
    private donorService: DonorService,
    private messageService: MessageService,
    @Inject(MAT_DIALOG_DATA) private data: any
  ) {
    this.donante = data ? data.donante : null;

    this.donorForm = this.fb.group({
      identificacion: ['', Validators.required],
      firstName: ['', Validators.required],
      secondName: ['', Validators.required],
      firstLastName: ['', Validators.required],
      secondLastName: ['', Validators.required],
      // nombreCompleto:['', Validators.required],
      phone: ['', Validators.pattern(/^\d{10}$/)],
      email: ['', Validators.required],
      status: [false],
    });

    if (this.donante) {
      this.donorForm.patchValue({
        identificacion: this.donante.identificacion,
        firstName: this.donante.firstName,
        secondName: this.donante.secondName,
        firstLastName: this.donante.firstLastName,
        secondLastName: this.donante.secondLastName,
        // nombreCompleto:this.donante.nombreCompleto,
        phone: this.donante.phone,
        email: this.donante.email,
        status: this.donante.status,
      });
    }
  }

  ngOnInit(): void {}
  /*
  guardarDonante() {


    if (this.donorForm.valid) {
      const formData = this.donorForm.value;

      if (this.donante) {

        this.donorService.updateDonor(this.donante.id_donante, formData).subscribe(
    
          (response) => {

                    this.dialogRef.close();
          },
          (error) => {
            console.error('Error al actualizar el donante:', error);
          }
        );
      } else {
        this.donorService.postDonor(formData).subscribe(
          (response) => {

            this.donorService.getDonorList().subscribe(
              (data) => {
              },
              (error) => {
                console.error('Error al obtener datos:', error);
              }
            );
            this.dialogRef.close();
          },
          (error) => {
            console.error('Error al guardar el donante:', error);
          }
        );
      }
    }
  }*/

  guardarDonante() {
    if (this.donorForm.valid) {
      const formData = this.donorForm.value;
      if (this.donante) {
        this.donorService
          .updateDonor(this.donante.id_donante, formData)
          .subscribe({
            next: (response) => {
              this.messageService.add({
                severity: 'success',
                summary: 'Éxito',
                detail: 'Donante actualizado con éxito',
              });
              this.dialogRef.close();
            },
            error: (error) => {
              this.messageService.add({
                severity: 'error',
                summary: 'Error',
                detail: 'Error al actualizar el donante',
              });
              console.error('Error al actualizar el donante:', error);
            },
          });
      } else {
        this.donorService.postDonor(formData).subscribe({
          next: (response) => {
            this.messageService.add({
              severity: 'success',
              summary: 'Éxito',
              detail: 'Donante guardado con éxito',
            });
            this.dialogRef.close();
          },
          error: (error) => {
            this.messageService.add({
              severity: 'error',
              summary: 'Error',
              detail: 'Error al guardar el donante',
            });
            console.error('Error al guardar el donante:', error);
          },
        });
      }
    }
  }

  showDialog() {
    this.visible = true;
  }

  closeDialog() {
    this.visible = false;
    this.dialogRef.close();
  }
}
