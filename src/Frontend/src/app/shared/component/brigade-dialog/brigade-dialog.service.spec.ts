import { TestBed } from '@angular/core/testing';

import { BrigadeDialogService } from './brigade-dialog.service';

describe('BrigadeDialogService', () => {
  let service: BrigadeDialogService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BrigadeDialogService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
