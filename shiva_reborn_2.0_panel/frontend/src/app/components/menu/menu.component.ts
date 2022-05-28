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

  public openMap = false;

  buildings: IBuilding[] = [{
    id: '',
    country: '',
    city: '',
  }]
  floors: IFloors[] = [{
    id: '',
    name: '',
    buildingId: '',
  }];
  places?: IPlaces[];

  buildingsControl = new FormControl();
  floorsControl = new FormControl();

  constructor(private _buildingService: BuildingService) {
  }

  async ngOnInit(): Promise<void> {
    this.buildings = await this._buildingService.getBuildings();
    this.floors = await this._buildingService.getFloorsByBuilding(this.buildings[0].id)
    this.places = await this._buildingService.getPlacesbyFloor(this.floors[0].id);

  }

  async setFloors(i: number) {
    this.floors = await this._buildingService.getFloorsByBuilding(this.buildings[i].id);
  }

  searchFloors(i: number) {
    this.setFloors(i);
    this.floorsControl.patchValue('');
  }

  async submit() {
    const floor = this.floors.find(x => x.name == this.floorsControl.value);
    if (floor) {
      this.places = await this._buildingService.getPlacesbyFloor(floor.id);
      this.openMap = true;
    }
  }
}
