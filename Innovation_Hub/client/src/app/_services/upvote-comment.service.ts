import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UpvoteCommentService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  upvoteComment(commentId: number) {
    console.log(commentId);
    return this.http.get(this.baseUrl + `proposals/upvotecomment?commentId=` + commentId);
  }
}
