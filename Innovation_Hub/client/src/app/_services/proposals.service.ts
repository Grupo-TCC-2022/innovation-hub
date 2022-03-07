import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ItemFilter } from '../_interfaces/ItemFilter';

@Injectable({
  providedIn: 'root'
})
export class ProposalsService {
  baseUrl = 'https://localhost:5001/api/';

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
