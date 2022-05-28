import {Component, Input, OnInit} from '@angular/core';
import {MatDialog} from "@angular/material/dialog";
import {AuthService} from "../../services/auth.service";
import {IAuthSession} from "../../interfaces/auth-session";
import {IPlaces} from "../../interfaces/user";

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.scss']
})
export class CalendarComponent implements OnInit {

  offDay: number=0;

  session: IAuthSession = {
    userId: '',
    username: '',
    token: '',
    tokenType: '',
    role: '',
  };
  places: IPlaces[] = [{
    name: 'string',
    isAssigned: true,
    coord: {x: 10, y: 20},
    assignedUser: 'string',
    date: 'string',
  }, {
    name: 'string',
    isAssigned: true,
    coord: {x: 10, y: 20},
    assignedUser: 'string',
    date: 'string',
  }, {
    name: 'string',
    isAssigned: true,
    coord: {x: 10, y: 20},
    assignedUser: 'string',
    date: 'string',
  }, {
    name: 'string',
    isAssigned: true,
    coord: {x: 10, y: 20},
    assignedUser: 'string',
    date: 'string',
  }, {
    name: 'string',
    isAssigned: true,
    coord: {x: 10, y: 20},
    assignedUser: 'string',
    date: 'string',
  }, {
    name: 'string',
    isAssigned: false,
    coord: {x: 10, y: 20},
    assignedUser: 'string',
    date: 'string',
  }, {
    name: 'string',
    isAssigned: true,
    coord: {x: 10, y: 20},
    assignedUser: 'string',
    date: 'string',
  }, {
    name: 'string',
    isAssigned: true,
    coord: {x: 10, y: 20},
    assignedUser: 'string',
    date: 'string',
  }, {
    name: 'string',
    isAssigned: true,
    coord: {x: 10, y: 20},
    assignedUser: 'string',
    date: 'string',
  }, {
    name: 'string',
    isAssigned: true,
    coord: {x: 10, y: 20},
    assignedUser: 'string',
    date: 'string',
  }, {
    name: 'string',
    isAssigned: true,
    coord: {x: 10, y: 20},
    assignedUser: 'string',
    date: 'string',
  }, {
    name: 'string',
    isAssigned: true,
    coord: {x: 10, y: 20},
    assignedUser: 'string',
    date: 'string',
  }, {
    name: 'string',
    isAssigned: false,
    coord: {x: 10, y: 20},
    assignedUser: 'string',
    date: 'string',
  }, {
    name: 'string',
    isAssigned: true,
    coord: {x: 10, y: 20},
    assignedUser: 'string',
    date: 'string',
  }];

  constructor(public dialog: MatDialog,
              private _authService: AuthService) {
  }

  async ngOnInit() {
    this.session = await this._authService.getSession();
    const date = new Date();
    const firstDay = new Date(date.getFullYear(), date.getMonth(), 3);
    this.offDay= firstDay.getDay();
  }

  book(i: number) {
    if (!this.places[i].isAssigned || this.places[i].assignedUser == this.session.userId) this.places[i].isAssigned = !this.places[i].isAssigned;
  }

  bookMonth(){
    this.places.forEach(x=>{if (!x.isAssigned || x.assignedUser == this.session.userId) x.isAssigned=true})
  }


}
