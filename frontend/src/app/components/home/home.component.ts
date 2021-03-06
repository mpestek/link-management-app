import { Component, OnInit } from '@angular/core';
import { Observable, of, BehaviorSubject } from 'rxjs';
import { UserService } from '../../services/user.service';
import { UserInfo } from '../../models/user-info.model';
import { tap, catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { Link } from '../../models/link.model';
import { LinkStore } from '../../stores/link.store';
import { TagSuggestionService } from '../../services/tag-suggestion.service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  userInfo$: Observable<UserInfo>;
  links$: Observable<Link[]>;
  suggestedTagsSubject$ = new BehaviorSubject<string[]>([]);
  suggestedTags$ = this.suggestedTagsSubject$.asObservable();

  getFromAnalysisControl = new FormControl(false);

  constructor(
    private userService: UserService,
    private linkStore: LinkStore,
    private tagSuggestionService: TagSuggestionService,
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
    this.linkStore.addLink(link).subscribe();
  }

  uriChanged({ newUri, isFromAnalysis }) {
    this.tagSuggestionService
      .getSuggestions(newUri, isFromAnalysis)
      .subscribe(
        (suggestedTags: string[]) => this.suggestedTagsSubject$.next(suggestedTags)
      )
  }
}
