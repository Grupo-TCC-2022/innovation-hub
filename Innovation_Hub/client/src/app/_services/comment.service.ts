import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CommentService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  postComment(model: any) {
    return this.http.post(this.baseUrl + `proposals/comment`, model);
  }
}
