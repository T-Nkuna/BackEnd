import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateClientInvoiceComponent } from './create-client-invoice.component';

describe('CreateClientInvoiceComponent', () => {
  let component: CreateClientInvoiceComponent;
  let fixture: ComponentFixture<CreateClientInvoiceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateClientInvoiceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateClientInvoiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
