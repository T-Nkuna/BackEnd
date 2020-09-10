import { Component, OnInit } from '@angular/core';
import { ClientInvoice } from '../../models/ClientInvoice';
import { Router, ActivatedRoute } from '@angular/router';
import { InvoiceService } from '../../services/invoice.service';
import { ConfigurationService } from '../../services/configuration.service';

@Component({
  selector: 'app-create-client-invoice',
  templateUrl: './create-client-invoice.component.html',
  styleUrls: ['./create-client-invoice.component.css']
})
export class CreateClientInvoiceComponent implements OnInit {

  clientInvoice: ClientInvoice;
  clientId: number;
  fields = [
    {
      displayName: "Invoice Amount",
      value: "",
      name: "invoiceAmount"
    }
  ];
  constructor(
    private _activatedRoute: ActivatedRoute,
    private _invoiceService: InvoiceService,
    private _configurationService: ConfigurationService,
    private _router:Router
  ) { }

  ngOnInit() {
    this._configurationService.displayedPageTitle = "Create Invoice";
    this.clientId = parseInt(this._activatedRoute.snapshot.paramMap.get("clientId"));
  }

  backClicked = ()=>{
    this._router.navigate(['invoices', this.clientId]);
  }

  submitClicked(formIsValid: boolean) {
    if (!formIsValid) {
      alert("Amount Must be Numeric")
    }
    else {
      this._invoiceService.addInvoiceToClientAccount(this.clientId, (<ClientInvoice>{ invoiceAmount: parseFloat(this.fields[0].value), invoiceOwedAmount: 0 }))
        .then(num => {
          if (num > 0) {
            alert("Submitted");
            this.fields[0].value = "";
          }
          else {
            alert("Failed to Submit")
          }
        }).catch(()=>alert("Unkown Error!"))
    }
  }
}
