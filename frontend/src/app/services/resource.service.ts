import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({providedIn: 'root'})
export class ResourceService {
    constructor(private httpClient: HttpClient) { }
    
    private readonly apiUrl = "https://localhost:5001/";

    getAll() {
      return this.httpClient.get(`${this.apiUrl}resources`);
    }

    get(id: string) {
      return this.httpClient.get(`${this.apiUrl}resources/${id}`);
    }

    create(resource) {
      return this.httpClient.post(`${this.apiUrl}resources`, resource);
    }

    update(resource) {
      return this.httpClient.put(`${this.apiUrl}resources`, resource);
    }

    delete(id: string) {
      return this.httpClient.delete(`${this.apiUrl}resources/${id}`);
    }
}