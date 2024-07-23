import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilterBrigadesComponent } from './filter-brigades.component';

describe('FilterBrigadesComponent', () => {
  let component: FilterBrigadesComponent;
  let fixture: ComponentFixture<FilterBrigadesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FilterBrigadesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FilterBrigadesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
