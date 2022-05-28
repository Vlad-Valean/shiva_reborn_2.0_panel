import {Component, OnInit} from '@angular/core';
import {BuildingService} from "../../services/building.service";
import {IBuilding, IFloors, IPlaces} from "../../interfaces/user";
import {FormControl} from "@angular/forms";

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {

  buildings?: IBuilding[];
  floors?: IFloors[];
  places?: IPlaces[];

  buildingsControl = new FormControl();
  floorsControl = new FormControl();

  constructor(private _buildingService: BuildingService) {
  }

  async ngOnInit(): Promise<void> {
    this.buildings = await this._buildingService.getBuildings();
    if (this.buildings[0].id) {
      this.floors = await this._buildingService.getFloorsByBuilding(this.buildings[0].id)
    }
    if (this.floors && this.floors[0].id) {
      this.places = await this._buildingService.getPlacesbyFloor(this.floors[0].id);
    }
  }
}
