import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrigadeService } from '../../brigada/services/brigade.service';
import { Result } from '../../../core/interfaces/result';

@Component({
  selector: 'app-index',
  // standalone: true,
  // imports: [CommonModule],
  templateUrl: './index.component.html',
  styleUrl: './index.component.sass'
})
export class IndexComponent {
  brigadeCount: number = 0;
  constructor(private brigadeService: BrigadeService) { }

  ngOnInit(): void {
    this.loadBrigadeCount();
  }

  loadBrigadeCount(): void {
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
  }
}
