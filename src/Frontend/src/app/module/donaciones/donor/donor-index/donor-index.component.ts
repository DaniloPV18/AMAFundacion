import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialog } from '@angular/material/dialog';
import { DonorCreateComponent } from '../donor-create/donor-create.component';
import { PersonService } from '../../../person/services/person.service';
@Component({
  selector: 'app-donor-index',
  templateUrl: './donor-index.component.html',
  styleUrl: './donor-index.component.sass',
})
export class DonorIndexComponent {
  visible: boolean = false;

  constructor(
    public dialog: MatDialog,
    private personDonorService: PersonService
  ) {}

  ngOnInit() {}

  callNavigateToCreate() {
    this.personDonorService.triggerCreateDonor();
  }


  closeDialog() {
    this.visible = false;
  }

 
}
