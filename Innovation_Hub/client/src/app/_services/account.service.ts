import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { NavComponent } from '../nav/nav.component';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'https://localhost:5001/api/';
  private currentUserSource = new ReplaySubject<User>(1);
  currenUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) { }

  login(model: User, nav: NavComponent) {
    return this.http.post(this.baseUrl + 'account/login', model).pipe(
      map((response: any) => {
        const user = response;
        if(user) {
          nav.modalRef?.hide();
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
        return user;
      })
    );
  }

  register(model: any, nav: NavComponent) {
    return this.http.post(this.baseUrl + 'account/register', model).pipe(
      map((user: User) => {
        if(user) {
          nav.modalRef?.hide();
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
        return user;
      })
    );
  }

  setCurrentUser(user: User) {
    this.currentUserSource.next(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}
