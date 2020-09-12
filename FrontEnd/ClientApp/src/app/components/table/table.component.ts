import { Component, OnInit , Input,AfterViewInit, ViewChild, ElementRef,SimpleChanges,OnChanges, SimpleChange} from '@angular/core';

export interface RowAction {
  text: string;
  icon: string;
  rowclick: (rowRecord: any) => void;
}
@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit, OnChanges {

  @Input() rows:any[]=[];
  @Input() actions: RowAction[]=[];
  columnNames = [];
  
  constructor() { }

 

  ngOnInit() {
    //this.columnNames = this.rows.length > 0 ? Object.keys(this.rows[0]) : [];
   
  }

  ngOnChanges(changes: SimpleChanges) {

    if ("rows" in changes && this.columnNames.length==0) {
      let change: SimpleChange = changes['rows'];
      this.columnNames = change.currentValue.length > 0 ? Object.keys(change.currentValue[0]) : [];

    }
  }

  recordToValues(rec: any) {
    return Object.values(rec);
  }

  getPadding() {
    return ({ padding: "1em" });
  }

}
