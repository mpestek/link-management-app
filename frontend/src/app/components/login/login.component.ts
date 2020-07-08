import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { LoginUserInfo } from '../../models/login-user-info.model';
import { tap, catchError } from 'rxjs/operators';
import { of } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  initialUserInfo = {
    username: 'admin',
    password: 'Admin123!'
  };

  constructor(
    private userService: UserService
  ) { }

  ngOnInit(): void {
  }

  login(loginUserInfo: LoginUserInfo) {
    this.userService.login(loginUserInfo).pipe(
      tap(() => location.href = 'home'),
      catchError(() => {
        console.log(`Login failed.`);
        return of();
      })
    ).subscribe();
  }
}
