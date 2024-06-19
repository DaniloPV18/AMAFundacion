import { Component } from '@angular/core';
// import { CommonModule } from '@angular/common';
import { MatDialog } from '@angular/material/dialog';
import { VoluntarioCreateComponent } from '../voluntario-create/voluntario-create.component';
import { PersonService } from '../../person/services/person.service';

@Component({
  selector: 'app-voluntario-index',
  templateUrl: './voluntario-index.component.html',
  styleUrls: ['./voluntario-index.component.sass'],
})
export class VoluntarioIndexComponent {
  visible: boolean = false;
  constructor(
    public dialog: MatDialog,
    private personDonorService: PersonService
  ) {}

  showDialog() {
    const dialogRef = this.dialog.open(VoluntarioCreateComponent, {
      width: '800px',
      data: {
        title: 'Crear Voluntario',
      },
    });
  }
  closeDialog() {
    this.visible = false;
  }
  callNavigateToCreate() {
    this.personDonorService.triggerCreateDonor();
  }
  
}
