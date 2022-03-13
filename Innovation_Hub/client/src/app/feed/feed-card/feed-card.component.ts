import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { faArrowCircleUp as arrowSolid } from '@fortawesome/free-solid-svg-icons';
import { faArrowAltCircleUp as arrowRegular } from '@fortawesome/free-regular-svg-icons';
import { faStar as starFavoriteSolid } from '@fortawesome/free-solid-svg-icons';
import { faStar as starFavoriteRegular } from '@fortawesome/free-regular-svg-icons';
import { InterestAreaService } from 'src/app/_services/interest-area.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

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

  constructor(public interestAreaService: InterestAreaService, private modalService: BsModalService) { }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  ngOnInit(): void {
  }

}
