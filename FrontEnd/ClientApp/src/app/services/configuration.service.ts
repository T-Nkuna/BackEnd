import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConfigurationService {

  serviceHost = "https://localhost:44386";

  displayedPageTitle = "Clients";
  constructor() { }
}
