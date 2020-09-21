import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NbThemeModule, NbLayoutModule, NbSidebarModule, NbButtonModule,NbIconModule,NbInputModule, NbPopoverModule, NbSelectModule } from '@nebular/theme';
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
import { LoginComponent } from './components/login/login.component';
import { LoginService } from './services/login.service';
import { RegistrationComponent } from './components/registration/registration.component';
import { CookieService } from 'ngx-cookie-service';
import { AccessApplicationRouteGuardService } from './routeGuards/access-application-route-guard.service';
import { SimpleFormComponent } from './components/simple-form/simple-form.component';

@NgModule({
  declarations: [
    AppComponent,
    TableComponent,
    ClientsComponent,
    IconButtonComponent,
    CreateClientAccountComponent,
    AccountInvoicesComponent,
    CreateClientInvoiceComponent,
    LoginComponent,
    RegistrationComponent,
    SimpleFormComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: "login", component: LoginComponent },
      { path: "register", component: RegistrationComponent},
      { path: '', children: [
          { path: "clients", component: ClientsComponent, resolve: { clientsAccounts: ClientsRouteResolverService } },
          { path: "createclient", component: CreateClientAccountComponent },
          { path: "createinvoice/:clientId", component: CreateClientInvoiceComponent },
          { path: "invoices/:clientId", component: AccountInvoicesComponent }], canActivate: [AccessApplicationRouteGuardService]
      },
    ], { useHash:true }),
    BrowserAnimationsModule,
    NbThemeModule.forRoot({ name: 'cosmic' }),
    NbLayoutModule,
    NbEvaIconsModule,
    NbSidebarModule,
    NbButtonModule, NbIconModule,
    NbInputModule,
    NbPopoverModule,
    NbSelectModule
  ],
  providers: [
    ClientsRouteResolverService,
    ClientService,
    InvoiceService,
    LoginService,
    CookieService,
    AccessApplicationRouteGuardService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
