import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DonationCreateOrEditComponent } from './donation-create-or-edit.component';

describe('DonationCreateOrEditComponent', () => {
  let component: DonationCreateOrEditComponent;
  let fixture: ComponentFixture<DonationCreateOrEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DonationCreateOrEditComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DonationCreateOrEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
