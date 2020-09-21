import { Component, OnInit, Input, EventEmitter,Output } from '@angular/core';

@Component({
  selector: 'app-simple-form',
  templateUrl: './simple-form.component.html',
  styleUrls: ['./simple-form.component.css']
})
export class SimpleFormComponent implements OnInit {
  @Input() formFields: {
    name: string;
    displayName: string;
    tagName: string;
    value: string;
    options?: string[];
    values?: string[];
    required?: boolean;
  }[];
  @Output() formSubmit = new EventEmitter<any>();
  constructor() { }

  ngOnInit() {
  }

  onFormSubmit(formValue: any) {
    this.formSubmit.emit(formValue);
  }
}
