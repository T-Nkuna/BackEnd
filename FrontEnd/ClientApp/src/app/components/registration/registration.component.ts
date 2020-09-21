import { Component, OnInit } from '@angular/core';
import { ConfigurationService } from '../../services/configuration.service';
import { Router } from '@angular/router';
import { ClientService } from '../../services/client.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  formFields = [
    {
      name: "name",
      displayName: "Name",
      value: "",
      tagName: "input",
      type: "text",
      required:true
    },
    {
      name: "email",
      displayName: "Email",
      value: "",
      tagName: "input",
      type: "email",
      required:true
    },
    {
      name: "contactNo",
      displayName: "Contact No",
      value: "",
      tagName: "input",
      type: "text",
      required:true
    },
    {
      name: "password",
      displayName: "Password",
      value: "",
      tagName: "input",
      type: "password",
      required:true
    },
    {
      name: "confirmPassword",
      displayName: "Confirm Password",
      value: "",
      tagName: "input",
      type: "password",
      required:true
    }
  ];
  constructor(private _configurationService: ConfigurationService, private _router: Router, private _clientService: ClientService) {
    this._configurationService.displayedPageTitle = "Register";
  }

  ngOnInit() {
  }

  formSubmitted(value) {
    if (value.confirmPassword !== value.password) {
      alert("Password mismatch");
      return;
    }

    this._clientService.createClientAccount(value)
      .then(num => {
        if (num > 0) {
          alert("Account successfully created");
          this.formFields.forEach(field => field.value = "");
        }
      });
  }

  backClicked() {
    this._router.navigate(["login"]);
  }

}
