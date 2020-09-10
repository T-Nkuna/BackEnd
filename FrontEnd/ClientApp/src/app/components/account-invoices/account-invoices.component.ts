import { Component, OnInit } from '@angular/core';
import { ConfigurationService } from '../../services/configuration.service';
import { Router, ActivatedRoute } from '@angular/router';
import { InvoiceService } from '../../services/invoice.service';
import { ClientInvoice } from '../../models/ClientInvoice';

@Component({
  selector: 'app-account-invoices',
  templateUrl: './account-invoices.component.html',
  styleUrls: ['./account-invoices.component.css']
})
export class AccountInvoicesComponent implements OnInit {

  clientId = -1;
  accountInvoices: ClientInvoice[] = [];
  constructor(private _configurationService: ConfigurationService, private _router: Router, private _activatedRoute: ActivatedRoute, private _invoiceService: InvoiceService) {
    this._configurationService.displayedPageTitle = "Client's Invoices";
  }

  ngOnInit() {
    this.clientId = parseInt(this._activatedRoute.snapshot.paramMap.get("clientId"))
  }

  getClientsInvoices() {
    this._invoiceService.getClientInvoices(this.clientId)
      .then(invoices => {
        console.log(invoices);
      }).catch(() => {
        alert("Unkown Error!");
      });
  }

   addNewInvoice = ()=> {
    this._router.navigate(['createinvoice',this.clientId])
   }

  backClicked = () => {
    this._router.navigate(["clients"]);
  }
}
