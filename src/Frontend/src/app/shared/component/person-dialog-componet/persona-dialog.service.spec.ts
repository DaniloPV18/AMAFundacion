import { TestBed } from '@angular/core/testing';

import { PersonaDialogService } from './persona-dialog.service';

describe('PersonaDialogService', () => {
  let service: PersonaDialogService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PersonaDialogService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
