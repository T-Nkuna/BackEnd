import { TestBed } from '@angular/core/testing';

import { AccessApplicationRouteGuardService } from './access-application-route-guard.service';

describe('AccessApplicationRouteGuardService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AccessApplicationRouteGuardService = TestBed.get(AccessApplicationRouteGuardService);
    expect(service).toBeTruthy();
  });
});
