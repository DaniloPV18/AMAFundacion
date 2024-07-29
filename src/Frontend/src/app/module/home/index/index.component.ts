import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrigadeService } from '../../brigada/services/brigade.service';
import { DonationService } from '../../donation/services/donation.service';
import { VoluntarioService } from '../../voluntario/voluntario.service';
import { beneficiarioService } from '../../beneficiario/services/beneficiario.service';
import { Result } from '../../../core/interfaces/result';

@Component({
  selector: 'app-index',
  // standalone: true,
  // imports: [CommonModule],
  templateUrl: './index.component.html',
  styleUrl: './index.component.sass'
})
export class IndexComponent {
  donacionesCount: number = 0;
  voluntariosCount: number = 0;
  brigadeCount: number = 0;
  beneficiariosCount: number = 0;
  constructor(
    private donationService: DonationService,
    private voluntarioService: VoluntarioService,
    private brigadeService: BrigadeService,
    private beebeficiarioService: beneficiarioService
  ) { }

  ngOnInit(): void {
    this.loadBrigadeCount();
  }

  loadBrigadeCount(): void {
    this.donationService.getDonationCount().subscribe(
      (res:any) => {
        if (res && res.result !== undefined) {
          this.donacionesCount = res.result;
        } else {
          console.error('Unexpected response format:', res);
          this.donacionesCount = 0; 
        }
        
      },
      (error) => {
        console.log("Errrrror");
        this.donacionesCount = 10;
        console.error('Error fetching brigade count', error);
      }
    );
    this.voluntarioService.getVoluntarioCount().subscribe(
      (res:any) => {
        if (res && res.result !== undefined) {
          this.voluntariosCount = res.result;
        } else {
          console.error('Unexpected response format:', res);
          this.voluntariosCount = 0; 
        }
        
      },
      (error) => {
        console.log("Errrrror");
        this.voluntariosCount = 10;
        console.error('Error fetching brigade count', error);
      }
    );
    this.brigadeService.getBrigadeCount().subscribe(
      (res:any) => {
        if (res && res.result !== undefined) {
          this.brigadeCount = res.result;
        } else {
          console.error('Unexpected response format:', res);
          this.brigadeCount = 0; 
        }
        
      },
      (error) => {
        console.log("Errrrror");
        this.brigadeCount = 10;
        console.error('Error fetching brigade count', error);
      }
    );
    this.beebeficiarioService.getBeneficiarioCount().subscribe(
      (res:any) => {
        if (res && res.result !== undefined) {
          this.beneficiariosCount = res.result;
        } else {
          console.error('Unexpected response format:', res);
          this.beneficiariosCount = 0; 
        }
        
      },
      (error) => {
        console.log("Errrrror");
        this.beneficiariosCount = 10;
        console.error('Error fetching brigade count', error);
      }
    );
  }
}
