import { Component, OnInit } from '@angular/core';
import { RegisterUserInfo } from '../../models/register-user-info.model';
import { UserService } from '../../services/user.service';
import { tap, catchError } from 'rxjs/operators';
import { of } from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(
    private userService: UserService
  ) { }

  ngOnInit(): void {
  }

  register(registerUserInfo: RegisterUserInfo) {
    this.userService.register(registerUserInfo).pipe(
      tap(() => location.href = 'home'),
      catchError(() => {
        console.log(`Registration failed.`);
        return of();
      })
    ).subscribe();
  }
}
