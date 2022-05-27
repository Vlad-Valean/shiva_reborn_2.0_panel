import {Component, Input, OnInit} from '@angular/core';
import {ICoord} from "../../interfaces/coord";
import {MatDialog} from "@angular/material/dialog";

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.scss']
})
export class MapComponent implements OnInit {
  @Input() img?: string;
  @Input() coords: ICoord[]=[{x:13,y:24}];

  constructor(public dialog: MatDialog) {
  }

  ngOnInit(): void {
  }

  openDialog(){
    const dialogRef = this.dialog.open(DialogContentExampleDialog);
  }

  addDot(e: any) {
    const cursorX = e.clientX;
    const cursorY = e.clientY;
    this.coords.push({x: cursorX, y: cursorY });
    this.cl('da');
  }

  cl(a: any) {
    console.log(a);
  }
}
