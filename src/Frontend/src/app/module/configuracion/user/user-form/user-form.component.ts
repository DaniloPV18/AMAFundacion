import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { FormGroup, Validators } from '@angular/forms';
import { IUserForm, IUserUpdateForm } from '../../../../models/users/user-form';
import { FormService } from '../../../../shared/services/from.service';
import { ConfSystemServiceService } from '../../../../data/conf-system-service.service';
import { UserService } from '../../../../services/configuracion/user/user.service';
import { catchError, elementAt, of } from 'rxjs';
import { ALL } from 'dns';
import { Alert } from 'bootstrap';
import { error } from 'console';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrl: './user-form.component.sass'
})

export class UserFormComponent implements OnInit {
  @Input() isNewUser: boolean = true;
  constructor(
    private ref: DynamicDialogRef,
    public config: DynamicDialogConfig,
    private formService: FormService,
    private userService: UserService,
  ) { }
  userForm!: FormGroup
  formData!: IUserForm;
  formDataUpdate!:  IUserUpdateForm;
  update: boolean = false;
  label: any = 'Crear';
  view: boolean = false;
  ngOnInit(): void {
    this.InitializeData();
  }



  InitializeData() {

    this.update = this.config.data.update;
    this.view = this.config.data.view;

    if (this.update) {
      this.label = 'Actualizar';
      this.buildFormData();
    } else {
      this.label = 'Crear';
      this.buildForm();
    }

  }


  closeDialog(): void {
    this.ref.close(); // Cierra el diálogo

  }

  private buildForm() {
    if (this.update) {
      this.formDataUpdate = {
        email: '',
        id: 0,
        identification: '',
        name: '',
        password:'',
        status: 'A',
        ...this.config.data.user
      };
      this.userForm = this.formService.createFormGroup<IUserUpdateForm>(this.formDataUpdate);
    }
    else {
      this.formData = {
        email: '',
        id: 0,
        identification: '',
        name: '',
        password: '',
        status: 'A',
        ...this.config.data.user
      };
      this.userForm = this.formService.createFormGroup<IUserForm>(this.formData);
    }

    this.validator();
  }

  private validator() {
    this.userForm.get('identification')?.setValidators([Validators.required, Validators.min(8)]);
    this.userForm.get('name')?.setValidators([Validators.required, Validators.min(5)]);
    this.userForm.get('email')?.setValidators([Validators.required, Validators.min(5)]);
    this.userForm.get('status')?.setValidators([Validators.required, Validators.min(5)]);
    if (!this.update){
       this.userForm.get('password')?.setValidators([Validators.required, Validators.min(4)]);
    }

  }

  private buildFormData() {
    this.formDataUpdate = {
      email: '',
      id: 0,
      identification: '',
      name: '',
      status: 'A',
      //password: null,
      ...this.config.data.user,
    };
    this.userForm = this.formService.createFormGroup<IUserUpdateForm>(this.formDataUpdate);
    this.validator();

  }

  Save() {

    if (this.update) {
      this.userService.Put(this.userForm.value)
        .pipe(
          catchError((error: any) => {
            return of();
          })
        ).subscribe(() => {
          this.closeDialog();
          return true;
        });;
    }

    if (!this.update) {
      this.userService.Create(this.userForm.value)
        .pipe(
          catchError((error: any) => {

            return of();
          })
        ).subscribe(() => {
          this.closeDialog();
          return true;

        });
    }
  }
}
