export interface IUser {
  id?: string,
  firstName: string,
  lastName: string,
  email: string,
  building?: IBuilding,
  assignedPlace?: IPlaces,
}

export interface IBuilding {
  id?: string,
  country: string,
  city: string,
  floors: IFloors[]
}

export interface IFloors{
  id?: string,
  name: string,
  places: IPlaces[]
}

export interface IPlaces{
  id?: string,
  name: string,
  isAssigned: boolean,
  coord: ICoord,
  assignedUser: string,
  date: string,
}

export interface ICoord{
  x:number,
  y:number
}
