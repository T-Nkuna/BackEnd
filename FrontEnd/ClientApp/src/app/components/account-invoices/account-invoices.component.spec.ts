import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountInvoicesComponent } from './account-invoices.component';

describe('AccountInvoicesComponent', () => {
  let component: AccountInvoicesComponent;
  let fixture: ComponentFixture<AccountInvoicesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccountInvoicesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountInvoicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
