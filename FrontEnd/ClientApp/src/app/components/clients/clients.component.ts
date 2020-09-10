import { Component, OnInit } from '@angular/core';
import { ActivatedRoute,Router } from '@angular/router';
import { ConfigurationService } from '../../services/configuration.service';
import { ClientAccount } from '../../models/ClientAccount';
import { RowAction } from '../table/table.component';
import { ClientService } from '../../services/client.service';
import { InvoiceService } from '../../services/invoice.service';

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.css']
})
export class ClientsComponent implements OnInit {

  clientAccounts: ClientAccount[] = [];
  rowActions: RowAction[] = [

  ];
  constructor(
    private _activatedRoute: ActivatedRoute,
    private _router: Router,
    private _congigurationService: ConfigurationService,
    private _clientService: ClientService
    ) {
    this.rowActions = [
      { icon: "eye-outline", text: "", rowclick: this.viewClientAccount },
      { icon: "trash-2-outline", text: "", rowclick:this.deleteClientAccount }
    ]
  }

  ngOnInit() {
    this._congigurationService.displayedPageTitle = "Clients";
    this._activatedRoute.data.subscribe(data => {
      this.clientAccounts = data.clientsAccounts;
    })
  }

  viewClientAccount = (clientAccount: ClientAccount) => {
    this._router.navigate(["invoices", clientAccount.clientAccountId]);
  }

  deleteClientAccount = (clientAccount: ClientAccount)=> {
    this._clientService.deleteClientAccount(clientAccount.clientAccountId)
      .then(num => {
        if (num > 0) {
          alert("Delete Successful");
          this.clientAccounts = this.clientAccounts.filter(rec => rec.clientAccountId !== clientAccount.clientAccountId);
        }
        else {
          alert("Delete Failed");
        }
      }).catch(() => {
        alert("Unkwon Error !");
      })
  }

  addClientAccount() {
    this._router.navigate(["createclient"]);
  }

}
