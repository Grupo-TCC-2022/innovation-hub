import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProblemsService {
  baseUrl = environment.apiUrl;

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
