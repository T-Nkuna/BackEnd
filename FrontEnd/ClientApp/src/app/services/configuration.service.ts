import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConfigurationService {

  
  private _env = "dev";
  displayedPageTitle = "Clients";
  constructor() { }

  get isAuthenticated() {
    return parseInt(sessionStorage.getItem("authenticated"));
  }

  set isAuthenticated(value) {
     sessionStorage.setItem("authenticated", isNaN(value)?"0":value.toString());
  }

  get serviceHost() {
    return this._env === "dev" ? "http://localhost:44309" : "https://invoice.etiocs.co.za";
  }
}
