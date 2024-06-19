import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListBrigadesComponent } from './list-brigades.component';

describe('ListBrigadesComponent', () => {
  let component: ListBrigadesComponent;
  let fixture: ComponentFixture<ListBrigadesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListBrigadesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ListBrigadesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
