import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NbThemeModule, NbLayoutModule, NbSidebarModule, NbButtonModule,NbIconModule,NbInputModule } from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { TableComponent } from './components/table/table.component';
import { ClientsComponent } from './components/clients/clients.component';
import { ClientsRouteResolverService } from './routeResolvers/clients-route-resolver.service';
import { ClientService } from './services/client.service';
import { IconButtonComponent } from './components/icon-button/icon-button.component';
import { CreateClientAccountComponent } from './components/create-client-account/create-client-account.component';
import { InvoiceService } from './services/invoice.service';
import { AccountInvoicesComponent } from './components/account-invoices/account-invoices.component';
import { CreateClientInvoiceComponent } from './components/create-client-invoice/create-client-invoice.component';

@NgModule({
  declarations: [
    AppComponent,
    TableComponent,
    ClientsComponent,
    IconButtonComponent,
    CreateClientAccountComponent,
    AccountInvoicesComponent,
    CreateClientInvoiceComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: "clients", component: ClientsComponent, resolve: { clientsAccounts: ClientsRouteResolverService } },
      { path: "createclient", component: CreateClientAccountComponent },
      { path: "createinvoice/:clientId", component: CreateClientInvoiceComponent },
      { path: "invoices/:clientId", component: AccountInvoicesComponent },
      { path: '', pathMatch: 'full', redirectTo: "clients" },
    ], { useHash:true }),
    BrowserAnimationsModule,
    NbThemeModule.forRoot({ name: 'cosmic' }),
    NbLayoutModule,
    NbEvaIconsModule,
    NbSidebarModule,
    NbButtonModule, NbIconModule,
    NbInputModule
  ],
  providers: [
    ClientsRouteResolverService,
    ClientService,
    InvoiceService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
