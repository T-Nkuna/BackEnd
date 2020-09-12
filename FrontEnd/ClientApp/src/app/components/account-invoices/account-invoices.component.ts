import { Component, OnInit } from '@angular/core';
import { ConfigurationService } from '../../services/configuration.service';
import { Router, ActivatedRoute } from '@angular/router';
import { InvoiceService } from '../../services/invoice.service';
import { ClientInvoice } from '../../models/ClientInvoice';
import { RowAction } from '../table/table.component';

@Component({
  selector: 'app-account-invoices',
  templateUrl: './account-invoices.component.html',
  styleUrls: ['./account-invoices.component.css']
})
export class AccountInvoicesComponent implements OnInit {

  clientId = -1;
  accountInvoices: ClientInvoice[] = [];
  rowActions: RowAction[] = []
  loading = false;
  constructor(private _configurationService: ConfigurationService, private _router: Router, private _activatedRoute: ActivatedRoute, private _invoiceService: InvoiceService) {
    this._configurationService.displayedPageTitle = "Client's Invoices";
    this.rowActions = [
      { icon: "trash-2-outline", text: "", rowclick:this.deleteClientInvoice}
    ];
  }

  ngOnInit() {
    this.clientId = parseInt(this._activatedRoute.snapshot.paramMap.get("clientId"))
    this.getClientsInvoices(this.clientId)
  }

  deleteClientInvoice = (clientInvoice: ClientInvoice) =>{

    this._invoiceService.deleteInvoice(clientInvoice.clientInvoiceId)
      .then(num => {
        if (num > 0) {
          alert("Delete Successful");
          this.accountInvoices = this.accountInvoices.filter(accInv => accInv.clientInvoiceId !== clientInvoice.clientInvoiceId)
        }
        else {
          alert("Delete Failed");
        }
      }).catch(() => {
        alert("Unknown Error");
      });
  }

  getClientsInvoices(clientId: number) {
    this.loading = true;
    this._invoiceService.getClientInvoices(clientId)
      .then(invoices => {
        this.loading = false;
        this.accountInvoices =invoices;
      }).catch(() => {
        this.loading = false;
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
