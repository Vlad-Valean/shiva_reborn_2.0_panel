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

  session?: IAuthSession;


  constructor(public dialog: MatDialog,
              private _authService:AuthService) {
  }

  async ngOnInit() {
    this.session=await this._authService.getSession();
  }

  book (i:number) {
    // if (!this.places[i].isAssigned) this.places[i].isAssigned = true;
  }

}
