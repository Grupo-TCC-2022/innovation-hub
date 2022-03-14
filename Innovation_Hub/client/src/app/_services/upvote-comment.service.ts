import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UpvoteCommentService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  upvoteComment(commentId: number) {
    console.log();
    const userName = JSON.parse(localStorage.getItem('user')).userName;
    return this.http.get(this.baseUrl + `proposals/upvotecomment?commentId=` + commentId + "&userName=" + userName);
  }
}
