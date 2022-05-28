import {EventEmitter, Injectable} from '@angular/core';
import {environment} from "../../environments/environment";
import {IAuthSession} from "../interfaces/auth-session";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {LocalStorage} from "@ngx-pwa/local-storage";
import {firstValueFrom, map, tap} from "rxjs";
import {IBuilding, IFloors, IPlaces} from "../interfaces/user";

@Injectable({
  providedIn: 'root'
})
export class BuildingService {
  private _token?: string;
  private readonly _baseUrl = environment.apiUrl;
  private _session?: IAuthSession;
  private static readonly _tokenStorageKey: string = 'token';
  private _authState: EventEmitter<boolean> = new EventEmitter();
  private static readonly _sessionStorageKey: string = 'session';

  constructor(private _http: HttpClient,
              private _storage: LocalStorage,
              private _router: Router) {
  }

  public async getBuildings(): Promise<IBuilding[]> {
    const url = this._baseUrl + '/api/Buildings/GetBuildings';
    return firstValueFrom(this._http.get<IBuilding[]>(url));
  }

  public async getFloorsByBuilding(id: string): Promise<IFloors[]> {
    const url = this._baseUrl + '/api/Floors/GetFloors';
    const floors = await firstValueFrom(this._http.get<IFloors[]>(url));
    return floors.filter(x => x.buildingId = id);
  }

  public async getPlacesbyFloor(id: string): Promise<IPlaces[]> {
    const url = this._baseUrl + '/api/Places/GetPlaces';
    const places = await firstValueFrom(this._http.get<IPlaces[]>(url));
    return places.filter(x => x.floorId = id);
  }
}
