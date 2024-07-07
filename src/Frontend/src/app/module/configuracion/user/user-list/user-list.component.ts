import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { UserService } from '../../../../services/configuracion/user/user.service';
import { UserDTO } from '../../../../models/users/user-dto';
import { UserQuery } from '../../../../models/users/user-query';
import { DialogService } from 'primeng/dynamicdialog';
import { UserFormComponent } from '../user-form/user-form.component';
import { ToolsService } from '../../../../services/tools.service';


@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.sass'
})
export class UserListComponent implements OnInit {
  users: UserDTO[] = [];
  filter: UserQuery = { status: '', identification: '' }; // Puedes ajustar los campos según tus necesidades

  constructor(
    private userService: UserService,
    private dialogService: DialogService,
    private tools:ToolsService,
    private cdr: ChangeDetectorRef) { }
  openFilterPanel:boolean=true;
  ngOnInit(): void {
    // this.getUsers();
  }

  getUsers(): void {
    this.userService.getUsers(this.filter).subscribe((res) => {
      this.users = res;
      console.log(res)
      this.cdr.detectChanges();
    });
  }

  applyFilter(): void {

    this.getUsers();
  }

  New(): void {

    this.dialogService.open(UserFormComponent, {
      header: 'Nuevo usuario',
      width: 'auto',
      height: 'auto',
      data: { update: false},
      contentStyle: { 'max-height': '500px', 'min-width': '500px' },
      baseZIndex: 10000,
    })
      .onClose.subscribe((result) => {
          this.getUsers();
      });
  }

  openCloseFilter() {
    this.openFilterPanel = !this.openFilterPanel;
  }
}
