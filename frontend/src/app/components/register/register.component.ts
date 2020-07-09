import { Component, OnInit } from '@angular/core';
import { RegisterUserInfo } from '../../models/register-user-info.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  register(registerUserInfo: RegisterUserInfo) {
    console.log(registerUserInfo);
  }
}
