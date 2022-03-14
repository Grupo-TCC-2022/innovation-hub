import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { faArrowCircleUp as arrowSolid } from '@fortawesome/free-solid-svg-icons';
import { faArrowAltCircleUp as arrowRegular } from '@fortawesome/free-regular-svg-icons';
import { faStar as starFavoriteSolid } from '@fortawesome/free-solid-svg-icons';
import { faStar as starFavoriteRegular } from '@fortawesome/free-regular-svg-icons';
import { InterestAreaService } from 'src/app/_services/interest-area.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CommentService } from 'src/app/_services/comment.service';
import { ToastrService } from 'ngx-toastr';
import { UpvoteCommentService } from 'src/app/_services/upvote-comment.service';

@Component({
  selector: 'app-feed-card',
  templateUrl: './feed-card.component.html',
  styleUrls: ['./feed-card.component.css']
})
export class FeedCardComponent implements OnInit {
  @Input() proposal: any;
  arrowSolid = arrowSolid;
  arrowRegular = arrowRegular;
  starFavoriteSolid = starFavoriteSolid;
  starFavoriteRegular = starFavoriteRegular;
  public modalRef?: BsModalRef;
  model: any = {}

  constructor(public interestAreaService: InterestAreaService, private modalService: BsModalService, public commentService: CommentService, private toastr: ToastrService, public upvoteCommentService: UpvoteCommentService) { }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  postComment() {
    this.model.proposalid = this.proposal.id;
    console.log(this.model);
    this.commentService.postComment(this.model).subscribe();
    this.toastr.success("Comentário feito com sucesso")
    this.model.commenttext = "";
  }

  upvoteComment(commentId: number) {
    console.log(document.getElementById(commentId + "count").innerHTML);
    if (document.getElementById(commentId + "solid").hidden) {
      document.getElementById(commentId + "count").innerHTML = String(Number.parseInt(document.getElementById(commentId + "count").innerHTML) + 1);
    } else {
      document.getElementById(commentId + "count").innerHTML = String(Number.parseInt(document.getElementById(commentId + "count").innerHTML) - 1);
    }
    document.getElementById(commentId + "solid").hidden = !document.getElementById(commentId + "solid").hidden;
    document.getElementById(commentId + "regular").hidden = !document.getElementById(commentId + "regular").hidden;


    this.upvoteCommentService.upvoteComment(commentId).subscribe();
  }

  ngOnInit(): void {
  }

}
