import { Component } from '@angular/core';
import { ConfigurationService } from './services/configuration.service';
import { LoginService } from './services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {

  constructor(public configurationService: ConfigurationService, private _loginService: LoginService, private _router: Router) {
    
  }

  signOut() {
    this._loginService.logOut().then(num => {
      if (num > 0) {
        this.configurationService.isAuthenticated = 0;
        this._router.navigate(["login"]);
      }
      else {
        alert('Sign Out Failed');
      }
    })
  }

}
