import {EventEmitter, Injectable} from '@angular/core';
import {environment} from "../../environments/environment";
import {IAuthSession} from "../interfaces/auth-session";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {LocalStorage} from "@ngx-pwa/local-storage";
import {firstValueFrom, map, tap} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _token?: string;
  private readonly _baseUrl = environment.apiUrl;
  private _session?: IAuthSession;
  private static readonly _tokenStorageKey: string = 'token';
  private _authState: EventEmitter<boolean> = new EventEmitter();
  private static readonly _sessionStorageKey: string = 'session';

  constructor(private http: HttpClient,
              private storage: LocalStorage,
              private router: Router) {
  }

  public async login(requestModel: IAuthSession): Promise<boolean> {
    const url = this._baseUrl + 'api/Auth/Login';
    return firstValueFrom(this.http.post<IAuthSession>(url, requestModel)
      .pipe(tap(async res => {
        await this.saveSession(res);
      }))
      .pipe(map(() => {
        return true;
      })))
  }

  public async saveSession(authSession?: IAuthSession): Promise<void> {
    if (authSession) {
      await firstValueFrom(this.storage.setItem(AuthService._tokenStorageKey, authSession.token));
      await firstValueFrom(this.storage.setItem(AuthService._sessionStorageKey, authSession));
    } else {
      await firstValueFrom(this.storage.removeItem(AuthService._tokenStorageKey));
      await firstValueFrom(this.storage.removeItem(AuthService._sessionStorageKey));
    }
    await this.loadSession();
  }

  private async loadSession(): Promise<void> {
    const initialStatus = !!this._token;
    const oldToken = this._token;
    this._token = <string>await firstValueFrom(this.storage.getItem(AuthService._tokenStorageKey));
    if (this._token) {
      this._session = <IAuthSession>await firstValueFrom(this.storage.getItem(AuthService._sessionStorageKey));
    } else {
      this._session = undefined;
    }
    const differentStatus = initialStatus !== !!this._token || oldToken !== this._token;
    if (differentStatus) {
      this._authState.emit(!!this._token);
    }
  }


  public async getSession(): Promise<IAuthSession> {
    if (!this._session) {
      this._session = <IAuthSession>await firstValueFrom(this.storage.getItem(AuthService._sessionStorageKey));
    }
    return this._session;
  }
}
