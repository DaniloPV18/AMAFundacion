import { TestBed } from '@angular/core/testing';

import { SmtpConfigurationService } from './smtp.service';

describe('SmtpConfigurationService', () => {
  let service: SmtpConfigurationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SmtpConfigurationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
