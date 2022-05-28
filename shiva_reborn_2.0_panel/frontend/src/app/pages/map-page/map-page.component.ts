import { Component, OnInit } from '@angular/core';
import {ICoord, IPlaces} from "../../interfaces/user";

@Component({
  selector: 'app-map-page',
  templateUrl: './map-page.component.html',
  styleUrls: ['./map-page.component.scss']
})
export class MapPageComponent implements OnInit {
  img='https://imgv3.fotor.com/images/homepage-feature-card/Fotor-AI-photo-enhancement-tool.jpg';
  places:IPlaces[]=[{
    name: 'string',
    isAssigned: true,
    coord: {x:10,y:20},
    assignedUser: 'string',
    date: 'string',
  }]

  constructor() { }

  ngOnInit(): void {
  }

}
