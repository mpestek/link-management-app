import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { UserService } from '../../services/user.service';
import { UserInfo } from '../../models/user-info.model';
import { tap, catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { Link } from '../../models/link.model';
import { LinkStore } from '../../stores/link.store';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  userInfo$: Observable<UserInfo>;
  links$: Observable<Link[]>;

  constructor(
    private userService: UserService,
    private linkStore: LinkStore,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.userInfo$ = this.userService.userInfo$;
    this.links$ = this.linkStore.links$;
  }

  logout() {
    this.userService.logout().pipe(
      tap(() => this.router.navigate(['login']),
      catchError(() => {
        console.log('Logout failed.');
        return of();
      })
    )).subscribe();
  }

  createLink(link: Link) {
    console.log(`component`);
    console.log(link);
    this.linkStore.addLink(link).subscribe();
  }
}
