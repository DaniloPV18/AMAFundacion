import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DonorFilterComponent } from './donor-filter.component';

describe('DonorFilterComponent', () => {
  let component: DonorFilterComponent;
  let fixture: ComponentFixture<DonorFilterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DonorFilterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DonorFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
