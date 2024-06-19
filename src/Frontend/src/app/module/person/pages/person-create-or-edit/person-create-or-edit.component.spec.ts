import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonCreateOrEditComponent } from './person-create-or-edit.component';

describe('PersonCreateOrEditComponent', () => {
  let component: PersonCreateOrEditComponent;
  let fixture: ComponentFixture<PersonCreateOrEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PersonCreateOrEditComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PersonCreateOrEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
