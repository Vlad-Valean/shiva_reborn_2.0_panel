import {Component, Input, OnInit} from '@angular/core';
import {ICoord} from "../../interfaces/coord";
import {MatDialog} from "@angular/material/dialog";
import {DialogContentComponent} from "../dialog-content/dialog-content.component";
import {IPlaces} from "../../interfaces/user";
import {IAuthSession} from "../../interfaces/auth-session";
import {AuthService} from "../../services/auth.service";

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.scss']
})
export class MapComponent implements OnInit {
  @Input() img?: string;
  @Input() places?: IPlaces[];
  session: IAuthSession= {
    userId: '',
    username: '',
    token: '',
    tokenType: '',
    role: '',
  };

  constructor(public dialog: MatDialog,
              private _authService:AuthService) {
  }

 async ngOnInit() {
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

  addDot(e: any) {
    if(this.session.role=='Admin') {
      const cursorX = e.clientX;
      const cursorY = e.clientY;
      //post cu place
    }
  }

  cl(a: any) {
    console.log(a);
  }
}
