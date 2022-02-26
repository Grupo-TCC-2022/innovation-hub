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
  interestAreasListFormated$: any = [];

  constructor(private http: HttpClient) { }

  getInterestAreas() {
    return this.http.get(this.baseUrl + 'interestareas/interest_areas').pipe(
      map((response: any) => {
        return response;
      }));
  }
}
