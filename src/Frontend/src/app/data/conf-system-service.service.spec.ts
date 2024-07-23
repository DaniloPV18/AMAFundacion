import { TestBed } from '@angular/core/testing';

import { ConfSystemServiceService } from './conf-system-service.service';

describe('ConfSystemServiceService', () => {
  let service: ConfSystemServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ConfSystemServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
