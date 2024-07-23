import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfirmationPasswordComponent } from './confirmation-password.component';

describe('ConfirmationPasswordComponent', () => {
  let component: ConfirmationPasswordComponent;
  let fixture: ComponentFixture<ConfirmationPasswordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ConfirmationPasswordComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ConfirmationPasswordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
