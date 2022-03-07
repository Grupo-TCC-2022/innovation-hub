import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProposalsService {
  baseUrl = 'https://localhost:5001/api/';
  ideasList$: any = [];
  projectsList$: any = [];
  problemsList$: any = [];

  constructor(private http: HttpClient) {
    this.getProjectsScroll();
  }

  getIdeasScroll() {
    this.http.get(this.baseUrl + 'proposals/ideas').pipe(
      map((response: any) => {
        return response;
      })).subscribe(response => {
        response.forEach(element => {
          this.ideasList$.push(element);
        });
        console.log(this.ideasList$);
      }, error => {
        console.log(error);
      });
  }

  getProjectsScroll() {
    this.http.get(this.baseUrl + 'proposals/projects').pipe(
      map((response: any) => {
        return response;
      })).subscribe(response => {
        response.forEach(element => {
          this.projectsList$.push(element);
        });
        console.log(this.projectsList$);
      }, error => {
        console.log(error);
      });
  }

  getProblemsScroll() {
    this.http.get(this.baseUrl + 'proposals/problems').pipe(
      map((response: any) => {
        return response;
      })).subscribe(response => {
        response.forEach(element => {
          this.problemsList$.push(element);
        });
        console.log(this.problemsList$);
      }, error => {
        console.log(error);
      });
  }
}
