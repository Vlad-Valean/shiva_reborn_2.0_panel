import { Component } from '@angular/core';
import {FormControl} from '@angular/forms';


@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent {
  constructor() { }
  countryControl = new FormControl();
  countries: string[] = ['Romania', 'Danemarca', 'Spania'];
  cityControl = new FormControl();
  cities: string[] = ['Oras1', 'Oras2', 'Oras3'];
  floorControl = new FormControl();
  floors: string[] = ['Etaj1', 'Etaj2', 'Etaj3'];

}
