import { Injectable } from '@angular/core';
import { ConfigurationService } from './configuration.service';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class LoginService {

  serviceUrl = "";
  constructor(private _configurationService: ConfigurationService, private _httpClient: HttpClient) {
    this.serviceUrl = `${this._configurationService.serviceHost}/api/clientaccounts`;
  }

  login(username: string, password: string) {

    return this._httpClient.post<number>(`${this.serviceUrl}/authenticate`, { username, password }, { withCredentials:true }).toPromise();
 
  }

  logOut() {
    return this._httpClient.get<number>(`${this.serviceUrl}/signout`).toPromise();
  }
}
