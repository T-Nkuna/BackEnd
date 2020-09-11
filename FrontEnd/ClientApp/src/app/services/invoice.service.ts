import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigurationService } from './configuration.service';
import { ClientInvoice } from '../models/ClientInvoice';

@Injectable()
export class InvoiceService {

  serviceUrl = "";
  constructor(private _httpClient: HttpClient, private _configurationService: ConfigurationService) {
    this.serviceUrl = `${this._configurationService.serviceHost}/api/clientinvoices`;
  }

  getClientInvoices(clientId: number) {
    return this._httpClient.get<Array<ClientInvoice>>(`${this.serviceUrl}/${clientId}`).toPromise();
  }

  addInvoiceToClientAccount(clientAccountId: number, invoice: ClientInvoice) {

    return this._httpClient.put<number>(`${this.serviceUrl}/${clientAccountId}`, invoice).toPromise();
  }
}
