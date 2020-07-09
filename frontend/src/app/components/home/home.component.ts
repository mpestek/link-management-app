import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { UserService } from '../../services/user.service';
import { UserInfo } from '../../models/user-info.model';
import { ResourceStore } from '../../stores/resource.store';
import { MatSnackBar } from '@angular/material/snack-bar';
import { withLatestFrom, tap } from 'rxjs/operators';
import { Router } from '@angular/router';

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
    private router: Router,
    private resourceStore: ResourceStore,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.userInfo$ = this.userService.userInfo$;
    // this.redirectToLoginIfNotAuthenticated();
    this.resources$ = this.resourceStore.resources$;
    this.resources$.subscribe(
      resources => console.log(resources)
    );
  }

  // private redirectToLoginIfNotAuthenticated() {
  //   of(1).pipe(
  //     withLatestFrom(this.userInfo$),
  //     tap(([_, userInfo]) => {
  //       console.log(userInfo);
  //       if (!userInfo) {
  //         this.router.navigate(['login']);
  //       }
  //     })
  //   ).subscribe();
  // }

  fileInputChanged(event) {
    console.log(event.target);
  }

  openSnackBar(text) {
    this.snackBar.open(text, 'some action', { duration: 2000 });
  }

  removeClicked(row) {
    console.log(row);
  }
}
