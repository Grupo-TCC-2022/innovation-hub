import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { NavComponent } from '../nav/nav.component';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class InterestAreasService {
  baseUrl = 'https://localhost:5001/api/';
  interestAreasList$: any = [];

  constructor(private http: HttpClient) {
    this.getInterestAreas();
  }

  getInterestAreas() {
    this.http.get(this.baseUrl + 'interestareas/interest_areas').pipe(
      map((response: any) => {
        return response;
      })).subscribe(response => {
        response.forEach(element => {
          this.interestAreasList$.push(element);
        });
        console.log(this.interestAreasList$);
      }, error => {
        console.log(error);
      });
  }
}
