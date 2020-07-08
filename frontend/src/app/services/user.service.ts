import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { LoginUserInfo } from '../models/login-user-info.model';
import { RegisterUserInfo } from '../models/register-user-info.model';
import { UserInfo } from '../models/user-info.model';
import { UserRole } from '../models/user-role.enum';

@Injectable({providedIn: 'root'})
export class UserService {
    constructor(private httpClient: HttpClient) { }
    
    private readonly apiUrl = "https://localhost:5001/";

    private _userInfoSubject$ = new BehaviorSubject<UserInfo>(null);

    get userInfo$() {
        return this._userInfoSubject$.asObservable();
    }

    login(loginUserInfo: LoginUserInfo) {
        return this.httpClient.post(`${this.apiUrl}account/login`, loginUserInfo);
    }

    register(registerUserInfo: RegisterUserInfo) {
        return this.httpClient.post(`${this.apiUrl}account/register`, registerUserInfo);
    }

    logout() {
        return this.httpClient.post(`${this.apiUrl}account/logout`, {});
    }

    getUserInfo(): Observable<UserInfo> {
        return this.httpClient
            .get<UserInfo>(`${this.apiUrl}account/userinfo`)
            .pipe(
                tap(userInfo => this._userInfoSubject$.next(userInfo))
            );
    }

    isInRole(userRole: UserRole) {
        if (!this._userInfoSubject$.value) {
            return false;
        }

        return this._userInfoSubject$.value.roles.includes(userRole);
    }
}