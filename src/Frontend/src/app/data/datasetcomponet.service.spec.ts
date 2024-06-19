import { TestBed } from '@angular/core/testing';

import { DataSetComponentService } from './datasetcomponet.service';

describe('DatasetcomponetService', () => {
  let service: DataSetComponentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DataSetComponentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
