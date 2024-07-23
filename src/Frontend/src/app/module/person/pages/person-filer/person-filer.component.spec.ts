import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonFilerComponent } from './person-filer.component';

describe('PersonFilerComponent', () => {
  let component: PersonFilerComponent;
  let fixture: ComponentFixture<PersonFilerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PersonFilerComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PersonFilerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
