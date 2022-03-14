import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProposalsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getIdeasScroll(filter: any) {
    return this.http.get(this.baseUrl + `proposals/ideas${filter}`);
  }

  getProjectsScroll(filter: any) {
    return this.http.get(this.baseUrl + `proposals/projects${filter}`);
  }

  getProblemsScroll(filter: any) {
    return this.http.get(this.baseUrl + `proposals/problems${filter}`);
  }
}
