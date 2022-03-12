import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProblemsService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getIdeasScroll(filter: any) {
    return this.http.get(this.baseUrl + `problems/ideas${filter}`);
  }

  getProjectsScroll(filter: any) {
    return this.http.get(this.baseUrl + `problems/projects${filter}`);
  }

  getProblemsScroll(filter: any) {
    return this.http.get(this.baseUrl + `problems/problems${filter}`);
  }
}
