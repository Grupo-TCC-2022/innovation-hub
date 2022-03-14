import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CommentService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  postComment(model: any) {
    const userName = JSON.parse(localStorage.getItem('user')).userName
    return this.http.post(this.baseUrl + `proposals/comment?userName=` + userName, model);
  }
}
