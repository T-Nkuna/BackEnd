import { Component, OnInit, ViewChild,ElementRef,AfterViewInit,SimpleChanges, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute,Router } from '@angular/router';
import { ConfigurationService } from '../../services/configuration.service';
import { ClientAccount } from '../../models/ClientAccount';
import { RowAction, TableComponent } from '../table/table.component';
import { ClientService } from '../../services/client.service';
import { InvoiceService } from '../../services/invoice.service';
import { NbPopoverDirective } from '@nebular/theme';

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.css']
})
export class ClientsComponent implements OnInit , AfterViewInit{

  clientAccounts: ClientAccount[] = [];
  rowActions: RowAction[] = [];
  selectedClientAcount: ClientAccount;
  popupClientEmail: string;
  popupClientContactNo: string;
  popupClientName: string;
  @ViewChild('editClientAccountForm') editClientAccountForm: ElementRef;
  @ViewChild('clientAccountsTable') clientAccountsTable: TableComponent;
  tableIsReady: boolean= false;
  constructor(
    private _activatedRoute: ActivatedRoute,
    private _router: Router,
    private _configurationService: ConfigurationService,
    private _clientService: ClientService,
    private _cd:ChangeDetectorRef
  )
  {
    this.rowActions = [
      { icon: "eye-outline", text: "", rowclick: this.viewClientAccount },
      { icon: "edit-outline", text: "", rowclick: this.updateClientAccount },
      { icon: "trash-2-outline", text: "", rowclick: this.deleteClientAccount }
    ];
  }

  ngOnInit() {
    this._configurationService.displayedPageTitle = "Clients";
    this._activatedRoute.data.subscribe(data => {
      this.clientAccounts = data.clientsAccounts;
     
    })
  }

  ngAfterViewInit() {
    this.rowActions = this.getUpdatedRowActions(this.editClientAccountForm);
    this._cd.detectChanges();
  }
 
  getUpdatedRowActions(templateRef: ElementRef) {
  
    return this.rowActions.map((rowAction, index) => index == 1 ? { ...rowAction, popupTrigger: true, popupContent: templateRef } : rowAction);
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

  updateClientAccount = (clientAccount: ClientAccount) => {
    this.selectedClientAcount = clientAccount;
    this.popupClientName = this.selectedClientAcount.name;
    this.popupClientEmail = this.selectedClientAcount.email;
    this.popupClientContactNo = this.selectedClientAcount.contactNo;
  }

  submitEditClientAccountForm() {

    let newRec = { ...this.selectedClientAcount, email: this.popupClientEmail, contactNo: this.popupClientContactNo, name: this.popupClientName };
    this._clientService
      .updateClientAccount(newRec)
      .then(num => {
        if (num > 0) {
          alert('Submitted !');
          this.popupClientContactNo = "";
          this.popupClientEmail = "";
          this.popupClientName = "";
          this.clientAccounts = this.clientAccounts.map((rec) => rec.clientAccountId == newRec.clientAccountId ? { ...rec, ...newRec } : rec);
        }
        else {
          alert("No changes detected");
        }
      }).catch(() => {
        alert("Unkown Error!");
      })
    
  }
}
