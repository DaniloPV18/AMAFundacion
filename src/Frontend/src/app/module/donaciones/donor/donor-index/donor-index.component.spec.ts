import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DonorIndexComponent } from './donor-index.component';

describe('DonorIndexComponent', () => {
  let component: DonorIndexComponent;
  let fixture: ComponentFixture<DonorIndexComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DonorIndexComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DonorIndexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
