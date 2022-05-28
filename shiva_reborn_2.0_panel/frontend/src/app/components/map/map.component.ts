import {Component, Input, OnInit} from '@angular/core';
import {MatDialog} from "@angular/material/dialog";
import {DialogContentComponent} from "../dialog-content/dialog-content.component";
import {IPlaces} from "../../interfaces/user";
import {IAuthSession} from "../../interfaces/auth-session";
import {AuthService} from "../../services/auth.service";
import {MatDatepicker} from "@angular/material/datepicker";
import {BuildingService} from "../../services/building.service";

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.scss']
})
export class MapComponent implements OnInit {
  @Input() img?: string;
  @Input() places?: IPlaces[];
  todayDate= new Date();
  twoMonth=new Date();
  session: IAuthSession= {
    userId: '',
    username: '',
    token: '',
    tokenType: '',
    role: '',
  };
  date: Date=new Date();

  constructor(public dialog: MatDialog,
              private _authService:AuthService,
              private _buildingService:BuildingService) {
  }

 async ngOnInit() {
    this.twoMonth.setMonth(this.twoMonth.getMonth() + 2)
    this.session=await this._authService.getSession();
  }

  openDialog() {
    if(this.session.role=='Admin') {
      const dialogRef = this.dialog.open(DialogContentComponent);
      let instance = dialogRef.componentInstance;
      instance.text = "admin"
    }
    else{
      const dialogRef = this.dialog.open(DialogContentComponent);
      let instance = dialogRef.componentInstance;
      instance.text = "user"
    }
  }

  addDot(e: MouseEvent) {
    if(this.session.role=='Admin') {
      const cursorX = e.clientX;
      const cursorY = e.clientY;
      //post cu place
    }
  }

  changeDate(){
    console.log(this.date);
  }

  padTo2Digits(num:number) {
    return num.toString().padStart(2, '0');
  }

   formatDate(date:Date) {
    return [
      date.getFullYear(),
      this.padTo2Digits(date.getMonth() + 1),
      this.padTo2Digits(date.getDate()),
    ].join('-');
  }

  isOccUser(p:IPlaces){
    const index=p.dates.indexOf(this.formatDate(this.date));
    return !!(p.usersId[index] && p.usersId[index] == this.session.userId);
  }
  isOcc(p:IPlaces){
    const index=p.dates.indexOf(this.formatDate(this.date));
    return !!(p.usersId[index] && p.usersId[index] !== this.session.userId);
  }

}
