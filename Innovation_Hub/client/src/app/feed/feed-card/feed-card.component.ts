import { Component, Input, OnInit } from '@angular/core';
import { faArrowCircleUp as arrowSolid } from '@fortawesome/free-solid-svg-icons';
import { faArrowAltCircleUp as arrowRegular } from '@fortawesome/free-regular-svg-icons';
import { faStar as starFavoriteSolid } from '@fortawesome/free-solid-svg-icons';
import { faStar as starFavoriteRegular } from '@fortawesome/free-regular-svg-icons';
import { InterestAreaService } from 'src/app/_services/interest-area.service';

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

  constructor(public interestAreaService: InterestAreaService) { }

  toggleVote(event: any) {
    //A fazer
    document.getElementById("openModalBtn").click();
  }

  ngOnInit(): void {
  }

}
