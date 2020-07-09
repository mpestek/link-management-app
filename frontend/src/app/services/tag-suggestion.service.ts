import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({providedIn: 'root'})
export class TagSuggestionService {
    constructor(private httpClient: HttpClient) { }
    
    private readonly apiUrl = "https://localhost:5001/";

    getSuggestions(uri) {
      return this.httpClient.post(`${this.apiUrl}suggest-tags`, JSON.stringify(uri), {
        headers: { 'Content-Type': 'application/json' }
      });
    }
}