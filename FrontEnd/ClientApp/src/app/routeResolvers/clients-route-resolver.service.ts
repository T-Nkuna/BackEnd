import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { ClientAccount } from '../models/ClientAccount';
import { ClientService } from '../services/client.service';

@Injectable()
export class ClientsRouteResolverService implements Resolve<ClientAccount[]> {

  constructor(private _clientService: ClientService) { }
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<ClientAccount[]> {
    return this._clientService.getClientAccounts();
    }
}
