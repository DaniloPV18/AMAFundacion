import { Component, OnInit } from '@angular/core';
import { AppService } from '../../../../../services/app.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrl: './user.component.sass'
})
export class UserComponent implements OnInit {
  public user:any;

  constructor(private appService: AppService) {}

  ngOnInit(): void {
      this.user = this.appService.user;
  }

  logout() {
      // this.appService.logout();
  }


}
