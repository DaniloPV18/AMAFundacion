import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BrigadeDialogComponent } from './brigade-dialog.component';

describe('BrigadeDialogComponent', () => {
  let component: BrigadeDialogComponent;
  let fixture: ComponentFixture<BrigadeDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BrigadeDialogComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BrigadeDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
