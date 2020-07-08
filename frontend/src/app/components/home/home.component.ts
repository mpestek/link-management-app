import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { UserService } from '../../services/user.service';
import { UserInfo } from '../../models/user-info.model';
import { ResourceStore } from '../../stores/resource.store';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  userInfo$: Observable<UserInfo>;
  resources$: Observable<any[]>;

  constructor(
    private userService: UserService,
    private resourceStore: ResourceStore,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.userInfo$ = this.userService.userInfo$;
    this.resources$ = this.resourceStore.resources$;
    this.resources$.subscribe(
      resources => console.log(resources)
    );
  }

  fileInputChanged(event) {
    console.log(event.target);
  }

  openSnackBar(text) {
    this.snackBar.open(text, 'some action', { duration: 2000 });
  }
}
