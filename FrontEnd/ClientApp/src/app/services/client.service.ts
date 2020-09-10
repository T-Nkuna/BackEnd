import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigurationService } from './configuration.service';
import { ClientAccount } from '../models/ClientAccount';
import { ClientInvoice } from '../models/ClientInvoice';

@Injectable()
export class ClientService {

  serviceUrl = "";
  constructor(private _httpClient: HttpClient, private _configurationService: ConfigurationService) {
    this.serviceUrl = `${_configurationService.serviceHost}/api/clientaccounts`;
  }

  getClientAccounts() {
    return this._httpClient.get<ClientAccount[]>(this.serviceUrl).toPromise();
  }

  viewClientAccountInvoices(clientAccountId: number) {
    return this._httpClient.get<ClientInvoice[]>(`${this.serviceUrl}/${clientAccountId}`)
      .toPromise();
  }

  deleteClientAccount(clientAccountId: number) {
    return this._httpClient.delete<number>(`${this.serviceUrl}/${clientAccountId}`).toPromise();
  }

  createClientAccount(clientAccount: ClientAccount) {
    return this._httpClient.post<number>(this.serviceUrl, clientAccount).toPromise();
  }


}
