import { TestBed } from '@angular/core/testing';

import { PersonAddressService } from './person-address.service';

describe('AddressService', () => {
  let service: PersonAddressService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PersonAddressService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
