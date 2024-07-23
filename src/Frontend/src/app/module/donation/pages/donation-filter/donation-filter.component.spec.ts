import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DonationFilterComponent } from './donation-filter.component';

describe('DonationFilterComponent', () => {
  let component: DonationFilterComponent;
  let fixture: ComponentFixture<DonationFilterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DonationFilterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DonationFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
