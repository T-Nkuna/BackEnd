import { Component, OnInit } from '@angular/core';
import { ClientService } from '../../services/client.service';
import { ClientAccount } from '../../models/ClientAccount';
import { ConfigurationService } from '../../services/configuration.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-client-account',
  templateUrl: './create-client-account.component.html',
  styleUrls: ['./create-client-account.component.css']
})
export class CreateClientAccountComponent implements OnInit {

  clientAccount: ClientAccount;
  fields = [
    {
      displayName: "Name",
      value: "",
      name:"name"
    },
    {
      displayName: "Contact No",
      value: "",
      name: "contactNo"
    },
    {
      displayName: "Email",
      value: "",
      name: "email"
    }
  ];

  constructor(private _clientService: ClientService, private _configurationService: ConfigurationService, private _router: Router) {
    this._configurationService.displayedPageTitle = "Create Client Account";
  }

  ngOnInit() {
  }

  submitClicked() {
    let submittedRec:any = this.fields.map(field => ({ [field.name]: field.value })).reduce((x, y) => ({ ...x, ...y }), {});
    this._clientService.createClientAccount(<ClientAccount>submittedRec)
      .then((numResponse) => {
        if (numResponse > 0) {
          alert("Submitted");
        }
        else {
          alert("Item not saved");
        }
      })
      .catch(() => {
        alert("Unkown Error Occured");
      })
      .finally(() => {
        this.fields.forEach(field => { field.value = "" });
      })
  }

  backClicked() {
    this._router.navigate(["/clients"])
  }
}
