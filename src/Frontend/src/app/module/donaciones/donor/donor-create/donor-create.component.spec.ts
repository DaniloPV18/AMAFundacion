import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DonorCreateComponent } from './donor-create.component';

describe('DonorCreateComponent', () => {
  let component: DonorCreateComponent;
  let fixture: ComponentFixture<DonorCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DonorCreateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DonorCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
