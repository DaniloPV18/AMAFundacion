import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DonationIndexComponent } from './donation-index.component';

describe('DonationIndexComponent', () => {
  let component: DonationIndexComponent;
  let fixture: ComponentFixture<DonationIndexComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DonationIndexComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DonationIndexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
