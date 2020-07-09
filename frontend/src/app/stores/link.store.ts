import { Injectable } from '@angular/core';
import { ResourceService } from '../services/resource.service';
import { BehaviorSubject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { LinkService } from '../services/link.service';
import { Link } from '../models/link.model';

@Injectable({providedIn: 'root'})
export class LinkStore {

  private _linksSubject$ = new BehaviorSubject([]);

  public links$ = this._linksSubject$.asObservable();

  constructor(
    private linkService: LinkService
  ) { 
    this.linkService.getAll().subscribe(
      (links: Link[]) => this._linksSubject$.next(links)
    );
  }

  addLink(link: Link) {
    console.log(`store`);
    console.log(link);
    return this.linkService.create(link).pipe(
      tap((createdLink: any) => this._linksSubject$.next([
        {
          ...createdLink,
          tags: [...createdLink.tags.map(tag => tag.name)]
        },
        ...this._linksSubject$.getValue()
      ]))
    );
  }
}