import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Link } from '../models/link.model';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class LinkService {
  constructor(private httpClient: HttpClient) { }
    
  private readonly apiUrl = "https://localhost:5001/";

  getAll() {
    return this.httpClient.get(`${this.apiUrl}links`).pipe(
      map((links: any[]) => links.map(link => ({
        ...link,
        tags: [...link.tags.map(tag => tag.name)]
      })))
    );
  }

  create(link) {
    return this.httpClient.post(`${this.apiUrl}links`, {
      ...link,
      tags: [...link.tags.map(link => ({ name: link }))]
    });
  }
}