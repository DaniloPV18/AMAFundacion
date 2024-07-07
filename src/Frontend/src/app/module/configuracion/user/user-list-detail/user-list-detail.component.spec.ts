import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserListDetailComponent } from './user-list-detail.component';

describe('UserListComponent', () => {
  let component: UserListDetailComponent;
  let fixture: ComponentFixture<UserListDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserListDetailComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserListDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
