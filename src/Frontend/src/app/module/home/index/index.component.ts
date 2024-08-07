import { Component } from '@angular/core';
import { BrigadeService } from '../../brigada/services/brigade.service';
import { DonationService } from '../../donation/services/donation.service';
import { VoluntarioService } from '../../voluntario/voluntario.service';
import { PersonService } from '../../person/services/person.service';
import { beneficiarioService } from '../../beneficiario/services/beneficiario.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrl: './index.component.sass',
})
export class IndexComponent {
  donacionesCount: number = 0;
  voluntariosCount: number = 0;
  brigadeCount: number = 0;
  beneficiariosCount: number = 0;
  constructor(
    private donationService: DonationService,
    private voluntarioService: VoluntarioService,
    private personService: PersonService,
    private brigadeService: BrigadeService,
    private beneficiarioService: beneficiarioService
  ) {}

  ngOnInit(): void {
    this.loadBrigadeCount();
  }

  loadBrigadeCount(): void {
    this.donationService.getDonationCount().subscribe({
      next: (res: any) => {
        if (res && res.result !== undefined) {
          this.donacionesCount = res.result;
        } else {
          this.donacionesCount = -51;
        }
      },
      error: (error) => {
        this.donacionesCount = 344404;
        console.error('Error fetching brigade count', error);
      },
    });
    //this.voluntarioService.getVoluntarioCount().subscribe({
    //  next: (res: any) => {
    //    if (res && res.result !== undefined) {
    //      //this.voluntariosCount = res.result;
    //    } else {
    //      //this.voluntariosCount = -51;
    //    }
    //  },
    //  error: (error) => {
    //    //this.voluntariosCount = 344404;
    //    //console.error('Error fetching brigade count', error);
    // },
    //});
    this.personService.getVoluntarioCount().subscribe({
      next: (res: any) => {
        if (res && res.result !== undefined) {
          this.voluntariosCount = res.result;
        } else {
          this.voluntariosCount = -51;
        }
      },
      error: (error:any) => {
        this.voluntariosCount = 344404;
        console.error('Error fetching brigade count', error);
      },
    });
    this.brigadeService.getBrigadeCount().subscribe({
      next: (res: any) => {
        if (res && res.result !== undefined) {
          this.brigadeCount = res.result;
        } else {
          this.brigadeCount = -51;
        }
      },
      error: (error) => {
        this.brigadeCount = 344404;
        console.error('Error fetching brigade count', error);
      },
    });
    this.beneficiarioService.getBeneficiarioCount().subscribe({
      next: (res: any) => {
        if (res && res.result !== undefined) {
          this.beneficiariosCount = res.result;
        } else {
          console.error('Unexpected response format:', res);
          this.beneficiariosCount = -51;
        }
      },
      error: (error) => {
        this.beneficiariosCount = 344404;
        console.error('Error fetching brigade count', error);
      },
    });
  }
}
