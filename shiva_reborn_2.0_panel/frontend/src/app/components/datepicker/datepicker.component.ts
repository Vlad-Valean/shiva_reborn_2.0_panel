import {Component, EventEmitter, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-datepicker',
  templateUrl: './datepicker.component.html',
  styleUrls: ['./datepicker.component.scss']
})
export class DatepickerComponent implements OnInit {
  todayDate= new Date();
  twoMonth=new Date();
  date: Date=new Date();
  @Output() outputDate = new EventEmitter<Date>();

  constructor() { }

  ngOnInit(): void {
    this.twoMonth.setMonth(this.twoMonth.getMonth() + 2)
  }

  addDate(){
    this.outputDate.emit(this.date);
  }

}
