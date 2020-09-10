import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateClientAccountComponent } from './create-client-account.component';

describe('CreateClientAccountComponent', () => {
  let component: CreateClientAccountComponent;
  let fixture: ComponentFixture<CreateClientAccountComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateClientAccountComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateClientAccountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
