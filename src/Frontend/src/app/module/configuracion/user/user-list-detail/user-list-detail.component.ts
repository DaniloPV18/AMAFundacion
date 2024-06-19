import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserService } from '../../../../services/configuracion/user/user.service';
import { UserDTO } from '../../../../models/users/user-dto';
import { UserQuery } from '../../../../models/users/user-query';
import { DialogService } from 'primeng/dynamicdialog';
import { UserFormComponent } from '../user-form/user-form.component';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Observable, catchError, of } from 'rxjs';




@Component({
  selector: 'app-user-list-detail',
  templateUrl: './user-list-detail.component.html',
  styleUrl: './user-list-detail.component.sass'
})
export class UserListDetailComponent implements OnInit {
  @Input() users: UserDTO[] = [];
  filter: UserQuery = { status: '', identification: '' }; // Puedes ajustar los campos según tus necesidades

  constructor(
    private userService: UserService,
    private dialogService: DialogService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService) { }
  loading: boolean = true

  ngOnInit(): void {
    this.loading = true;
    this.getUsers();

  }

  getUsers(): void {
    this.userService.getUsers(this.filter).pipe(
      catchError((error:any) => {
        this.loading = false;
        return of();
      })
    ).subscribe((users) => {
      this.users = users;
      this.loading = false;
    });

  }

  applyFilter(): void {
    this.getUsers();
  }
  Edit(user: UserDTO): void {

    this.dialogService.open(UserFormComponent, {
      header: 'Modificar usuario',
      width: 'auto',
      height: 'auto',
      data: { update: true, user: user },
      contentStyle: { 'max-height': '500px', 'min-width': '500px' },
      baseZIndex: 10000,
    })
      .onClose.subscribe((result) => {

          this.getUsers();
      });
  }


  Delete(user: UserDTO): void {


    this.confirmationService.confirm({
       message: 'Se eliminará el usuario 999999999999999 - System',
      header: '¿Está seguro que quiere eliminar el usuario?',
      icon: 'pi pi-exclamation-triangle',
      closeOnEscape: true,
      acceptButtonStyleClass: 'btn btn-success ml-2',
      rejectButtonStyleClass: 'btn btn-danger',
      acceptLabel: 'No',
      rejectLabel: 'Si, Eliminar',
      accept: () => {
        console.log('no eliminado');
      },
      reject: () => {
        console.log('elimiado');
      },
    });
  }
}
