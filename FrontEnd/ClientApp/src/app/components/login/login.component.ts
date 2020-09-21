import { Component, OnInit } from '@angular/core';
import { ConfigurationService } from '../../services/configuration.service';
import { LoginService } from '../../services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formFields = [
    { name: "username", displayName: "Username", type: "text",value:"" },
    { name: "password", displayName: "Password", type: "password",value:"" }
  ];
  constructor(private _configurationService: ConfigurationService, private _loginService: LoginService,private _router:Router) {
    this._configurationService.displayedPageTitle = "Login";
  }

  ngOnInit() {
  }

  loginClicked(loginCredentials: any) {
    this._loginService.login(loginCredentials.username, loginCredentials.password)
      .then(num => {
        if (num > 0) {
          this._configurationService.isAuthenticated = 1;
          this._router.navigate(["clients"]);
        }
        else {
          alert('Invalid credentials');
        }
      })

  }

  registerClicked() {
    this._router.navigate(["register"]);
  }

}
