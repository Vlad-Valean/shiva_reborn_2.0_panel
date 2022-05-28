export interface IUser {
  id?: string,
  firstName: string,
  lastName: string,
  email: string,
  building: IBuilding,
  assignedPlace: IPlaces,
}

export interface IBuilding {
  id?: string,
  country: string,
  city: string,
}

export interface IFloors{
  id?: string,
  name: string,
  buildingId: string,
}

export interface IPlaces{
  id?: string,
  name: string,
  isAssigned?: boolean,
  floorId?: string,
  coord: ICoord,
  assignedUser?: string,
  date?: string,
}

export interface ICoord{
  x:number,
  y:number
}
