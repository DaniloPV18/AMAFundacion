import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateOrEditBrigadesComponent } from './create-or-edit-brigades.component';

describe('CreateOrEditBrigadesComponent', () => {
  let component: CreateOrEditBrigadesComponent;
  let fixture: ComponentFixture<CreateOrEditBrigadesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateOrEditBrigadesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreateOrEditBrigadesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
