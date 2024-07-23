import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SmtpAddComponent } from './smtp-add.component';

describe('SmtpAddComponent', () => {
  let component: SmtpAddComponent;
  let fixture: ComponentFixture<SmtpAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SmtpAddComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SmtpAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
