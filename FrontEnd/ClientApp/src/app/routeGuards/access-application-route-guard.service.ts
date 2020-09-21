import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { ConfigurationService } from '../services/configuration.service';

@Injectable()
export class AccessApplicationRouteGuardService implements CanActivate {

  constructor(private _configurationService: ConfigurationService, private _router: Router) {
    
  }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {

    if (this._configurationService.isAuthenticated) {
        return true;
      }

      this._router.navigate(["login"]);
      return false;
    }

}
