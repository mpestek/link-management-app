import { Injectable } from '@angular/core';
import { ResourceService } from '../services/resource.service';
import { BehaviorSubject } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({providedIn: 'root'})
export class ResourceStore {

  private _resourcesSubject$ = new BehaviorSubject([]);

  public resources$ = this._resourcesSubject$.asObservable();

  constructor(
    private resourceService: ResourceService
  ) { 
    this.resourceService.getAll().subscribe(
      (resources: any[]) => this._resourcesSubject$.next(resources)
    );
  }

  addResource(resource) {
    return this.resourceService.create(resource).pipe(
      tap((createdResource: any[]) => this._resourcesSubject$.next([
        ...this._resourcesSubject$.getValue(),
        createdResource])
      )
    );
  }
}