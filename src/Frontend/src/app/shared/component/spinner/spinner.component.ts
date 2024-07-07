import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  styleUrl: './spinner.component.sass'
})
export class SpinnerComponent {
  @Input() visible!: boolean;
  constructor() { }
}
