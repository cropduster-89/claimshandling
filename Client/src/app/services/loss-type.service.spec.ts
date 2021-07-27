import { TestBed } from '@angular/core/testing';

import { LossTypeService } from './loss-type.service';

describe('LossTypeService', () => {
  let service: LossTypeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LossTypeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
