import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IndexBrigadesComponent } from './index-brigades.component';

describe('IndexBrigadesComponent', () => {
  let component: IndexBrigadesComponent;
  let fixture: ComponentFixture<IndexBrigadesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [IndexBrigadesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(IndexBrigadesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
