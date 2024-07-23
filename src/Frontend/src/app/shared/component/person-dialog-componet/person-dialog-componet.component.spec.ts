import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonDialogComponet } from './person-dialog-componet.component';

describe('PersonDialogComponetComponent', () => {
  let component: PersonDialogComponet;
  let fixture: ComponentFixture<PersonDialogComponet>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PersonDialogComponet]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PersonDialogComponet);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
