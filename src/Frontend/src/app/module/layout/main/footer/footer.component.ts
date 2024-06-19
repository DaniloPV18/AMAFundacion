import { Component, HostBinding } from '@angular/core';
import { DatePipe  } from '@angular/common';

@Component({
  selector: 'app-footer',
  // standalone: true,
  // imports: [CommonModule],
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.sass'
})


export class FooterComponent {

  @HostBinding('class') classes: string = 'main-footer';
  public appVersion = '0.0.1';
  public currentYear: string;

  constructor(private datePipe: DatePipe) {
    // Obtén la fecha actual y dale formato
    const currentDate = new Date();
    this.currentYear = this.datePipe.transform(currentDate, 'yyyy')??"";
  }
}
