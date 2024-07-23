import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { HttpClient } from '@angular/common/http';
import { VoluntarioService } from '../voluntario.service';
//import { DonorService } from '../../donor/donor.service';


@Component({
  selector: 'app-voluntario-create',
  templateUrl: './voluntario-create.component.html',
  styleUrl: './voluntario-create.component.sass',
})
export class VoluntarioCreateComponent {
  visible: boolean = true;
  voluntarioForm: FormGroup;
  voluntario: any;

  constructor(
    private dialogRef: MatDialogRef<VoluntarioCreateComponent>,
    private fb: FormBuilder,
    private http: HttpClient,
    //private donorService: DonorService,
    private voluntarioService:VoluntarioService,
    @Inject(MAT_DIALOG_DATA) private data: any
  ) {

    this.voluntario = data ? data.voluntario : null;
    this.voluntarioForm = this.fb.group({
      nombre_voluntario: ['', Validators.required],
      apellido_voluntario: ['', Validators.required],
      genero_voluntario: ['', Validators.required],
      direccion_voluntario: ['', Validators.required],
      celular_voluntario: ['', Validators.pattern(/^\d{10}$/)],
      email_voluntario:['', Validators.required],
      disponibilidad: [false],
    });

    if (this.voluntario) {
      this.voluntarioForm.patchValue({
        nombre_voluntario: this.voluntario.nombre_voluntario,
        apellido_voluntario: this.voluntario.apellido_voluntario,
        genero_voluntario: this.voluntario.genero_voluntario,
        direccion_voluntario:this.voluntario.direccion_voluntario,
        celular_voluntario: this.voluntario.celular_voluntario,
        email_voluntario:this.voluntario.email_voluntario,
        disponibilidad:this.voluntario.disponibilidad,
       
      });
    }
  }

  ngOnInit(): void {}

  guardarVoluntario() {

    const formData = this.voluntarioForm.value;
   

    if (this.voluntarioForm.valid) {
      const formData = this.voluntarioForm.value;
    
  
      if (this.voluntario) {
      } else {
        this.voluntarioService.postVoluntario(formData).subscribe(
          (response) => {
     
            this.voluntarioService.getVoluntarioList().subscribe(
              (data) => {
              },
              (error) => {
                console.error('Error al obtener datos de voluntarios:', error);
              }
            );
            this.dialogRef.close();
          },
          (error) => {
            console.error('Error al guardar el voluntario:', error);
          }
        );
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
